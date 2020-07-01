const { expect } = require("chai");

class StringBuilder {
    constructor(string) {
        if (string !== undefined) {
            StringBuilder._vrfyParam(string);
            this._stringArray = Array.from(string);
        } else {
            this._stringArray = [];
        }
    }
    append(string) {
        StringBuilder._vrfyParam(string);
        for (let i = 0; i < string.length; i++) {
            this._stringArray.push(string[i]);
        }
    }
    prepend(string) {
        StringBuilder._vrfyParam(string);
        for (let i = string.length - 1; i >= 0; i--) {
            this._stringArray.unshift(string[i]);
        }
    }
    insertAt(string, startIndex) {
        StringBuilder._vrfyParam(string);
        this._stringArray.splice(startIndex, 0, ...string);
    }
    remove(startIndex, length) {
        this._stringArray.splice(startIndex, length);
    }
    static _vrfyParam(param) {
        if (typeof param !== 'string') throw new TypeError('Argument must be string');
    }
    toString() {
        return this._stringArray.join('');
    }
}

describe('StringBuilder', function() {
    const errorMessage = 'Function did not return the correct result!';
    const instance = new StringBuilder();
    describe('constructor', function() {
        it('should be initiliazed when string param is given', function() {
            let input = 's';
            expect(new StringBuilder(input)._stringArray).to.eq(input.split(''), errorMessage);
        });

        it('should be initiliazed with empty ctor', function() {
            expect(instance._stringArray).to.eq([], errorMessage);
        });
    });

    describe('append', function() {
        it('should append characters at the end of the array', function() {
            instance.append('123');
            expect(instance._stringArray.slice(instance._stringArray.length - 3, instance._stringArray.length).join('')).to.eq('123', errorMessage);
        });
    });

    describe('prepend', function() {
        it('should append characters at the beggining of the array', function() {
            instance.prepend('123');
            expect(instance._stringArray.slice(0, 3).join('')).to.eq('123', errorMessage);
        });
    });

    describe('insertAt', function() {
        it('should insert character at position', function() {
            instance.insertAt('a', 2);
            expect(instance._stringArray.join('').charAt(2)).to.eq('a', errorMessage);
        });
    });

    describe('remove', function() {
        it('should remove characters from specified range', function() {
            instance._stringArray = ['2', '1'];
            instance.remove(0, 1);
            expect(instance._stringArray.join('')).to.eq('1', errorMessage);
        });
    });

    describe('toString', function() {
        it('should succesfuly join the array', function() {
            instance._stringArray = ['1'];
            expect(instance._stringArray.toString()).to.eq(instance._stringArray.join(''), errorMessage);
        });
    });

    describe('_vrfyParam', function() {
        it('should throw an error if param is a number', function() {
            expect(StringBuilder._vrfyParam(1)).throws(new TypeError('Argument must be string'), errorMessage);
        });

        it('should throw an error if param is an object', function() {
            expect(StringBuilder._vrfyParam({ obj: 'obj' })).throws(new TypeError('Argument must be string'), errorMessage);
        });
    });
});