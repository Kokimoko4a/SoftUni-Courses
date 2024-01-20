function solve(array){

    let result = [];

    for (let index = 1; index < array.length; index++) {
        const element = array[index];
        

        let currentData = element.split("|").map(x => x.trim()).filter(x => !!x)
       
      

        let currentTown = {
            Town: currentData[0],
            Latitude: (Number)((Number)(currentData[1]).toFixed(2)),
            Longitude: (Number)((Number)(currentData[2]).toFixed(2))
        };

    

        result.push(currentTown);

    }

    console.log(JSON.stringify(result));

}

solve(['| Town | Latitude | Longitude |',
'| Sofia | 42.696552 | 23.32601 |',
'| Beijing | 39.913818 | 116.363625 |']
)