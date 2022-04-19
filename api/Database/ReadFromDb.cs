using System; 
using System.IO;
using MySql.Data.MySqlClient;
using PA4.Models;
using System.Collections.Generic;

namespace PA4.Database
{
    public class ReadFromDb //shows all songs
    {
        public static List<Song> ShowAllSongs()
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs; 
            using var con = new MySqlConnection(cs);
            con.Open();
            
            string stm = "SELECT * FROM songs WHERE Deleted = 'no' ";
            using var cmd = new MySqlCommand(stm, con);
            using MySqlDataReader rdr = cmd.ExecuteReader();

            List<Song>songList = new List<Song>(); 
            while(rdr.Read())
            {
                Song tempSong = new Song(){
                    SongID = rdr.GetInt32(0),
                    SongTitle = rdr.GetString(1),
                    SongTimestamp = rdr.GetDateTime(2),
                    Deleted = rdr.GetString(3),
                    Favorite = rdr.GetString(4),
                };
                songList.Add(tempSong);
            }
            return songList; 

        }
    }
}