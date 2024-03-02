function solve() {

    let firstStop = 'depot';
    let departButton = document.getElementById('depart');
    let arriveButton = document.getElementById('arrive');
    let nameOfStop = document.getElementsByTagName('span')[0];
    let nextStopId = '';
    let stopName = '';


    function depart() {



        const url = 'http://localhost:3030/jsonstore/bus/schedule/';



        let response = fetch(url + firstStop).then(data => data.json()).then(data => {

            nameOfStop.textContent = `Next stop ${data.name}`;
            departButton.disabled = true;
            arriveButton.disabled = false;
            nextStopId = data.next;
            stopName = data.name;


        });


      

    }

    function arrive() {

        departButton.disabled = false;
        arriveButton.disabled = true;
        nameOfStop.textContent = `Arriving at ${stopName}`;
        firstStop = nextStopId;


    }

    return {
        depart,
        arrive
    };
}

let result = solve();