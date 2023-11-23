function parkingLot(input) {

    let list = [];

    input.forEach(element => {

        let row = element.split(", ");

        if (row[0].toUpperCase() === "IN" && !list.includes(row[1])) {

            list.push(row[1]);
        }

        else if (row[0].toUpperCase() === "OUT" && list.includes(row[1])) {

            let indexToRemoveAt = list.indexOf(row[1]);

            list.splice(indexToRemoveAt, 1);
        }
    });


    if (list.length === 0) {
        console.log("Parking Lot is Empty");
    }

    else {

        list  = list.sort((a,b) => a.localeCompare(b));

        console.log(list.join("\n"));
    }

}

parkingLot(['IN, CA2844AA',
'IN, CA1234TA',
'OUT, CA2844AA',
'IN, CA9999TT',
'IN, CA2866HI',
'OUT, CA1234TA',
'IN, CA2844AA',
'OUT, CA2866HI',
'IN, CA9876HH',
'IN, CA2822UU']
);