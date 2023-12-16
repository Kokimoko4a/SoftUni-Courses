
let baseURL = 'http://localhost:3030/jsonstore/tasks';

let buttonGet = document.getElementById('load-history');
let listWithTowns = document.getElementById('list');
let buttonAdd = document.getElementById('add-weather');
let locationInput = document.getElementById('location');
let temperature = document.getElementById('temperature');
let date = document.getElementById('date');
let editButton = document.getElementById('edit-weather');
let formElement = document.querySelector('#form form');


editButton.addEventListener('click', async (e) => {

    e.preventDefault();

    let updatedRecord = {

        _id: formElement.dataset.weather,
        location: locationInput.value,
        date: date.value,
        temperature: temperature.value

    };

    await fetch(`http://localhost:3030/jsonstore/tasks/${formElement.dataset.weather}`, {

        method: 'PUT',
        body: JSON.stringify(updatedRecord)
    });

    let response = await fetch(baseURL);

    getHistroies(await response.json());

    editButton.disabled = true;
    buttonAdd.disabled = false;
    locationInput.value = "";
    temperature.value = '';
    date.value = '';
    currId = "";

    delete formElement.dataset.weather;

})

buttonAdd.addEventListener('click', async (e) => {
    e.preventDefault();

    if (locationInput.value === '' && temperature.value === '' && date.value === '') {
        return null;
    }

    let newRecord = {
        location: locationInput.value,
        temperature: temperature.value,
        date: date.value,
    };

    await fetch(baseURL, {
        method: 'POST',
        body: JSON.stringify(newRecord),
    });

    // Fetch the updated data
    let response = await fetch(baseURL);
    let data = await response.json();

    // Update the form element with the ID of the last added record
    
    // Update the UI with the new data
    getHistroies(data);

    locationInput.value = '';
    temperature.value = '';
    date.value = '';
});

buttonGet.addEventListener('click', async (e) => {

    e.preventDefault();

    let response = await fetch(baseURL);

    let history = await response.json();

    getHistroies(history);
});

function getHistroies(input) {

    listWithTowns.innerHTML = "";

    Object.values(input).forEach(x => {

        /* <div class="container">
                        <h2>Sofia</h2>
                        <h3>2023-08-01</h3>
                        <h3 id="celsius">35</h3>
                        <div id="buttons-container">  //
                        <button class="change-btn">Change</button>
                        <button class="delete-btn">Delete</button>
                        </div>
                        
                    </div> */

        let div = document.createElement('div');
        div.className = 'container';

        let name = document.createElement('h2');
        let currDate = document.createElement('h3');
        let celsius = document.createElement('h3');

        celsius.setAttribute('id', 'celsius');

        let butttonsDiv = document.createElement('div');
        butttonsDiv.setAttribute('id', 'buttons-container');

        let buttonChange = document.createElement('button');
        buttonChange.textContent = 'Change';
        buttonChange.className = 'change-btn';

        buttonChange.addEventListener('click', async (e) => {


            e.preventDefault();

            locationInput.value = name.textContent;
            temperature.value = celsius.textContent;
            date.value = currDate.textContent;

            editButton.disabled = false;
            buttonAdd.disabled = true;

            formElement.dataset.weather = x._id;



            div.remove();
        })

        let buttonDelete = document.createElement('button');
        buttonDelete.textContent = 'Delete';
        buttonDelete.className = "delete-btn";

        buttonDelete.addEventListener('click', async (e) => {

            e.preventDefault();



            await fetch(`http://localhost:3030/jsonstore/tasks/${x._id}`, {

                method: 'DELETE'
            });

            let response = await fetch(baseURL);
            getHistroies(await response.json());


        })

        name.textContent = x.location;
        currDate.textContent = x.date;
        celsius.textContent = x.temperature;

        listWithTowns.appendChild(div);
        div.appendChild(name);
        div.appendChild(currDate);
        div.appendChild(celsius);
        div.appendChild(butttonsDiv);

        butttonsDiv.appendChild(buttonChange);
        butttonsDiv.appendChild(buttonDelete);


    })
}


//send GET request

//attach elements to DOM tree
