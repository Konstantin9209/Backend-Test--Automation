import { sum } from './sum-numbers.js'
import { expect } from 'chai'
describe('The function sum', () => {
    it('should return 0 if an empty array is given', () => {
        const inputArray = [];

        const result = sum(inputArray)

        expect(result).to.equals(0)
    })
    
    it('should return the single element as a sum if a single element array is given', () => {
        const inputArray = [33];

        const result = sum(inputArray);

        expect(result).to.equals(33);
})

    
it('should return the total sum of an array if a multi value array is given', () => {
    const inputArray = [12, 3, 1];

    const result = sum(inputArray);

    expect(result).to.equals(16);
})
})
