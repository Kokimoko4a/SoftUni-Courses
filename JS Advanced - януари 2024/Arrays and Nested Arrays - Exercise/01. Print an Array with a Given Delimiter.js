function placeDelimeter(array, delimeter){

    let output = "";

    for (let index = 0; index < array.length; index++) {
        const element = array[index];

        if (index !== array.length - 1) {
            
            output += element + delimeter;
        }
       
        else{

            output += element;
        }
       
    }
    
    console.log(output);
}

placeDelimeter(["d","d","d"], "-");