function createTowns(table){

   

    for (const data of table) {
        
        let curr = data.split(" | ");

        console.log(`{ town: '${curr[0]}', latitude: '${ parseFloat(curr[1]).toFixed(2)}', longitude: '${parseFloat(curr[2]).toFixed(2)}' }`);

    }
}

createTowns(['Sofia | 42.696552 | 23.32601',
'Beijing | 39.913818 | 116.363625']
);