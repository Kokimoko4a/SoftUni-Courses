function attachEvents() {

  const baseURL = "http://localhost:3030/jsonstore/collections/students";

  let fistName = document.getElementById('firstName');
  let lastName = document.getElementById('lastName');
  let facultyNumber = document.getElementById('facultyNumber');
  let grade = document.getElementById('grade');
  let buttonSubmit = document.getElementById('submit');

  buttonSubmit.addEventListener('click', async () => {

  let student = {

    grade: grade.value,
    facultyNumber: facultyNumber.value,
    firstName: fistName.value,
    lastName: lastName.value
  };
  
  await fetch(baseURL, {

    method: 'POST',
    body: JSON.stringify(student)
  });

  let response

  });


}

attachEvents();