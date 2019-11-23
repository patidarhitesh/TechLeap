// function student(){
//     this.name = "hitesh";
// }
// let st1 = new student();
// st1.name = 'shreya';
// console.log(st1.name);


// class student {
//     constructor(studentId, studentName) {
//         this.studentId = studentId;
//         this.studentName = studentName;
//         this.displaydetails = function () {
//             console.log(`Student Id : ${this.studentId}, Name : ${this.studentName}`);
//         };
//     }
// }

// let student1 = new student(101, 'sachin');
// student1.displaydetails();
// let student2 = new student(102, 'sehwag');
// student2.displaydetails();

// let student1 = new student(101, 'sachin');
// student1.city = 'delhi';
// let student2 = new student(102, 'sehwag');
// student2.displaydetails();
// console.log(student1.city);

// student.prototype.stream = 'it'

class Employee{
    constructor(empID, empName, address){
        this.empID = empID;
        this.empName = empName;
        this.address = address;

    }
    displayDetails(){
        console.log(`Emp id: ${this.empID}, Name: ${this.empName}, Address: ${this.address}`);
    }
}
Employee.prototype.contact = '011-4123245';
let emp1 = new Employee(111, 'nilesh', 'pune');
emp1.displayDetails();
console.log(emp1);
console.log(emp1.contact);

