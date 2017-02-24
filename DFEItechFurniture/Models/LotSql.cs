using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DFEItechFurniture.Models
{
    public class LotSql: MySqlLink
    {
        public LotSql()
        {
            cmd.Connection = con;
            con.Open();
        }
        ~LotSql()
        {
            con.Close();
        }






    }
}