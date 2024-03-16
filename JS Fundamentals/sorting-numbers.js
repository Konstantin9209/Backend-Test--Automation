function solve(inputArray){
'use strict';

inputArray.sort((a, b) => a - b)

const result = [];

while(inputArray.length > 0){
    const firstElement = inputArray.shift()
    const lastElement = inputArray.pop()

    result.push(firstElement)
    if (lastElement){
        result.push(lastElement)
    }
}

return result
}