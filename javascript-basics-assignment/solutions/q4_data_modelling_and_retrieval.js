// Create a list of fruits with their properties (name, color, pricePerKg)
// and convert it into a format so that for a given fruit name
// retrieval of its color and pricePerKg value is fast


// Write your code here

let fruits = [
    {name: 'apple', color: 'magenta', price: 80},
    {name: 'Banana', color: 'yellow', price: 20},
    {name: 'orange', color: 'yellow', price: 35},
    {name: 'blackberry', color: 'white', price: 90},
    {name: 'dragonfruit', color: 'aqua', price: 40}
];
console.log("hello")
let n = [];
console.log(n);
for (let i = 0; i < fruits.length; i+1) {
    n[i]= fruits[i].name;
 
}
let t = [];
console.log(t);
for (let i = 0; i < fruits.length; i+1) {
         t[i] = {"color":`${fruits[i].color}`, "price": `${ fruits[i].price}`};
    }
let m = new Map();
for (let i = 0; i < fruits.length; i+1) {
    m.set(n[i], t[i]);
}
console.log(m);


