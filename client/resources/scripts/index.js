baseUrl = "https://localhost:5001/api/song";
var songList = []; 
var mySongList = {}; 


// function populateList(){
//     const allSongsApiUrl = baseUrl;
//     fetch(allSongsApiUrl).then(function(response){
//         return response.json();
//         }).then(function(json){
//             songList = json;
//             let html = `<select class="listBox" onLoad="handleOnLoad()" id="selectListBox" onClick="handleOnChange()" name="list_box" size=5 width="100%">"`;            
//             json.forEach((song)=>{
//                 html += "<option value= " + song.songId + ">" + "<h3>" + "<strong>Title: </strong>" + song.songTitle + "</h3>" + "</option>";
//             })
//             html+="</select>";
//             document.getElementById("listBox").innerHTML = html;
//         }) .catch(function(error){
//             console.log(error);
//         });
// }


function populateForm(){
    document.getElementById("songId").value = mySongList.songId;
    document.getElementById("songTitle").value = mySongList.songTitle; 
    document.getElementById("songTimestamp").value = mySongList.songTimestamp;
    document.getElementById("Deleted").value = mySongList.Deleted;
    document.getElementById("Favorite").value = mySongList.favorite;
}



function handleOnLoad(){
    //populateList();
    findSongs();
}



function handleOnChange(){
    const selectedId = document.getElementById("selectListBox").value
    songList.forEach((song)=>{
        if(song.id == selectedId){
            mySongList = song;
            populateForm(); 
        }
    })
}



function getList(){
    const allSongsApiUrl = baseUrl;
    fetch(allSongsApiUrl).then(function(response){
        return response.json();
    }).then(function(json){
        songList = json;
        populateList();
    }).catch(function(error){
        console.log(error);
    })
}



function postSong(){
    const postSongApiUrl = baseUrl; //error right here :)
    const sendSong = { 
        SongTitle: document.getElementById("songTitle").value,
    }
    fetch(postSongApiUrl, {
        method: "POST",
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json', 
        },
        body: JSON.stringify(sendSong)
    })
    .then((response)=>{
        mySongList = sendSong;
        populateForm; 
    })
    
}



function putSong(){
    const putSongApiUrl = baseUrl;
    const sendSong = {
        songId: document.getElementById("songId").value,
        songTitle: document.getElementById("songTitle").value,
        songTimestamp: document.getElementById("songTimestamp").value,
        Deleted: document.getElementById("Deleted").value,
        favorite: document.getElementById("Favorite").value, 
    }
    fetch(putSongApiUrl, { 
        method: "PUT",
        headers:{
            "Accept": 'application/json',
            "Content-Type": 'application/json',
        },
        body: JSON.stringify(sendSong)
    })
    .then((response=>{
        mySongList = sendSong;
        populateForm(); 
    }))
}



function deleteThisSong(){
    var thisTitle = document.getElementById("deleteSong").value
    const deleteSongApiUrl = baseUrl + "/" + thisTitle;
    fetch(deleteSongApiUrl, {
        method: "DELETE",
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json',
        }
    })
    .then((response)=>{
        //blankFields();
        findSongs();
    });
}

function favoriteThisSong(){
    var thisFavoriteTitle = document.getElementById("favoriteSong").value
    const favoriteSongApiUrl = baseUrl + "/" + thisFavoriteTitle;
    fetch(favoriteSongApiUrl, {
        method: "PUT",
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json',
        }
    })
    .then((response)=>{
        //blankFields();
        findSongs();
    });
}

function handleOnAdd(){
    var buttonHtml = "<button class=\"btn btn-dark\" onclick=\"handleOnAdd()\">Add Song</button>";
    document.getElementById("addButton").innerHTML = buttonHtml;
    postSong();
}

function findSongs(){
    var url = baseUrl;
    fetch(url).then(function(response) {
		console.log(response);
		return response.json();
	}).then(function(json) {
        console.log(json)
        let html = ``;
		json.forEach((song) => {
            if(song.favorite == `yes`)
            {
                console.log(song.favorite)
                html += `<div class="card col-md-4 bg-dark text-white">`;
                html += `<img src="./resources/images/music.jpeg" class="card-img" alt="...">`;
                html += `<div class="card-img-overlay">`;
                html += `<h5 class="card-title">`+song.songTitle+song.favorite+`</h5>`;
                html += `</div>`;
                html += `</div>`;
            }
            else
            {
                console.log(song.favorite)
                html += `<div class="card col-md-4 bg-dark text-white">`;
                html += `<img src="./resources/images/music.jpeg" class="card-img" alt="...">`;
                html += `<div class="card-img-overlay">`;
                html += `<h5 class="card-title">`+song.songTitle+` `+song.favorite+`</h5>`;
                html += `</div>`;
                html += `</div>`;
            }
		});
		
        if(html === ``){
            html = "No Songs found :("
        }
		document.getElementById("cards2").innerHTML = html;

	}).catch(function(error) {
		console.log(error);
	})
}



