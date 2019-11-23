// let repos = [];
// function fetchProjects(){
//     let httpRequest = new XMLHttpRequest();
//     httpRequest.onreadystatechange = ()=>{
//         if(httpRequest.readyState === XMLHttpRequest.DONE){
            
            
//             if(httpRequest.status === 200){
//                 repos = JSON.parse(httpRequest.responseText);
//                 repos.forEach(repo=>{
//                     let r = {url:repo.web_url, username: repo.owner, createdAt: Date(repo.created_at)}
//                     console.log(r);
//                 })
//             }
//         }
//     }
//     httpRequest.open('GET', 'https://gitlab-nht.stackroute.com/api/v4/projects?private_token=8S5s5mxWsHv4c1Dh5Zp');
//     httpRequest.send();
// }


let repos=[];
function fetchProjects(){
    let httpRequest=new XMLHttpRequest();
    httpRequest.onreadystatechange=()=>{
        if(httpRequest.readyState === XMLHttpRequest.DONE)
        {
            if(httpRequest.status === 200){
                repos=JSON.parse(httpRequest.responseText);
                repos.forEach(repo=>{
                    let r = {url :repo.web_url, createdAt: Date(repo.created_at)}
                    console.log(r);
                });
            }
        }
    }
    httpRequest.open('GET','https://gitlab-nht.stackroute.in/api/v4/projects?private_token=X4qFzxwPF6hcxxLaPqw8');
    httpRequest.send();
}