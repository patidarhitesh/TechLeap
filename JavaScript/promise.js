let students=[];
for (let i = 0; i < 100; i++) {
    let student = {studentID: i+1, studentName: `student-${i+1}`};
    students.push(student);    
}

function searchStudent(id){
    let studentPromise = new Promise((resolve, reject)=>{
        let _student = students.find(student=>
           student.studentID === id 
        );
        if(_student != undefined){
            resolve(_student);
        } else {
            reject(new Error('This student id not found.'));
        }
    });
    return studentPromise;
}

function search(id){
    searchStudent(id).then(result=>{
        console.log(result);
    }).catch(err=>{
        console.log(err);
    });
}

search(45);