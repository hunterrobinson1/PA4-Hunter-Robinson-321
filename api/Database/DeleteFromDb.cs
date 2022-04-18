using System; 
using System.IO;
using MySql.Data.MySqlClient;
using PA4.Models; 

namespace PA4.Database
{
    public class DeleteFromDb
    {
        public static void Delete(string title)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs; 
            using var con = new MySqlConnection(cs);
            con.Open();
                
            string stm = @"UPDATE songs SET Deleted = 'yes' WHERE SongTitle = @title"; 
            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@title", title);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            
        }
    }
}