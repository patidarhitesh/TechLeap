// /* function can be defined in 2 ways
// 1. function declaration
// 2. function Expression

// 1. this one is hoisted
// function displayDetails(){
//     ... ;
//     ...;
//     ...;
//     return ... ;

// 2. this one is not hoisted
// let sum()=function(){....};

// }*/
// let square= n => n*n;
// let add = (n1,n2) => {
//     console.log(`sum is ${n1+n2}`);
// }
// add(5,7)
// console.log(square(12));



//CLOSURE
//inner function
//retains the acces to its outer variables

// function outer(){
//     let x=10;
//     function inner(){
//         x++;
//         return x;
//     }
//     return inner();
// }

// console.log(outer());

// let x=10;
// function outer(){
//     return function(){
//         x++;
//         return x;
//     }
// }
// console.log(outer()());
// console.log(outer()());

// let result= [];
// for (var i = 0; i < 5; i++) {//using let will yield output 1
//     result.push(function() {return i});
    
// }
// console.log(result[1]());


//Object.assign() -> makes a copy of the object.