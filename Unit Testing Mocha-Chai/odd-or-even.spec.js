import { describe, it } from "mocha";
import { expect } from 'chai';
import { isOddOrEven } from "./odd-or-even.js";

describe("odd-or-even", () => {
    it("should return undefined when passed a non-string value as input", () => {
        const inputValueNumber = 15;
        const inputValueUndefined = undefined;
        const inputValueNull = null;
        const inputValueFloatNumber = 10.10;

        const resultNumber = isOddOrEven(inputValueNumber);
        const resultUndefined = isOddOrEven(inputValueUndefined);
        const resultNull = isOddOrEven(inputValueNull);
        const resultFloatNumber = isOddOrEven(inputValueFloatNumber);

        expect(resultNumber).to.be.undefined;
        expect(resultUndefined).to.be.undefined;
        expect(resultNull).to.be.undefined;
        expect(resultFloatNumber).to.be.undefined;
    });

    it("should return even when input string length is even", () => {

        const evenStringLength = "1234";
        const resultEvenStringLength = isOddOrEven(evenStringLength);
        expect(resultEvenStringLength).to.be.equal('even');
});

it("should return odd when input string length is odd", () => {

    const oddStringLength = "123";
    const resultOddStringLength = isOddOrEven(oddStringLength);
    expect(resultOddStringLength).to.be.equal('odd');
});

it("should return even when input string length is 0", () => {

    const zeroLengthString = "";
    const resultzeroLengthString = isOddOrEven(zeroLengthString);
    expect(resultzeroLengthString).to.be.equal('even');
});
});
