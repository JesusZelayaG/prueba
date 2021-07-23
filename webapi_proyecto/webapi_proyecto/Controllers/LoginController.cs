using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using webapi_proyecto.Models;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace webapi_proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        [HttpPost]
        public JsonResult Post(Login login)
        {

            try
            {
                Users user = new Users();
                string query = @"call inventory.login(@Email, @Password)";
                string sqlDataSource = _configuration.GetConnectionString("Default");
                MySqlDataReader myReader;
                using (MySqlConnection conn = new MySqlConnection(sqlDataSource))
                {
                    conn.Open();
                    using (MySqlCommand comand = new MySqlCommand(query, conn))
                    {
                        comand.Parameters.AddWithValue("@Email", login.email);
                        comand.Parameters.AddWithValue("@Password", login.password);
                        myReader = comand.ExecuteReader();
                        if (myReader.HasRows)
                        {
                            while (myReader.Read())
                            {
                                user.IdUser = int.Parse(myReader["id_user"].ToString());
                                user.FirstName = myReader["first_name"].ToString();
                                user.SecondName = myReader["second_name"].ToString();
                                user.LastName = myReader["last_name"].ToString();
                                user.SecondLastName = myReader["second_last_name"].ToString();
                                user.Email = myReader["user_email"].ToString();
                                user.Password = myReader["user_password"].ToString();
                                user.UserType = myReader["user_type"].ToString();
                            }
                            return new JsonResult(BuildToken(user));
                        }
                        else {
                            return new JsonResult("Usuario no encontrado");
                        }
                        myReader.Close();
                        conn.Close();
                    }
                }
                
            }
            catch (Exception e)
            {
                return new JsonResult(e);
            }
        }

        private IActionResult BuildToken(Users user) 
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, user.FirstName),
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())

            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecreteKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            
            var expiration = DateTime.UtcNow.AddHours(1);


            JwtSecurityToken token = new JwtSecurityToken(
              issuer: "yourdomain.com",
              audience: "yourdomain.com",
              claims: claims,
              expires: expiration,
              signingCredentials: creds);

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = expiration
            });

        }

    }
}
