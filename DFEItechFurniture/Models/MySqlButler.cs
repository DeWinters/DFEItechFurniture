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
            TypeSql typeSql = new TypeSql(); 
        }
        ~MySqlButler()
        {
            con.Close();
        }

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
                    //lot = GetLotsById() nope
                }
                catch (MySqlException e)
                {
                    lot.LotName = e.ToString();
                }
                finally
                {
                   // con.Close();
                }
            }
            return lot;
        }

        public Lot FindLotById(int id)
        {
            Lot lot = new Lot();
            try
            {
                con.Open();
                cmd.CommandText = "SELECT * FROM lot WHERE lot_id=" + id;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    lot.LotId = rdr.GetInt32(0);
                    lot.LotName = rdr.GetString(1);
                    lot.LotType = rdr.GetInt32(2);
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
            finally
            {
                //con.Close();
            }
            return lot;
        }

        /*********************************************************************************** Single param searches **/
        public List<Lot> GetLotsById(int id)
        {
            List<Lot> lots = new List<Lot>();   //tobeContinued
            return lots;
        }

        public List<Lot> GetLotsByName(string name)
        {
            List<Lot> lots = new List<Lot>();   //tobeContinued
            return lots;
        }

        public List<Lot> GetLotsByType(int type)
        {
            List<Lot> lots = new List<Lot>();   //tobeContinued
            return lots;
        }

        public List<Lot> GetLotsByExterior(Boolean exterior)
        {
            List<Lot> lots = new List<Lot>();   //tobeContinued
            return lots;
        }

        public List<Lot> GetLotsByPrice(decimal maxPrice)
        {
            List<Lot> lots = new List<Lot>();   //tobeContinued
            return lots;
        }
        /*********************************************************************************** Double param searches **/
        public List<Lot> GetLotsByTypeAndName(int type, string name)
        {
            List<Lot> lots = new List<Lot>();   //tobeContinued
            return lots;
        }

        public List<Lot> GetLotsByTypeAndPrice(int type, decimal price)
        {
            List<Lot> lots = new List<Lot>();   //tobeContinued
            return lots;
        }

        public List<Lot> GetLotsByTypeAndExterior(int type, Boolean exterior)
        {
            List<Lot> lots = new List<Lot>();   //tobeContinued
            return lots;
        }
    }
}