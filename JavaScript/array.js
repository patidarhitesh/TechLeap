// let cities = ['noida', 'delhi','Indore' ];

// // let i=0;
// // while(i<=cities.length){
// //     console.log(cities[i]);
// //     i++;
// // }

// // cities.push('Mumbai');

// // for (let index = 0; index < cities.length; index++) {
// //     console.log(cities[index]);

// // }

// // let elem = cities.pop();
// // console.log(`last element was ${elem}`);
// // console.log(`curent length ${cities.length}`);
// // let firstelem = cities.shift();
// // console.log(`first element was ${firstelem}`);
// // console.log(`curent length ${cities.length}`);

// // cities.unshift('Chennai','Gurgaon','Ahmendabad');
// // console.log(cities);

// // cities.forEach((item,index)=>{
// //     console.log(`iten at position ${index} is ${item}`);
// // });
// // cities.push('Indore');
// // console.log(cities);
// // cities.forEach((item,index,cities)=>{
// //     if(item == cities[index+1]){
// //         cities.splice(index,1);
// //         //console.log(`iten at position ${index} is ${item}`);
// //     }
// // });
// // console.log(cities);

// // 'use strict';//should be at the top of the script
// // function f(){
// //     color = 'blue';

// // }
// // f();
// // console.log(color);

// for(city in cities){
//     console.log(cities[city]);
// }





//MAP
var first = new Map([
    [1, 'one'],
    [2, 'two'],
    [3, 'three'],
  ]);
  
  var second = new Map([
    [1, 'uno'],
    [2, 'dos']
  ]);
  
  // Merge two maps. The last repeated key wins.
  // Spread operator essentially converts a Map to an Array
  var merged = new Map([...first, ...second]);
  
  console.log(merged.get(1)); // uno
  console.log(merged.get(2)); // dos
  console.log(merged.get(3)); // three