using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace DFEItechFurniture.Models
{
    public class CategorySql: MySqlLink
    {
        public CategorySql()
        {
            cmd.Connection = con;
            con.Open();
        }
        ~CategorySql()
        {
            con.Close();
        }


        public Category FindCategoryById(int id)
        {
            Category category = new Category();
            try
            {
                con.Close();
                con.Open();
                cmd.CommandText = "SELECT * FROM type WHERE type_id =" + id;
                //cmd.Parameters.AddWithValue("@ID", id);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    category.CategoryId = rdr.GetInt32(0);
                    category.CategoryName = rdr.GetString(1);
                }
            }
            catch (MySqlException e)
            {
                category.CategoryName = e.ToString();
            }
            return category;
        }

        public Category FindCategoryByName(string name)
        {
            Category category = new Category();
            try
            {
                cmd.CommandText = "SELECT * FROM type WHERE type_name =@NAME";
                cmd.Parameters.AddWithValue("@NAME", name);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    category.CategoryId = rdr.GetInt32(0);
                    category.CategoryName = rdr.GetString(1);
                }
            }
            catch (MySqlException e)
            {
                category.CategoryName = e.ToString();
            }
            return category;
        }

        public List<Category> GetAllCategories()
        {
            List<Category> allCategories = new List<Category>();
            try
            {
                cmd.CommandText = "SELECT * FROM type";
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Category category = new Category();
                    category.CategoryId = rdr.GetInt32(0);
                    category.CategoryName = rdr.GetString(1);
                    allCategories.Add(category);
                }
            }
            catch (MySqlException e)
            {
                Category category = new Category();
                category.CategoryName = e.ToString();
                allCategories.Add(category);
            }
            return allCategories;
        }
    }
}