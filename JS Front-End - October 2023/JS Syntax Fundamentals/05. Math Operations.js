function calculate(number1,number2,operator)
{
    if(operator == "+"){
        console.log(number1 + number2);
    }

   else if(operator == "-"){
        console.log(number1 - number2);
    }

    else if(operator == "*"){
        console.log(number1 * number2);
    }

    else if(operator == "/"){
        console.log(number1 / number2);
    }

    else if(operator == "**"){
        console.log(number1 ** number2);
    }

    else if(operator == '%')
    {
        console.log(number1%number2);
    }
}