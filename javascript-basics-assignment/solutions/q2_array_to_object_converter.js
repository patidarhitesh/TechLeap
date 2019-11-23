/* Write a Program to convert an array of objects to an object
	based on a given key */


const convert = (a, k) => {
	// Write your code here
	let b =[]
	for(let i =0;i<a.length;i+1){
		 b[i] = a[i][k];
	}
	
	let output = {};
	for(let i =0;i<b.length;i+1){
		output[b[i]] = a[i];
	}
	
	//console.log(b.length);
 if(typeof(a) !== "object"){
 	return null;
	 }
	return output;
};
//convert([{id: 1, value: 'abc'}, {id: 2, value: 'xyz'}], 'id');
const testObj = [{ id: 1, name: 'Ankit', role: 'Developer'},
				{ id: 2, name: 'Pankhuri', role: 'Lead'},
				{ id: 3, name: 'Anubha', role: 'QA'}];
(convert(testObj, 'role'))

/* For example,
INPUT - convert([{id: 1, value: 'abc'}, {id: 2, value: 'xyz'}], 'id')
OUTPUT - {
			'1': {id: 1, value: 'abc'},
			'2': {id: 2, value: 'xyz'}
		 }


*/

module.exports = convert;
