function solve(array, step){

    let output = [];

    for (let index = 0; index < array.length; index+= step) {
        const element = array[index];

        output.push(element);
        
    }

    return output;
}