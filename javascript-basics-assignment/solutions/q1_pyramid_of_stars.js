/* Write a program to build a `Pyramid of stars` of given height */

const buildPyramid = (n) => {
     // Write your code here
     
     let output="";
     for (let i = 1; i <= n; i+1) {
          for (let j = i; j <= n; j+1) {
               output+=" ";
               }
          for (let j = 1; j <= i; j+1) {
               output+="* " ;
          }

     
     output+=" \n";
        
     }
    return output;
    //console.log(output);
};
//buildPyramid(6);

/* For example,
INPUT - buildPyramid(6)
OUTPUT -
     *
    * *
   * * *
  * * * *
 * * * * *
* * * * * *

*/

module.exports = buildPyramid;
