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
            inputTagLocked.setAttribute('name', 'user1Locked' + data[key].username);
            inputTagLocked.setAttribute('value', 'lock');
            inputTagLocked.checked = true;

            labelForUnlocking = document.createElement('label');
            labelForUnlocking.textContent = 'Unlock';

            let inputTagUNlocked = document.createElement('input');
            inputTagUNlocked.setAttribute('type', 'radio');
            inputTagUNlocked.setAttribute('name', 'user1Locked' + data[key].username);
            inputTagUNlocked.setAttribute('value', 'unlock');

            let br = document.createElement('br');
            let hr = document.createElement('hr');

            let labelUsername = document.createElement('label');
            labelUsername.textContent = data[key].username;

            let inputTagForUsername = document.createElement('input');
            inputTagForUsername.setAttribute('type', 'text');
            inputTagForUsername.setAttribute('name', data[key].username);
            inputTagForUsername.setAttribute('value', data[key].username); 
            inputTagForUsername.disabled = true;
            inputTagForUsername.readOnly = true;

            let divHiddenFields = document.createElement('div');
            divHiddenFields.setAttribute('id', data[key].username);

            let hrAfterHiddenFields = document.createElement('hr');

            let labelForEmail = document.createElement('label');
            labelForEmail.textContent = 'Email:';

            let inputEmail = document.createElement('input');
            inputEmail.setAttribute('type','email');
            inputEmail.setAttribute('name', data[key].email);
            inputEmail.setAttribute('value',data[key].email);
            inputEmail.disabled = true;
            inputEmail.readOnly = true;



            let labelForAge = document.createElement('label');
            labelForAge.textContent = 'Age:';

            let inputAge = document.createElement('input');
            inputAge.setAttribute('type','email');
            inputAge.setAttribute('name', data[key].age);
            inputAge.setAttribute('value',data[key].age);
            inputAge.disabled = true;
            inputAge.readOnly = true;

            let ShowMoreBtn = document.createElement('button');
            ShowMoreBtn.textContent = 'Show more';


            

            mainList.appendChild(divProfile);


            divProfile.appendChild(img);
            divProfile.appendChild(labelForLocking);
            divProfile.appendChild(inputTagLocked);
            divProfile.appendChild(labelForUnlocking);
            divProfile.appendChild(inputTagUNlocked);
            divProfile.appendChild(br);
            divProfile.appendChild(hr);
            divProfile.appendChild(labelUsername);
            divProfile.appendChild(inputTagForUsername);
            divProfile.appendChild(divHiddenFields);


            divHiddenFields.appendChild(hr);
            divHiddenFields.appendChild(labelForEmail);
            divHiddenFields.appendChild(inputEmail);
            divHiddenFields.appendChild(labelForAge);
            divHiddenFields.appendChild(inputAge);

            divProfile.appendChild(ShowMoreBtn);
            
            if (inputTagLocked) {
                    
                divHiddenFields.style.display = 'none';
            }


            ShowMoreBtn.addEventListener('click', () => {
                if (inputTagUNlocked.checked) {
                    if (ShowMoreBtn.textContent === 'Show more') {
                        divHiddenFields.style.display = 'block';
                        ShowMoreBtn.textContent = 'Hide it';
                    } else {
                        divHiddenFields.style.display = 'none';
                        ShowMoreBtn.textContent = 'Show more';
                    }
                }
            });



        }

    })
}