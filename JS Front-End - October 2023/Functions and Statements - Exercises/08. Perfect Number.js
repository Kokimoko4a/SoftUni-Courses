
function isNumberPerfect(number) {
    let divisors = [];
    let sum = 0;

    for (let i = 1; i < number; i++) {

        if (number % i === 0) {
            divisors.push(i);
            sum+=i;
        }

    }

    if(number === sum)
    {
        console.log("We have a perfect number!");
    }

    else{
        console.log( "It's not so perfect.");
    }
}

