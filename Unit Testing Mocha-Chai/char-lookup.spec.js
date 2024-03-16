import { lookupChar } from "./char-lookup.js";
import {expect} from 'chai';

describe("lookUpChar", () => {

    it ("should return undefined index when First parameter is from incorrect and second parameter is correct type", ()=>{
    const incorrectFirstParam = 123;
    const correctSecondParam = 1;

    const undefinedResult = lookupChar(incorrectFirstParam, correctSecondParam);

    expect(undefinedResult).to.be.undefined;

    })
    it ("should return undefined index when First parameter is from correct and second parameter is incorrect type", ()=>{
        const correctFirstParam = "some string here";
        const incorrectSecondParam = "10";
    
        const undefinedResult = lookupChar(correctFirstParam, incorrectSecondParam);
    
        expect(undefinedResult).to.be.undefined;
    
        })
        it ("should return undefined index when First parameter is from correct and second parameter is incorrect float type", ()=>{
            const correctFirstParam = "some string here";
            const incorrectFloatNumberParam = 10.10;
        
            const undefinedResult = lookupChar(correctFirstParam, incorrectFloatNumberParam);
        
            expect(undefinedResult).to.be.undefined;
        
            })
            it ("should return incorrect index when First parameter is from correct and second parameter is bigger than the string length", ()=>{
                const correctFirstParam = "some string here";
                const biggerLengthSecondParam = 20;
            
                const incorrectIndexResult = lookupChar(correctFirstParam, biggerLengthSecondParam);
            
                expect(incorrectIndexResult).to.be.equal("Incorrect index");
            
                }) 
                it ("should return incorrect index when First parameter is from correct and second parameter is lower than the string length", ()=>{
                    const correctFirstParam = "some string here";
                    const lowerLengthSecondParam = -20;
                
                    const incorrectIndexResult = lookupChar(correctFirstParam, lowerLengthSecondParam);
                
                    expect(incorrectIndexResult).to.be.equal("Incorrect index");
                
                    }) 
                    it ("should return correct wehn all the parameters are correct", ()=>{
                        const correctFirstParam = "some string here";
                        const correctSecondParam = 1;
                    
                        const correctResult = lookupChar(correctFirstParam, correctSecondParam);
                    
                        expect(correctResult).to.be.equal("o");
                    
                        }) 
    })


