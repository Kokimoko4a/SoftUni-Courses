function print(number){

    let result = "";

    for (let index = 0; index < number; index++) {
        printRows(number);

    }
    
    function printRows(number){
        for (let index = 0; index < number; index++) {
            
            result+= number + " ";
            
        }

        console.log(result);
        result = "";
    }
}

print(3);