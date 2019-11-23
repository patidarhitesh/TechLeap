function dispDetails(employee) {
  console.log(
    "ID:" +
      employee.empId +
      " Name:" +
      employee.empName +
      " City:" +
      employee.city
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
var Course = /** @class */ (function() {
  function Course(courseId, courseName, duration) {
    this.courseId = courseId;
    this.courseName = courseName;
    this.duration = duration;
    this.price = 5000;
    this.courseId == courseId;
    this.courseName = courseName;
    this.duration = duration;
  }
  Course.prototype.dispCourseInfo = function() {
    console.log(this.courseName + " is of " + this.duration + " weeks");
  };
  return Course;
})();
var course = new Course(301, "Angular", 2);
course.dispCourseInfo();
console.log(course.price);
