function sumOddEven(number){

    let numberAsString =  number.toString();
    let sumEven = 0;
    let sumOdd = 0;

    for(let i = 0; i<numberAsString.length; i++){

        let curr = parseInt(numberAsString[i]);

        if(curr % 2 == 0){
            sumEven+=curr;
        }

        else{
            sumOdd += curr;
        }
    }

    console.log(`Odd sum = ${sumOdd}, Even sum = ${sumEven}`)
}

