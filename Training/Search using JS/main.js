let names = ['akash', 'maliha', 'shreya', 'palash', 'karthik', 'krishna', 'hriday', 'karandeep', 'astha', 'shivangi', 'kundan', 'aman'];
console.log(names);

function search(){

    let n = document.getElementById("h").value;
console.log(n);
  if (names.includes(n)){

    document.getElementById("res").innerHTML=n.toUpperCase();
  }
  else{
    document.getElementById("res").innerHTML="<div style = 'color:red'>Error</div>"
  }


}
