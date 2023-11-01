function solve(number, operation1, operation2, operation3, operation4, operation5) {
    let operations = [operation1, operation2, operation3, operation4, operation5];


    number = parseInt(number);

    

    for (let i = 0; i < 5; i++) {

        let currOperation = operations[i];

        if (currOperation == "chop") {

            number /= 2;
        }

        else if (currOperation == "dice") {
            number = Math.sqrt(number);
        }

        else if (currOperation == "bake") {
            number *= 3;
        }

        else if (currOperation == "fillet") {
            number -= 0.2 * number;
        }

        else if (currOperation == "spice") {
            number += 1;
        }

        console.log(number);


    }

    
}

