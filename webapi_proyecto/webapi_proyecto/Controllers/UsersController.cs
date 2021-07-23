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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace webapi_proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UsersController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public UsersController(IConfiguration configuration) {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            try
            {
                string query = @"select * from users";
                DataTable table = new DataTable();
                string sqlDataSource = _configuration.GetConnectionString("Default");
                MySqlDataReader myReader;

                using (MySqlConnection conn = new MySqlConnection(sqlDataSource))
                {
                    conn.Open();
                    using (MySqlCommand comand = new MySqlCommand(query, conn))
                    {
                        myReader = comand.ExecuteReader();
                        table.Load(myReader);
                        myReader.Close();
                        conn.Close();
                    }
                }
                return new JsonResult(table);
            }
            catch (Exception e) {
                return new JsonResult(e);
            }
        }
        [HttpGet("{id}")]
        public JsonResult GetId(int id)
        {
            try
            {
                string query = @"call inventory.select_user(@IdUser)";
                DataTable table = new DataTable();
                string sqlDataSource = _configuration.GetConnectionString("Default");
                MySqlDataReader myReader;

                using (MySqlConnection conn = new MySqlConnection(sqlDataSource))
                {
                    conn.Open();
                    using (MySqlCommand comand = new MySqlCommand(query, conn))
                    {
                        comand.Parameters.AddWithValue("@IdUser", id);
                        myReader = comand.ExecuteReader();
                        table.Load(myReader);
                        myReader.Close();
                        conn.Close();
                    }
                }
                return new JsonResult(table);
            }
            catch (Exception e) {
                return new JsonResult(e);
            }
        }
        [HttpPost]
        public JsonResult Post(UserPost user)
        {
            try
            {
                string query = @"call inventory.insert_user(@FistName, @SecondName, @FirstLasName, @SecondLastName, @Email, @Password, @Type)";
                DataTable table = new DataTable();
                string sqlDataSource = _configuration.GetConnectionString("Default");
                MySqlDataReader myReader;

                using (MySqlConnection conn = new MySqlConnection(sqlDataSource))
                {
                    conn.Open();
                    using (MySqlCommand comand = new MySqlCommand(query, conn))
                    {

                        comand.Parameters.AddWithValue("@FistName", user.FirstName);
                        comand.Parameters.AddWithValue("@SecondName", user.SecondName);
                        comand.Parameters.AddWithValue("@FirstLasName", user.LastName);
                        comand.Parameters.AddWithValue("@SecondLastName", user.SecondLastName);
                        comand.Parameters.AddWithValue("@Email", user.Email);
                        comand.Parameters.AddWithValue("@Password", user.Password);
                        comand.Parameters.AddWithValue("@Type", user.UserType);
                        myReader = comand.ExecuteReader();
                        table.Load(myReader);
                        myReader.Close();
                        conn.Close();
                    }
                }
                return new JsonResult("Se Agrego correctamente");
            }
            catch (Exception e)
            {
                return new JsonResult(e);
            }
        }


        [HttpPut]
        public JsonResult Put(Users user)
        {
            try
            {
                string query = @"call inventory.update_user(@IdUser,@FistName, @SecondName, @FirstLasName, @SecondLastName, @Email, @Password, @Type)";
                DataTable table = new DataTable();
                string sqlDataSource = _configuration.GetConnectionString("Default");
                MySqlDataReader myReader;

                using (MySqlConnection conn = new MySqlConnection(sqlDataSource))
                {
                    conn.Open();
                    using (MySqlCommand comand = new MySqlCommand(query, conn))
                    {
                        comand.Parameters.AddWithValue("@IdUser", user.IdUser);
                        comand.Parameters.AddWithValue("@FistName", user.FirstName);
                        comand.Parameters.AddWithValue("@SecondName", user.SecondName);
                        comand.Parameters.AddWithValue("@FirstLasName", user.LastName);
                        comand.Parameters.AddWithValue("@SecondLastName", user.SecondLastName);
                        comand.Parameters.AddWithValue("@Email", user.Email);
                        comand.Parameters.AddWithValue("@Password", user.Password);
                        comand.Parameters.AddWithValue("@Type", user.UserType);
                        myReader = comand.ExecuteReader();
                        table.Load(myReader);
                        myReader.Close();
                        conn.Close();
                    }
                }
                return new JsonResult("Se Actualizo correctamente");
            }
            catch (Exception e) {
                return new JsonResult(e);
            }
        }

        [HttpDelete("{id}")]

        public JsonResult Delete(int id)
        {
            try
            {
                string query = @"call inventory.delete_user(@IdUser)";
                DataTable table = new DataTable();
                string sqlDataSource = _configuration.GetConnectionString("Default");
                MySqlDataReader myReader;

                using (MySqlConnection conn = new MySqlConnection(sqlDataSource))
                {
                    conn.Open();
                    using (MySqlCommand comand = new MySqlCommand(query, conn))
                    {
                        comand.Parameters.AddWithValue("@IdUser", id);
                        myReader = comand.ExecuteReader();
                        table.Load(myReader);
                        myReader.Close();
                        conn.Close();
                    }
                }
                return new JsonResult("Se borro completamente");
            }
            catch (Exception e) {
                return new JsonResult(e);
            }
        }

    }
}
