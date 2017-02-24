using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DFEItechFurniture.Models
{
    public class TypeSql: MySqlLink
    {
        public TypeSql()
        {
            cmd.Connection = con;
            con.Open();
        }
        ~TypeSql()
        {
            con.Close();
        }
    }
}