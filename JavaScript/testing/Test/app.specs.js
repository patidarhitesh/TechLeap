const assert = require("chai").assert;
const expect = require("chai").expect;
const st = require("../student");

describe("Test case using Mocha and Chai", () => {
  describe.skip("Simple testing with primitive types", () => {
    it("Num must be equal to 10", done => {
      let num = 10;
      assert.equal(num, 10);
      done();
    });
    it("Num should not be undefines", done => {
      let num;
      assert.isUndefined(num);
      assert.isTrue(num === undefined);
      done();
    });
    it("Num should a number", done => {
      let num = 10;
      assert.typeOf(num, "Number");
      done();
    });
  });
  describe.skip("Testing array using Chai and Mocha", () => {
    it("Both arrays should be equivalent", done => {
      let arr1 = [1, 2, 3];
      let arr2 = [1, 2, 3];
      assert.deepEqual(arr1, arr2);
      done();
    });
    it("Both array content should be equivalent", done => {
      let arr1 = [1, 2, 3];
      let arr2 = [2, 1, 3];
      assert.includeMembers(arr1, arr2);
      done();
    });
    it("Both array content should have same members in same sequence", done => {
      let arr1 = [1, 2, 3];
      let arr2 = [1, 2, 3];
      expect(arr1).to.eql(arr2);
      done();
    });
    it("Student object must contain course property", done => {
      let student = { id: 101, name: "Palash", course: "FSE" };
      expect(student).to.have.property("course"); //single property
      expect(student).to.have.keys(["id", "name", "course"]); //all properties
      expect(student).to.contain.keys("id", "name"); //some properties
      done();
    });
  });
  describe("Test cases for student object", () => {
    it("despDetains should return a string with id and name", done => {
      let st1 = new st(101, "Manish");
      expect(st1.dispDetails()).equals("Student id:101, Name:Manish");
      done();
    });
  });
});
