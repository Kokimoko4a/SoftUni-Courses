//TODO:Add me to new folder please

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
        console.log("Yes");
    }

    else{
        console.log("NO");
    }
}

isNumberPerfect(123456789);