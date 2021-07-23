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
    public class ProductController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public ProductController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            try
            {
                string query = @"select * from products";
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
        public JsonResult GetId(string id)
        {
            try
            {
                string query = @"call inventory.select_product(@IdUser)";
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
        public JsonResult Post(Products product)
        {
            try
            {
                string query = @"call inventory.insert_product(@IdProduct, @ProductName, @ProductDesc, @ProductPrice, @ProducCat)";
                DataTable table = new DataTable();
                string sqlDataSource = _configuration.GetConnectionString("Default");
                MySqlDataReader myReader;

                using (MySqlConnection conn = new MySqlConnection(sqlDataSource))
                {
                    conn.Open();
                    using (MySqlCommand comand = new MySqlCommand(query, conn))
                    {
                        comand.Parameters.AddWithValue("@IdProduct", product.IdProduct);
                        comand.Parameters.AddWithValue("@ProductName", product.ProductName);
                        comand.Parameters.AddWithValue("@ProductDesc", product.ProductDesc);
                        comand.Parameters.AddWithValue("@ProductPrice", product.ProductPrice);
                        comand.Parameters.AddWithValue("@ProducCat", product.ProductCategory);
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
        public JsonResult Put(Products product)
        {
            try
            {
                string query = @"call inventory.update_product(@IdProduct, @ProductName, @ProductDesc, @ProductPrice, @ProducCat)";
                DataTable table = new DataTable();
                string sqlDataSource = _configuration.GetConnectionString("Default");
                MySqlDataReader myReader;

                using (MySqlConnection conn = new MySqlConnection(sqlDataSource))
                {
                    conn.Open();
                    using (MySqlCommand comand = new MySqlCommand(query, conn))
                    {
                        comand.Parameters.AddWithValue("@IdProduct", product.IdProduct);
                        comand.Parameters.AddWithValue("@ProductName", product.ProductName);
                        comand.Parameters.AddWithValue("@ProductDesc", product.ProductDesc);
                        comand.Parameters.AddWithValue("@ProductPrice", product.ProductPrice);
                        comand.Parameters.AddWithValue("@ProducCat", product.ProductCategory);
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

        public JsonResult Delete(string id)
        {
            try
            {
                string query = @"call inventory.delete_product(@IdProduct)";
                DataTable table = new DataTable();
                string sqlDataSource = _configuration.GetConnectionString("Default");
                MySqlDataReader myReader;

                using (MySqlConnection conn = new MySqlConnection(sqlDataSource))
                {
                    conn.Open();
                    using (MySqlCommand comand = new MySqlCommand(query, conn))
                    {
                        comand.Parameters.AddWithValue("@IdProduct", id);
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
