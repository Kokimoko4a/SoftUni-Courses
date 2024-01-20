function solve(array){

    let result = {};

    for (let index = 0; index < array.length; index+=2) {
        const element = array[index];
        

        result[element] = (Number)(array[index + 1]);
    }

    let f = " ";
    console.log(result)

}

solve(['Yoghurt', '48', 'Rise', '138', 'Apple', '52'])