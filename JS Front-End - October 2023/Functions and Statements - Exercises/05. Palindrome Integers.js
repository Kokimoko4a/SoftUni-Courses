function checkIfIsPalindrome(numbers){

    for(let i = 0; i < numbers.length; i++){

        let isPalindrome = checkIt(numbers[i]);
        console.log(isPalindrome);
    }

    function checkIt(number){
        let numberAsString = number.toString();

        let reversedNum = "";

        for (let index = numberAsString.length-1; index >= 0; index--) {
            reversedNum  += numberAsString[index];    
        }

        return numberAsString === reversedNum ? true : false;
    }

}

