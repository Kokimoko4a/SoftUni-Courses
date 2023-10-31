function solve(number1, number2)
{
    let sum = 0;
    let numbers = "";


    for(let i =number1; i<=number2; i++)
    {
        sum+=i;

        numbers+=i + " ";
    }

    console.log(numbers);
    console.log(`Sum: ${sum}`);
}

