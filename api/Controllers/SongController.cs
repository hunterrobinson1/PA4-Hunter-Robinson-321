using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PA4.Models;
using PA4.Database;
using Microsoft.AspNetCore.Cors;

namespace PA4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongController : ControllerBase
    {
        // GET: api/Song
        [EnableCors("AnotherPolicy")]
        [HttpGet]
        public List<Song> Get()
        {
            return ReadFromDb.ShowAllSongs();
        }

        
        [EnableCors("AnotherPolicy")]
        [HttpGet("{id}", Name = "Get")]
        public Song Get(int id)
        {
            return new Song();

        }

        
        [EnableCors("AnotherPolicy")]
        [HttpPost]
        public void Post([FromBody] Song newSong)
        {
            Song hunterSong = new Song(newSong.SongTitle); 
            AddSongDB.AddASongDb(hunterSong);
        }

       
        [EnableCors("AnotherPolicy")]
        [HttpPut("{title}")]
        public void Put(string title)
        {
            EditSongDb.EditSongFromDb(title);
        }

       
        [EnableCors("AnotherPolicy")]
        [HttpDelete("{title}")]
        public void Delete(string title)
        {
            DeleteFromDb.Delete(title);
        }
    }
}