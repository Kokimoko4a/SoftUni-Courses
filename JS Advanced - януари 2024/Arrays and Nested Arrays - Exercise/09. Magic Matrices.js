function solve(matrix) {
    let flag = true;
    let previous = 0;
    
    for (let index = 0; index < matrix.length; index++) {
        let curr = 0;  // Reset curr for each column

        for (let k = 0; k < matrix[index].length; k++) {
            const element = matrix[index][k];  // Access elements along the column

            curr += element;
        }

        if (index !== 0) {
            if (curr !== prevoius) {
                flag = false;
                break;  // If a mismatch is found, no need to check further
            }
        }

         prevoius = curr;  // Moved inside the loop
    }

    let output = flag ? true : false;
    console.log(output);
}


console.log(solve([[11, 32, 45],
    [21, 0, 1],
    [21, 1, 1]]
   )
   );