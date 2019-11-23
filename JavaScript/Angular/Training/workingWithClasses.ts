interface Employee {
  empId: number;
  empName: string;
  city: string;
}
function dispDetails(employee: Employee) {
  console.log(
    `ID:${employee.empId} Name:${employee.empName} City:${employee.city}`
  );
}
dispDetails({ empId: 222, empName: "Sachin", city: "Pune" });
// interface Employee{
//     empId:number
//     empName:string
//     city:string
//  }
//  function dispDetails(employee:Employee) {
//     console.log(`Id: ${employee.empId} ${employee.empName} ${employee.city}`);
//  }
//  dispDetails({empId:222, empName:'Shreya',city:'Bengaluru'});

class Course {
    price = 5000;
  constructor(
    public courseId: number,
    public courseName: string,
    public duration: number
  ) {
    this.courseId == courseId;
    this.courseName = courseName;
    this.duration = duration;
  }
  dispCourseInfo() {
    console.log(`${this.courseName} is of ${this.duration} weeks`);
  }
}

let course = new Course(301, 'Angular', 2);
course.dispCourseInfo();
console.log(course.price);

