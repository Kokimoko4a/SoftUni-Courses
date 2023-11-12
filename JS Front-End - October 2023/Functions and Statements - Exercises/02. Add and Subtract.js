function solve(num1,num2,num3){

    let sum =  add(num1,num2);
    let result = subtract(sum,num3);

    console.log(result);

    function add(num1,num2){
        return num1 + num2;
    }

    function subtract(sum, num3){
        return sum-num3;
    }
}

