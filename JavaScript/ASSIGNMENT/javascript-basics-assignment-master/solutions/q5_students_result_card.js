// Write a program to display one result card of 100 students
// with their name and percentage
// Out of 100 students, 50 has subjects - Grammer and Accounts
// and other 50 has subjects -  Grammer and Physics

// Hint : You need to calculate percentage of 100 students having different set of subjects.
//        You can assume their scores on their respective subjects.


// Write your code here

class Student{
    constructor(name, scorecard, subject){
        this.name = name;
        this.subject = subject;
        this.scorecard = scorecard;
        this.percentage = function(){
            let per = (scorecard[0] + scorecard[1])/2;
            return per.toFixed(2);
        }
    }

}
// let student1 = new Student('raj', [80,70]);
// console.log(student1.percentage());

list = [];
for (let i = 0; i < 50; i++) {
    list[i] =  new Student('student'+i, [Math.random()*100, Math.random()*100],['Grammer', 'Accounts']);
}

for (let i = 50; i < 100; i++) {
    list[i] =  new Student('student'+i, [Math.random()*100, Math.random()*100],['Grammer', 'Physics']);
}

for (let i = 0; i < 100; i++) {
    console.log(list[i].name+ " : " +list[i].percentage() + " (Subjects : " + list[i].subject[0] + " and " + list[i].subject[1] + ")");
    
}
