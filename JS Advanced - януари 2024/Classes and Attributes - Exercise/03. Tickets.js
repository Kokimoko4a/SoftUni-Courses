

function solve(arr, criteria){
    class Ticket{

        destination;
        price;
        status;
    
        constructor(destination, price, status){
    
            this.destination = destination;
            this.price = price;
            this.status = status;
        }
    
    }
    let list = [];

    for (let index = 0; index < arr.length; index++) {
        const element = arr[index];

        [destination, price, status] = element.split("|");

        let ticket = new Ticket(destination, Number(price).toFixed(1), status, index); // Pass index to Ticket constructor

        list.push(ticket);
    }

    if (criteria === "price") {
        list.sort((a, b) => a.price - b.price || a.index - b.index); // Use index as tiebreaker
    } else if (criteria === "destination") {
        list.sort((a, b) => a.destination.localeCompare(b.destination) || a.index - b.index); // Use index as tiebreaker
    } else if (criteria === "status") {
        list.sort((a, b) => a.status.localeCompare(b.status) || a.index - b.index); // Use index as tiebreaker
    }

    
    list.map(x => Number(x.price));

    for (let index = 0; index < list.length; index++) {
        const element = list[index];

        console.log(element.price);
        
    }
    return list;

    }

    




 console.log(solve(['Philadelphia|94.20|available',
 'New York City|95.99|available',
 'New York City|95.99|sold',
 'Boston|126.20|departed'],
'destination'));

