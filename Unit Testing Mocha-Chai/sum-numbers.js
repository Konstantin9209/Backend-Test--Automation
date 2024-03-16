export function sum(arr) {
    let totalSum = 0; // Change the variable name to avoid conflict
    for (let num of arr) {
        totalSum += Number(num);
    }
    return totalSum;
}
