function lockedProfile() {

    const baseUrlForGettingAllUsers = 'http://localhost:3030/jsonstore/advanced/profiles';
    let mainList = document.getElementById('main');

    fetch(baseUrlForGettingAllUsers).then(data => data.json()).catch().then(data => {

        for (const key in data) {


            console.log(data[key]);


            let divProfile = document.createElement('div');
            divProfile.classList.add('profile');

            let img = document.createElement('img');
            img.setAttribute('src', './iconProfile2.png');
            img.classList.add('userIcon');

            let labelForLocking = document.createElement('label');
            labelForLocking.textContent = 'Lock';

            let inputTagLocked = document.createElement('input');
            inputTagLocked.setAttribute('type', 'radio');
            inputTagLocked.setAttribute('name', 'user1Locked');
            inputTagLocked.setAttribute('value', 'lock');
            inputTagLocked.checked = true;

            let inputTagUNlocked = document.createElement('input');
            inputTagLocked.setAttribute('type', 'radio');
            inputTagLocked.setAttribute('name', 'user1Locked');
            inputTagLocked.setAttribute('value', 'unlock');

            let br = document.createElement('br');
            let hr = document.createElement('hr');

            let labelUsername = document.createElement('label');
            labelUsername.textContent = data.username;

            let inputTagForUsername = document.createElement('input');
            inputTagForUsername.setAttribute('type', 'text');
            inputTagForUsername.setAttribute('name', 'user1Username');//here may be data.username,we will see ;)
            inputTagForUsername.setAttribute('value', data.username); //here can be problems
            inputTagForUsername.disabled = true;
            inputTagForUsername.readOnly = true;

            let divHiddenFields = document.createElement('div');
            divHiddenFields.setAttribute('id', 'user1HiddenFields');

            let hrAfterHiddenFields = document.createElement('hr');

            let labelForEmail = document.createElement('label');
            labelForEmail.textContent = 'Email:';

            let inputEmail = document.createElement('input');
            inputEmail.setAttribute('type','email');
            inputEmail.setAttribute('name','user1Email');
            inputEmail.setAttribute('value',data.email);
            inputEmail.disabled = true;
            inputEmail.readOnly = true;






            mainList.appendChild(divProfile);
            divProfile.appendChild(img);

        }

    })
}