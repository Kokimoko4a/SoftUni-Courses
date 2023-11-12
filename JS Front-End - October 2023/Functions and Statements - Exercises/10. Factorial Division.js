function factorialDividing(number1, number2) {

    let factorial1 = factorial1Result(number1, 1);
    let factorial2 = factorial1Result(number2,1);
    console.log((factorial1 / factorial2).toFixed(2));

 

    function factorial1Result(number, res) {



        res *= number;
        number = number - 1;

        if (number > 1) {


           return factorial1Result(number, res);

        }

        else {
            return res;
        }



    }
}

factorialDividing(5, 2);