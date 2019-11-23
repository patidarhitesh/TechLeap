// Create a list of fruits with their properties (name, color, pricePerKg)
// and convert it into a format so that for a given fruit name
// retrieval of its color and pricePerKg value is fast


// Write your code here

fruits = [
    {name: 'apple', color: 'magenta', price: 80},
    {name: 'Banana', color: 'yellow', price: 20},
    {name: 'orange', color: 'yellow', price: 35},
    {name: 'blackberry', color: 'white', price: 90},
    {name: 'dragonfruit', color: 'aqua', price: 40},
];

let n = [];
for (let i = 0; i < fruits.length; i++) {
    n[i]= fruits[i]['name'];
 
}
let t = [];
for (let i = 0; i < fruits.length; i++) {
         t[i] = {"color":`${fruits[i]['color']}`, "price": `${ fruits[i]['price']}`};
    }
var m = new Map();
for (let i = 0; i < fruits.length; i++) {
    m.set(n[i], t[i]);
}
console.log(m);


