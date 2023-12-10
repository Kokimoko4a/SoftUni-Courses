async function attachEvents() {

  const baseURL = "http://localhost:3030/jsonstore/collections/students";

  let firstName = document.getElementsByName('firstName')[0];
  let lastName = document.getElementsByName('lastName')[0];
  let facultyNumber = document.getElementsByName('facultyNumber')[0];
  let grade = document.getElementsByName('grade')[0];
  
  let buttonSubmit = document.getElementById('submit');
  let table = document.querySelector('tbody');

  let response = await fetch(baseURL);

  let students = await response.json();

  Object.values(students).forEach(student => {

    let tr = document.createElement('tr');
    let tdForFirstName = document.createElement('td');
    let tdForLastName = document.createElement('td');
    let tdForFacultyNumber = document.createElement('td');
    let tdForGrade = document.createElement('td');

    tdForFacultyNumber.textContent = student.facultyNumber;
    tdForFirstName.textContent = student.firstName;
    tdForGrade.textContent = student.grade;
    tdForLastName.textContent = student.lastName;


    table.appendChild(tr);
    tr.appendChild(tdForFirstName);
    tr.appendChild(tdForLastName);
    tr.appendChild(tdForGrade);
    tr.appendChild(tdForFacultyNumber);
  })

  buttonSubmit.addEventListener('click', async () => {


 
    let student = {
      grade: grade.value,
      facultyNumber: facultyNumber.value,
      firstName: firstName.value,
      lastName: lastName.value,
    };

    await fetch(baseURL, {
      method: 'POST',
      body: JSON.stringify(student),
    });

   

  });


}

attachEvents();