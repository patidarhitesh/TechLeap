let student = function(id, name) {
  this.id = id;
  this.name = name;
};

student.prototype.dispDetails = function() {
  return `Student id:${this.id}, Name:${this.name}`;
};

module.exports = student;
