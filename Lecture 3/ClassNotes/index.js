console.log(new Date());

console.log(Date())

console.log(new Date().getTime());

//momemnt.js suggested


// Region specific
const date = new Date();
console.log(new Intl.DateTimeFormat('en-US').format(date));