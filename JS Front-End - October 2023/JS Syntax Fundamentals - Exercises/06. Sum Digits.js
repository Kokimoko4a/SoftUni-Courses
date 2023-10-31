function solve(input) {

    let sum = 0
    let numberAsString = String(input);

    for (let i=0; i < numberAsString.length; i++) {
        sum += Number(numberAsString[i]);
    }


    console.log(sum);
}
