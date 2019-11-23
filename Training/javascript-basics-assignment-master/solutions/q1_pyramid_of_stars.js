/* Write a program to build a `Pyramid of stars` of given height */

const buildPyramid = (n) => {
     // Write your code here
     
     var output="";
     for (var i = 1; i <= n; i++) {
          for (var j = i; j <= n; j++) {
               output+=" ";
               }
          for (var j = 1; j <= i; j++) {
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
