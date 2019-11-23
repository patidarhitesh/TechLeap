// let stName: string;
// let age: number;
// let isCertified: boolean;
// let marks: number[] = [67, 78];
// let tuple: [number, string] = [101, "Noida"]; //to define heterogenous collection
// enum Grades {
//   A=15,
//   B=10,
//   C=20
// }
// age = 10;

// let data:any;
// data=10;
// data='delhi'
// console.log('data',data)
// console.log(`Name is ${stName}`);
// console.log(`Age is ${age}`);
// console.log(`Certified ${isCertified}`);
// console.log(marks);
// console.log(tuple[0]);
// console.log(Grades);
// console.log(Grades.A);
// console.log(Grades[0]);

let [num1, ...num2] = [10, 20];
console.log("num1", num1);
console.log(typeof num2);

let {id, name}= {'id':'101','name':'Nitin'}
console.log(`Id: ${id} Name: ${name}`);


// export {};
