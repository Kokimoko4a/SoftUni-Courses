function solve(input) {

    let flag = true;
    let output = "";
    let sum = 0
    let numberAsString = String(input);

    for (let i = 0; i < numberAsString.length; i++) {

        sum += Number(numberAsString[i]);

        for (let k = 0; k < numberAsString.length; k++) {


            if (numberAsString[k] != numberAsString[i]) {
                output = "false";
        
                flag = false;
            }


        }
    }

    if (flag) {
        console.log(flag);
    }

    else{
        console.log(output);
    }

    console.log(sum);
}

