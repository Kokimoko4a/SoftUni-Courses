function solve(array) {
    array.sort((a, b) => a - b);
    let output = [];

    while (array.length > 0) {
        const elementSmallest = array.shift();
        const elementBiggest = array.pop();

        output.push(elementSmallest);
        if (elementBiggest !== undefined) {
            output.push(elementBiggest);
        }
    }

    return output;
}

console.log(solve([22, 9, 63, 3, 2, 19, 54, 11, 21, 18]));