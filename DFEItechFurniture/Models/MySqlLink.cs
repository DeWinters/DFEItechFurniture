using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace DFEItechFurniture.Models
{
    public abstract class MySqlLink
    {
        protected MySqlCommand cmd = new MySqlCommand();
        protected MySqlConnection con = new MySqlConnection(@"Server=localhost;Port=3306;database=furniture;Uid=root;password=secret");
        protected MySqlDataReader rdr;
    }
}