function solve(inputArray, numberOfRotations){
    'use strict';

    for(let index = 0; index < numberOfRotations; index++){
        const firstElement = inputArray.shift()
        inputArray.push(firstElement)
    }
    console.log(inputArray.join(' '))
}
solve([51, 47, 32, 61, 21], 2)