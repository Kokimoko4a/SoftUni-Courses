function attachEvents() {

    const baseURL = 'http://localhost:3030/jsonstore/phonebook';
    let buttonForLoading = document.getElementById('btnLoad');
    let phoneBook = document.getElementById('phonebook');
    let buttonCreate = document.getElementById('btnCreate');
    let personName = document.getElementById('person');
    let phoneNumber = document.getElementById('phone');

    buttonForLoading.addEventListener('click', async () => {

        let response = await fetch(baseURL);

        let peopleAndPhoneNumbersJson = await response.json();

        for (const obj of Object.values(peopleAndPhoneNumbersJson)) {

            let li = document.createElement('li');
            li.textContent = `${obj.person}: ${obj.phone}`;
            let deleteButton = document.createElement('button');
            deleteButton.textContent = "Delete";
            li.appendChild(deleteButton);
            phoneBook.appendChild(li);

            deleteButton.addEventListener('click', deletePhoneNumber);

            async function deletePhoneNumber() {

                let response = await fetch(baseURL + `/${obj._id}`, {

                    method: 'DELETE',

                });

                li.remove();


            }
        }

    });

    buttonCreate.addEventListener('click', async () => {


        let phoneAndPersobObj = {

            person: personName.value,
            phone: phoneNumber.value
        };

        await fetch(baseURL, {

            method: 'POST',
            body: JSON.stringify(phoneAndPersobObj),

        });

        personName.value = "";
        phoneNumber.value = '';

        buttonForLoading.click();

    })


}

attachEvents();