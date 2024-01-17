function solve(array, timesToRotate) {

    for (let index = 0; index < timesToRotate; index++) {

        let element = array[array.length - 1];

        array.pop();
        array.unshift(element);
    }

    console.log(array.join(" "));
}

solve(['Banana', 
'Orange', 
'Coconut', 
'Apple'], 
15

);