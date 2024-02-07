function validateForm(event) {
    event.preventDefault(); // Prevent the default form submission behavior

    let regexForUsername = /^[a-zA-Z0-9]+{3,30}$/gm;
    let regexForPassword = /^\w{5,15}$/gm;
    let regexForEmail = /^[a-zA-Z0-9]+\@[a-zA-Z0-9]+\.+[A-Za-z0-9\.]*$/gm;

    let username = document.getElementById('username');
    let password = document.getElementById('password');
    let confirmPassword = document.getElementById('confirm-password');
    let email = document.getElementById('email');
    let companyFieldSet = document.getElementById('companyInfo');
    let companyNumber = document.getElementById('companyNumber');
    let check = document.getElementById('company');

    if (!regexForUsername.test(username.value)) {
        username.style.borderColor = "red";
    }

    if (!regexForPassword.test(password.value)) {
        password.style.borderColor = "red";
    }

    if (!regexForPassword.test(confirmPassword.value)) {
        confirmPassword.style.borderColor = "red";
    }

    if (!regexForEmail.test(email.value)) {
        email.style.borderColor = "red";
    }

    if (confirmPassword.value !== password.value) {
        confirmPassword.style.borderColor = "red";
    }

    if (check.checked) {
        if (companyNumber.value < 1000 || companyNumber.value > 9999) {
            companyNumber.style.borderColor = "red";
        } else {
            companyNumber.style.border = 'none';
        }
    }
}

// Add event listener to the form's submit event
document.getElementById('registerForm').addEventListener('submit', validateForm);