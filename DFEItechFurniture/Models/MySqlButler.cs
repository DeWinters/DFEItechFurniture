using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace DFEItechFurniture.Models
{
    public class MySqlButler : MySqlLink
    {
        public MySqlButler()
        { 
            cmd.Connection = con;
            con.Open();
            LotSql lotSql = new LotSql();
            
        }
        ~MySqlButler()
        {
            con.Close();
        }

        CategorySql categorySql = new CategorySql();

        public Lot InsertLot(string name, int type, string imgString, string descript, Boolean exterior, decimal price)
        {
            Lot lot = new Lot();
            if (name != null && type != 0 && price >0)
            {
                try
                {
                    cmd.CommandText = "INSERT INTO lot (lot_name, lot_type, lot_image, lot_descript, exterior, price) VALUES(@NAME, @TYPE, @IMAGE, @DESCRIPT, @EXTERIOR, @PRICE)";
                    cmd.Parameters.AddWithValue("@NAME", name);
                    cmd.Parameters.AddWithValue("@TYPE", type);
                    cmd.Parameters.AddWithValue("@IMAGE", imgString);
                    cmd.Parameters.AddWithValue("@DESCRIPT", descript);
                    cmd.Parameters.AddWithValue("@EXTERIOR", exterior);
                    cmd.Parameters.AddWithValue("@PRICE", price);
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException e)
                {
                    lot.LotName = e.ToString();
                }
            }
            return lot;
        }

        public Lot DeleteLot(int id)
        {
            Lot lot = FindLotById(id);
            if (id != 0)
            {
                try
                {
                    cmd.CommandText = "DELETE FROM lot WHERE worksop_id= @ID";
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException e)
                {
                    lot.LotName = e.ToString();
                }
            }
            else
            {
                lot.LotName = "No Lot ID entered";
            }
            return lot;
        }

        public Lot FindLotById(int id)
        {
            Lot lot = new Lot();
            try
            {
                cmd.CommandText = "SELECT * FROM lot WHERE lot_id=" + id;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    lot.LotId = rdr.GetInt32(0);
                    lot.LotName = rdr.GetString(1);
                    lot.LotType = categorySql.FindCategoryById(rdr.GetInt32(2));
                    lot.LotImage = rdr.GetString(3);
                    lot.LotDescript = rdr.GetString(4);
                    lot.Exterior = rdr.GetBoolean(5);
                    lot.Price = rdr.GetDecimal(6);
                }
            }
            catch (MySqlException e)
            {
                lot.LotName = e.ToString();
            }
            return lot;
        }

        public List<Lot> GetAllLots()
        {
            List<Lot> lots = new List<Lot>();
            try
            {
                cmd.CommandText = "SELECT * FROM lot";
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Lot lot = new Lot();
                    lot.LotId = rdr.GetInt32(0);
                    lot.LotName = rdr.GetString(1);
                    lot.LotType = categorySql.FindCategoryById(rdr.GetInt32(2));
                    lot.LotImage = rdr.GetString(3);
                    lot.LotDescript = rdr.GetString(4);
                    lot.Exterior = rdr.GetBoolean(5);
                    lot.Price = rdr.GetDecimal(6);
                    lots.Add(lot);
                }
            }
            catch (MySqlException e)
            {
                Lot lot = new Lot();
                lot.LotName = e.ToString();
                lots.Add(lot);
            }
            return lots;
        }

        /*********************************************************************************** Single param searches **/
        public List<Lot> GetLotsById(int id)
        {
            List<Lot> lots = new List<Lot>();
            try
            {
                cmd.CommandText = "SELECT * FROM lot WHERE lot_id=@ID";
                cmd.Parameters.AddWithValue("@ID", id);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Lot lot = new Lot();
                    lot.LotId = rdr.GetInt32(0);
                    lot.LotName = rdr.GetString(1);
                    lot.LotType = categorySql.FindCategoryById(rdr.GetInt32(2));
                    lot.LotImage = rdr.GetString(3);
                    lot.LotDescript = rdr.GetString(4);
                    lot.Exterior = rdr.GetBoolean(5);
                    lot.Price = rdr.GetDecimal(6);
                    lots.Add(lot);
                }
            }
            catch (MySqlException e)
            {
                Lot lot = new Lot();
                lot.LotName = e.ToString();
                lots.Add(lot);
            }
            return lots;
        }

        public List<Lot> GetLotsByName(string name)
        {
            List<Lot> lots = new List<Lot>();
            try
            {
                cmd.CommandText = "SELECT * FROM lot WHERE lot_name=@NAME";
                cmd.Parameters.AddWithValue("@NAME", name);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Lot lot = new Lot();
                    lot.LotId = rdr.GetInt32(0);
                    lot.LotName = rdr.GetString(1);
                    lot.LotType = categorySql.FindCategoryById(rdr.GetInt32(2));
                    lot.LotImage = rdr.GetString(3);
                    lot.LotDescript = rdr.GetString(4);
                    lot.Exterior = rdr.GetBoolean(5);
                    lot.Price = rdr.GetDecimal(6);
                    lots.Add(lot);
                }
            }
            catch (MySqlException e)
            {
                Lot lot = new Lot();
                lot.LotName = e.ToString();
                lots.Add(lot);
            }
            return lots;
        }

        public List<Lot> GetLotsByType(int type)
        {
            List<Lot> lots = new List<Lot>();
            try
            {
                cmd.CommandText = "SELECT * FROM lot WHERE lot_type=@TYPE";
                cmd.Parameters.AddWithValue("@TYPE", type);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Lot lot = new Lot();
                    lot.LotId = rdr.GetInt32(0);
                    lot.LotName = rdr.GetString(1);
                    lot.LotType = categorySql.FindCategoryById(rdr.GetInt32(2));
                    lot.LotImage = rdr.GetString(3);
                    lot.LotDescript = rdr.GetString(4);
                    lot.Exterior = rdr.GetBoolean(5);
                    lot.Price = rdr.GetDecimal(6);
                    lots.Add(lot);
                }
            }
            catch (MySqlException e)
            {
                Lot lot = new Lot();
                lot.LotName = e.ToString();
                lots.Add(lot);
            }
            return lots;
        }

        public List<Lot> GetLotsByExterior(Boolean exterior)
        {
            List<Lot> lots = new List<Lot>();
            try
            {
                cmd.CommandText = "SELECT * FROM lot WHERE exterior=@EXTERIOR";
                cmd.Parameters.AddWithValue("@EXTERIOR", exterior);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Lot lot = new Lot();
                    lot.LotId = rdr.GetInt32(0);
                    lot.LotName = rdr.GetString(1);
                    lot.LotType = categorySql.FindCategoryById(rdr.GetInt32(2));
                    lot.LotImage = rdr.GetString(3);
                    lot.LotDescript = rdr.GetString(4);
                    lot.Exterior = rdr.GetBoolean(5);
                    lot.Price = rdr.GetDecimal(6);
                    lots.Add(lot);
                }
            }
            catch (MySqlException e)
            {
                Lot lot = new Lot();
                lot.LotName = e.ToString();
                lots.Add(lot);
            }            
            return lots;
        }

        public List<Lot> GetLotsByPrice(decimal maxPrice)
        {
            List<Lot> lots = new List<Lot>();
            try
            {
                cmd.CommandText = "SELECT * FROM lot WHERE lot_price <=@MAX";
                cmd.Parameters.AddWithValue("@MAX", maxPrice);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Lot lot = new Lot();
                    lot.LotId = rdr.GetInt32(0);
                    lot.LotName = rdr.GetString(1);
                    lot.LotType = categorySql.FindCategoryById(rdr.GetInt32(2));
                    lot.LotImage = rdr.GetString(3);
                    lot.LotDescript = rdr.GetString(4);
                    lot.Exterior = rdr.GetBoolean(5);
                    lot.Price = rdr.GetDecimal(6);
                    lots.Add(lot);                   
                }
            }
            catch (MySqlException e)
            {
                Lot lot = new Lot();
                lot.LotName = e.ToString();
                lots.Add(lot);
            }
            return lots;
        }
        /*********************************************************************************** Double param searches **/
        public List<Lot> GetLotsByTypeAndName(int type, string name)
        {
            List<Lot> lots = new List<Lot>();
            try
            {
                cmd.CommandText = "SELECT * FROM lot WHERE lot_type=@TYPE & lot_name=@NAME";
                cmd.Parameters.AddWithValue("@TYPE", type);
                cmd.Parameters.AddWithValue("@NAME", name);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Lot lot = new Lot();
                    lot.LotId = rdr.GetInt32(0);
                    lot.LotName = rdr.GetString(1);
                    lot.LotType = categorySql.FindCategoryById(rdr.GetInt32(2));
                    lot.LotImage = rdr.GetString(3);
                    lot.LotDescript = rdr.GetString(4);
                    lot.Exterior = rdr.GetBoolean(5);
                    lot.Price = rdr.GetDecimal(6);
                    lots.Add(lot);
                }
            }
            catch (MySqlException e)
            {
                Lot lot = new Lot();
                lot.LotName = e.ToString();
                lots.Add(lot);
            }
            return lots;
        }

        public List<Lot> GetLotsByTypeAndPrice(int type, decimal price)
        {
            List<Lot> lots = new List<Lot>();
            try
            {
                cmd.CommandText = "SELECT * FROM lot WHERE lot_type =@TYPE & price <=@PRICE";
                cmd.Parameters.AddWithValue("@TYPE", type);
                cmd.Parameters.AddWithValue("@PRICE", price);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Lot lot = new Lot();
                    lot.LotId = rdr.GetInt32(0);
                    lot.LotName = rdr.GetString(1);
                    lot.LotType = categorySql.FindCategoryById(rdr.GetInt32(2));
                    lot.LotImage = rdr.GetString(3);
                    lot.LotDescript = rdr.GetString(4);
                    lot.Exterior = rdr.GetBoolean(5);
                    lot.Price = rdr.GetDecimal(6);
                    lots.Add(lot);
                }
            }
            catch (MySqlException e)
            {
                Lot lot = new Lot();
                lot.LotName = e.ToString();
                lots.Add(lot);
            }
            return lots;
        }

        public List<Lot> GetLotsByTypeAndExterior(int type, Boolean exterior)
        {
            List<Lot> lots = new List<Lot>();
            try
            {
                cmd.CommandText = "SELECT * FROM lot WHERE lot_type=@TYPE & exterior=@EXTERIOR";
                cmd.Parameters.AddWithValue("@TYPE", type);
                cmd.Parameters.AddWithValue("@EXTERIOR", exterior);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Lot lot = new Lot();
                    lot.LotId = rdr.GetInt32(0);
                    lot.LotName = rdr.GetString(1);
                    lot.LotType = categorySql.FindCategoryById(rdr.GetInt32(2));
                    lot.LotImage = rdr.GetString(3);
                    lot.LotDescript = rdr.GetString(4);
                    lot.Exterior = rdr.GetBoolean(5);
                    lot.Price = rdr.GetDecimal(6);
                    lots.Add(lot);
                }
            }
            catch (MySqlException e)
            {
                Lot lot = new Lot();
                lot.LotName = e.ToString();
                lots.Add(lot);
            }
            return lots;
        }

        public List<Lot> GetLotsByNameAndExterior(string name, Boolean exterior)
        {
            List<Lot> lots = new List<Lot>();
            try
            {
                cmd.CommandText = "SELECT * FROM lot WHERE lot_name=@NAME & exterior=@EXTERIOR";
                cmd.Parameters.AddWithValue("@NAME", name);
                cmd.Parameters.AddWithValue("@EXTERIOR", exterior);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Lot lot = new Lot();
                    lot.LotId = rdr.GetInt32(0);
                    lot.LotName = rdr.GetString(1);
                    lot.LotType = categorySql.FindCategoryById(rdr.GetInt32(2));
                    lot.LotImage = rdr.GetString(3);
                    lot.LotDescript = rdr.GetString(4);
                    lot.Exterior = rdr.GetBoolean(5);
                    lot.Price = rdr.GetDecimal(6);
                    lots.Add(lot);
                }
            }
            catch (MySqlException e)
            {
                Lot lot = new Lot();
                lot.LotName = e.ToString();
                lots.Add(lot);
            }
            return lots;
        }

        /*********************************************************************************** TYPE queries **/



    }
}



