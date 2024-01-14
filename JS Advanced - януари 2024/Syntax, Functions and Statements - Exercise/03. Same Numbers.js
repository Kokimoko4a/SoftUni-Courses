function solve(number) {

    number = number.toString();
    let flag = true;
    let array = Array.from(number);
    let sum = 0;

    sum += parseInt(array[0]);

    for (let index = 1; index < array.length; index++) {
        const element = array[index];

        if (element !== array[index - 1]) {


            flag = false;

        }

        sum += parseInt(element);

    }

    if (flag === true) {

        console.log(true);
    }

    else {

        console.log(false)
    }

    console.log(sum);


}

solve(2222222);