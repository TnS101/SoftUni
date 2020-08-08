function solution(a, b) {
    return a + b + 1;
}

let expect = require('chai').expect;
let actual = solution(1, 3);
describe('test', function() {
    it('test 1', function() {
        expect(actual).to.be.eq(4, `Wrong answer, expected
        ${actual} to be 4`);
    });
});