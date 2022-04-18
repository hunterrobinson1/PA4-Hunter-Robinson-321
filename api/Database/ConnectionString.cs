using System; 
using MySql.Data.MySqlClient;
using MySql.Data;
using System.IO;
namespace PA4.Database
{
    public class ConnectionString
    {
        public string cs {get;set;}
        public ConnectionString()
        {
            string server = "pk1l4ihepirw9fob.cbetxkdyhwsb.us-east-1.rds.amazonaws.com";
            string database = "ui65go0pjfu3ngzk";
            string userName = "wfz2vc3j5mb3hym0"; 
            string password = "q8ugdij9tjx68ffy"; 

            cs = $"server={server};database={database};uid={userName};pwd={password};"; 
           
        } 
    }
}