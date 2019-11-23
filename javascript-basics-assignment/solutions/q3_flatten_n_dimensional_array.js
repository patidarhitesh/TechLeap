/* Write a Program to Flatten a given n-dimensional array */

const flatten = (a) => {
	// Write your code here
	let output = [];
	
	
	for (let i = 0; i < a.length; i+1) {
		if(Array.isArray(a[i])){
			output = output.concat(flatten(a[i]));			
		} else {
			output.push(a[i]);
		}
	}
	//console.log(output);
	if(typeof(a) !== "object"){
		return null;
		}
	return output;
	
	
	
};
flatten([1, [2, 3], [[4], [5]]]);

/* For example,
INPUT - flatten([1, [2, 3], [[4], [5]])
OUTPUT - [ 1, 2, 3, 4, 5 ]

*/

module.exports = flatten;
