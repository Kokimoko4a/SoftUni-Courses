async function lockedProfile() {
    const baseURL = "http://localhost:3030/jsonstore/advanced/profiles";

    let mainContainer = document.getElementById('main');

    let response = await fetch(baseURL);
    let users = await response.json();

    for (const user of Object.values(users)) {
        let username = user.username;
        let age = user.age;
        let email = user.email;

        let profileHTML = `<div class="profile">
            <img src="./iconProfile2.png" class="userIcon" />
            <label>Lock</label>
            <input type="radio" name="user1Locked" value="lock" checked>
            <label>Unlock</label>
            <input type="radio" name="user1Locked" value="unlock"><br>
            <hr>
            <label>Username</label>
            <input type="text" name="user1Username" value="${username}" disabled readonly />
            <div class="user1Username" style="display: none;">
                <hr>
                <label>Email:</label>
                <input type="email" name="user1Email" value="${email}" disabled readonly />
                <label>Age:</label>
                <input type="text" name="user1Age" value="${age}" disabled readonly />
            </div>
            <button>Show more</button>
        </div>`;

        mainContainer.innerHTML += profileHTML;

        let currentProfile = mainContainer.lastElementChild;
        let classUser1UsernameDiv = currentProfile.querySelector('.user1Username');
        let button = currentProfile.querySelector('button');

        button.addEventListener('click', function () {
            if (button.textContent === "Show more") {
                classUser1UsernameDiv.style.display = 'block';
                button.textContent = "Hide";
            } else {
                classUser1UsernameDiv.style.display = 'none';
                button.textContent = "Show more";
            }
        });
    }
}