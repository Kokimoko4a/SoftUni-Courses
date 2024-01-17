function solve(array) {
    if (array.length === 0) {
        return [];
    }

    let output = [array[0]];

    for (let index = 1; index < array.length; index++) {
        const element = array[index];

        if (element > output[output.length - 1]) {
            output.push(element);
        }
    }

    return output;

}
console.log(solve([1, 
    3, 
    8, 
    4, 
    10, 
    12, 
    3, 
    2, 
    24]
    
    ));