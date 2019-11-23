


function fetch(){

    let array = Object.entries(localStorage);
    for( let k in array){
        let id = array[k][0];
        let description =array[k][1];
        let n = document.getElementById("notes");
        let p = document.createElement("div");
        let hash = Math.round((Math.pow(36, 10 + 1) - Math.random() * Math.pow(36, 10))).toString(36).slice(1);
    
        console.log(hash);
        p.setAttribute("id", `p`);
        p.setAttribute("class", 'class="col-6 text-center p-5"')
        p.innerHTML =  ` 
        <div class="card card-body p-5 m-5 rounded" >
        <div><h4>${id}</h4></div>
        <div>${description}</div>
        <button class="btn btn-dark" onclick='delNote("${id}")' >Delete Note</button></div>
         `;
        
        n.appendChild(p);
        
    }
}



function update(){
    let id = document.getElementById('noteTitle').value;
    console.log(id);
    let description = document.getElementById('noteText').value;
    let n = document.getElementById("notes");
    let p = document.createElement("div");
    let array = Object.entries(localStorage);
   
      
    p.setAttribute("class", 'class="col-6 text-center p-5"')
    
    
    p.innerHTML =  ` 
        <div class="card card-body p-5 m-5 rounded" >
        <div><h4>${id}</h4></div>
        <div>${description}</div>
        <button class="btn btn-dark" onclick='delNote("${id}")' >Delete Note</button></div>
         `;
    n.appendChild(p);
}

function addNote(){
    let id = document.getElementById('noteTitle').value;
    let description = document.getElementById('noteText').value;
    
    localStorage.setItem(id, description);
    
    update();
}
    
    


function delNote(i){
    console.log(i);
    localStorage.removeItem(i);
    let n = document.getElementById("notes");
    n.innerHTML = "";
    fetch();
   
}