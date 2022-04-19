using System;
using System.IO; 
namespace PA4.Models
{
    public class Song: IComparable<Song>
    {
        // auto implemented properties
        public int SongID {get; set;}
        public string SongTitle {get; set;}
        public DateTime SongTimestamp {get; set;}
        public string Deleted { get; set; }

        public string Favorite {get; set;}

        public override string ToString() 
        {
            return SongTitle + " (ID: " + SongID + ", Added " + SongTimestamp + ")";
        }

        public string ToFile(){
            return SongID + "#" + SongTitle + "#" + SongTimestamp + "#" + Deleted + "#" + Favorite ;
        }

        public int CompareTo(Song temp) { 
            return -this.SongTimestamp.CompareTo(temp.SongTimestamp); 
        }

        public Song()
        {

        }
        public Song(string title)
        {
            SongTitle = title;
            SongTimestamp = DateTime.Now;
            Deleted = "no"; 
            Favorite = "no";
        }
    }
}