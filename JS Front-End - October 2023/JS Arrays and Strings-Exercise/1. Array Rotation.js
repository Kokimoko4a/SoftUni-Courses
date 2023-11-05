function rotate(array, rotations){

    for (let i = 0; i < rotations; i++) {
        
        array.push(array[0]);
        array.shift();
       
        
    }

    console.log(array.join(" "));
}
