function lockedProfile() {

    let profiles = document.getElementsByClassName("profile");

    let buttons = Array.from(document.getElementsByTagName("button"));


    buttons[0].addEventListener('click', showOrHideInfoForUser1);
    buttons[1].addEventListener('click', showOrHideInfoForUser2);
    buttons[2].addEventListener('click', showOrHideInfoForUser3);




    function showOrHideInfoForUser1(event) {
        let button = event.target;

        let parent = button.parentNode;

        let hiddenFields = document.getElementById("user1HiddenFields");

        let child = parent.getElementsByTagName('input')[0];

        if (!child.checked && button.textContent === "Show more") {


            hiddenFields.style.display = "block";


            button.textContent = "Hide it";


        }

        else if (!child.checked && button.textContent !== "Show more") {





            hiddenFields.style.display = "none";


            button.textContent = "Show more";


        }
    }

    function showOrHideInfoForUser3(event) {
        let button = event.target;

        let parent = button.parentNode;

        let hiddenFields = document.getElementById("user3HiddenFields");

        let child = parent.getElementsByTagName('input')[0];

        if (!child.checked && button.textContent === "Show more") {


            hiddenFields.style.display = "block";


            button.textContent = "Hide it";


        }

        else if (!child.checked && button.textContent !== "Show more") {





            hiddenFields.style.display = "none";


            button.textContent = "Show more";


        }
    }

    function showOrHideInfoForUser2(event) {
        let button = event.target;

        let parent = button.parentNode;

        let hiddenFields = document.getElementById("user2HiddenFields");

        let child = parent.getElementsByTagName('input')[0];

        if (!child.checked && button.textContent === "Show more") {


            hiddenFields.style.display = "block";


            button.textContent = "Hide it";


        }

        else if (!child.checked && button.textContent !== "Show more") {





            hiddenFields.style.display = "none";


            button.textContent = "Show more";


        }
    }

}