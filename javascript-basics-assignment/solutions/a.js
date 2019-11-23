// const a = [10, 12, 15, 21];
// for (let i = 0; i < a.length; i++) {
//   setTimeout(function() {

//     console.log('Index-' + i + ', element-' + a[i]);
//     setTimeout(function() {
        
//             console.log('Index-' + i + ', element-' + a[i]);
        
//     },2000)
//   }, 3000);
// }

function f1(a){

    function f2(b){
        // function f3(c){
        //     return function f4(d) {
        //         return a+b+c+d
        //     }
        // }
        return a+b;
    }
    return f2;
}
   let obj=new f1(10)

console.log(obj(5))




