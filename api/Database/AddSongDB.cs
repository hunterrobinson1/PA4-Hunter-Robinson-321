using System; 
using System.IO;
using MySql.Data.MySqlClient;
using PA4.Models; 

namespace PA4.Database
{
    public class AddSongDB
    {
        public static void AddASongDb(Song mysong)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs; 
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"INSERT INTO songs(ID, SongTitle, SongTimestamp, Deleted, Favorite) VALUES(@SongID, @SongTitle, @SongTimestamp, 'no', 'no' )"; 
            using var cmd = new MySqlCommand(stm,con); 
            cmd.Parameters.AddWithValue("@SongID", mysong.SongID);
            cmd.Parameters.AddWithValue("@SongTitle", mysong.SongTitle);
            cmd.Parameters.AddWithValue("@SongTimestamp", mysong.SongTimestamp);
            cmd.Parameters.AddWithValue("@Favorite", "no");
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            
        }
        
    }
}