function solve(array){

    let output = [];
    let number = 1;

    for (let index = 0; index < array.length; index++) {
        const element = array[index];
        

        if (element === "add") {
            
            output.push(number++);

        }

        else if (element === "remove") {
            
            output.pop();
            number++;
        }
    }

    if (output.length === 0) {
        
        console.log("Empty")
    }
    output.forEach(element => {

        console.log(element);
    })
}

solve(['add', 
'add', 
'add', 
'add']
);