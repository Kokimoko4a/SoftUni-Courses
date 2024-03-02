function getInfo() {

    const url = 'http://localhost:3030/jsonstore/bus/businfo/';

    let buttonSubmit = document.getElementById('submit');
    let divStopName = document.getElementById('stopName');
    let listWithBuses = document.getElementById('buses');

    divStopName.textContent = '';
    listWithBuses.innerHTML = '';

    let stopId = document.getElementById('stopId');

    let response =  fetch(url + stopId.value).then(data => data.json()).catch(err => {divStopName.textContent = 'Error'}).then(data => {

        divStopName.textContent = data.name;

        for (const bus in data.buses) {

            let li = document.createElement('li');

            li.textContent = `Bus ${bus} arrives in ${data.buses[bus]} minutes`;

            listWithBuses.appendChild(li);
        }


    }).catch(error => {divStopName.textContent  = 'Error'});








}
