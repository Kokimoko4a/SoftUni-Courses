window.addEventListener('load', solve);

function solve() {


    let nextBtn = document.getElementById('next-btn');
    let reservationList = document.getElementsByClassName('info-list')[0];
    let infoList = document.getElementsByClassName('confirm-list')[0];
    let verficationH1 = document.getElementById('verification');


    nextBtn.addEventListener('click', (e) => {



        e.preventDefault();

        let firstName = document.getElementById("first-name");
        let lastName = document.getElementById("last-name");
        let dateIn = document.getElementById("date-in");
        let dateOut = document.getElementById("date-out");
        let peopleCount = document.getElementById("people-count");
        let dateInParsed = new Date(dateIn.value);
        let dateOutParsed = new Date(dateOut.value);

        //

        if (firstName.value.trim() && lastName.value.trim() && peopleCount.value && dateIn.value && dateOut.value && dateInParsed.getTime() < dateOutParsed.getTime()) {

            let listItem = document.createElement('li');
            listItem.classList.add('reservation-content');

            let article = document.createElement('article');

            let h3 = document.createElement('h3');
            let pForDateIn = document.createElement('p');
            let pForDateOut = document.createElement('p');
            let pForPeopleCount = document.createElement('p');


            let btnEdit = document.createElement('button');
            let btnContinue = document.createElement('button');

            btnEdit.classList.add('edit-btn');
            btnEdit.textContent = 'Edit';
            btnContinue.classList.add('continue-btn');
            btnContinue.textContent = 'Continue';
            //article
            h3.textContent = `Name: ${firstName.value} ${lastName.value}`;
            let heplerForFirstName = firstName.value;
            let helperForLastName = lastName.value;
            pForDateIn.textContent = `From date: ${dateIn.value}`;
            let helperForDateIn = dateIn.value;
            let helperForDateOut = dateOut.value;
            pForDateOut.textContent = `To date: ${dateOut.value}`;
            let helpetForPeopleCount = peopleCount.value;
            pForPeopleCount.textContent = `For ${peopleCount.value} people`;
            //article

            reservationList.appendChild(listItem);
            listItem.appendChild(article);

            article.appendChild(h3);
            article.appendChild(pForDateIn);
            article.appendChild(pForDateOut);
            article.appendChild(pForPeopleCount);

            listItem.appendChild(btnEdit);
            listItem.appendChild(btnContinue);

            firstName.value = '';
            lastName.value = '';
            dateIn.value = '';
            dateOut.value = '';
            peopleCount.value = '';
            nextBtn.disabled = true;
            btnEdit.disabled = false;
            btnContinue.disabled = false;

            btnEdit.addEventListener('click', () => {

                firstName.value = heplerForFirstName;
                lastName.value = helperForLastName;
                dateIn.value = helperForDateIn;
                dateOut.value = helperForDateOut;
                peopleCount.value = helpetForPeopleCount;

                listItem.remove();

                nextBtn.disabled = false;


            });

            btnContinue.addEventListener('click', () => {

                let listItemForInfoList = document.createElement('li');

                listItemForInfoList.classList.add('reservation-content');

                let articleForInfo = document.createElement('article');
                let h3ForNameInfo = document.createElement('h3');
                let pForDateInInfo = document.createElement('p');
                let pForDateOutInfo = document.createElement('p');
                let pForPeopleCountInfo = document.createElement('p');
                //article

                let confirmBtn = document.createElement('button');
                let cancelBtn = document.createElement('button');

                confirmBtn.classList.add('confirm-btn');
                cancelBtn.classList.add('cancel-btn');
                confirmBtn.textContent = 'Confirm';
                cancelBtn.textContent = 'Cancel';

                infoList.appendChild(listItemForInfoList);

                listItemForInfoList.appendChild(articleForInfo);

                articleForInfo.appendChild(h3ForNameInfo);
                articleForInfo.appendChild(pForDateInInfo);
                articleForInfo.appendChild(pForDateOutInfo);
                articleForInfo.appendChild(pForPeopleCountInfo);
                listItemForInfoList.appendChild(confirmBtn);
                listItemForInfoList.appendChild(cancelBtn);

                h3ForNameInfo.textContent = h3.textContent;
                pForDateInInfo.textContent = pForDateIn.textContent;
                pForDateOutInfo.textContent = pForDateOut.textContent;
                pForPeopleCountInfo.textContent = pForPeopleCount.textContent;

                listItem.remove();

                confirmBtn.addEventListener('click', () => {

                    listItemForInfoList.remove();

                    nextBtn.disabled = false;

                    verficationH1.classList.remove('reservation-confirmed');
                    verficationH1.classList.remove('reservation-cancelled');
                    verficationH1.textContent = 'Confirmed.';
                    verficationH1.classList.add('reservation-confirmed');
                });

                cancelBtn.addEventListener('click', () => {

                    listItemForInfoList.remove();

                    nextBtn.disabled = false;

                    verficationH1.textContent = 'Cancelled.';
                    verficationH1.classList.remove('reservation-confirmed');
                    verficationH1.classList.remove('reservation-cancelled');
                    verficationH1.classList.add('reservation-cancelled');
                })

            })
        }


    });



}






