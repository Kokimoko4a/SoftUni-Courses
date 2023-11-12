function solve(char1,char2){

    let char1Code = char1.charCodeAt();
    let char2Code = char2.charCodeAt();

    if(char1Code < char2Code){

        printChars1(char1Code,char2Code);
    }

    else{
        printChars2(char1Code,char2Code);
    }

    function printChars1(char1Code,char2Code){

        let result = "";

        for(let i = char1Code + 1; i< char2Code; i++)
        {
           
           result += String.fromCharCode(i) + " ";
        }

        console.log(result);
    }

    function printChars2(char1Code,char2Code){

        let result = "";

        for(let i = char2Code + 1; i < char1Code; i++)
        {
           
           result += String.fromCharCode(i) + " ";
        }

        console.log(result);
    }
}


