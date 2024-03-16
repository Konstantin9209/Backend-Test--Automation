import { createCalculator } from './add-subtract.js';
import { expect } from 'chai';

describe('createCalculator', () => {
    it('should return an object with add, subtract, and get functions', () => {
        const calculator = createCalculator();
        expect(calculator).to.be.an('object');
        expect(calculator).to.have.property('add').that.is.a('function');
        expect(calculator).to.have.property('subtract').that.is.a('function');
        expect(calculator).to.have.property('get').that.is.a('function');
    });

    it('should return the correct sum after adding and subtracting numbers', () => {
        const calculator = createCalculator();
        calculator.add(5);
        calculator.subtract(2);
        calculator.add('3');
        const result = calculator.get();
        expect(result).to.equal(6);
    });

    it('should handle string inputs that can be parsed as numbers', () => {
        const calculator = createCalculator();
        calculator.add('10');
        calculator.subtract('5');
        const result = calculator.get();
        expect(result).to.equal(5);
    });

    it('should not allow modification of the internal sum from outside', () => {
        const calculator = createCalculator();
        calculator.add(7);
        const internalSum = calculator.get();
        calculator.subtract(3);
        const modifiedSum = calculator.get();
        expect(internalSum).to.equal(7);
        expect(modifiedSum).to.equal(4);
    });
});
