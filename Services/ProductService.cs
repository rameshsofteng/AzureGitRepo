﻿using SQLApp.Models;
using System.Data.SqlClient;

namespace SQLApp.Services
{
    public class ProductService
    {
        private static string db_source = "azsqldbappserver.database.windows.net"; // SQL DB Server Name
        private static string db_user = "sqladmin";
        private static string db_password = "rameshSofT@1985";
        private static string db_database = "MyFirstAZSQLDB";

        private SqlConnection GetConnection()
        {
            var _builder = new  SqlConnectionStringBuilder();
            _builder.DataSource = db_source;
            _builder.UserID = db_user;
            _builder.Password = db_password;
            _builder.InitialCatalog = db_database;
            return new SqlConnection(_builder.ConnectionString);
        }

        public List<Product> GetProducts()
        { 
            SqlConnection conn = GetConnection();
            List<Product> _product_lst = new List<Product>();
            string statement = "SELECT ProductID, ProductName, Quantity FROM Products;";

            conn.Open();

            SqlCommand cmd = new SqlCommand(statement, conn);            

            using (SqlDataReader reader = cmd.ExecuteReader())
            { 
                while (reader.Read())
                {
                    Product product = new Product()
                    {
                        ProductID = reader.GetInt32(0),
                        ProductName = reader.GetString(1),
                        Quantity = reader.GetInt32(2)
                    };
                    _product_lst.Add(product);
                }
            }
            conn.Close();
            return _product_lst;
        }
    }





}
