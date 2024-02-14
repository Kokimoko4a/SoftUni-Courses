window.addEventListener('load', solution);

function solution() {

  let addBtn = document.getElementById('add-btn');

  addBtn.addEventListener('click', (e) => {

    e.preventDefault();

    let employeeName = document.getElementById('employee');
    let category = document.getElementById('category');
    let urgency = document.getElementById('urgency');
    let assignedTeam = document.getElementById('team');
    let desciption = document.getElementById('description');

    if (employeeName.value !== "" && category.value !== "" && urgency.value !== "" && assignedTeam.value !== "" && desciption.value !== "") {


      let previewList = document.getElementsByClassName('preview-list')[0];

      let li = document.createElement('li');
      li.classList.add('problem-content');

      let article = document.createElement('article');

      let pForName = document.createElement('p');
      pForName.textContent = 'From: ' + employeeName.value;
      let helperName = employeeName.value;

      let pForCategory = document.createElement('p');
      let helperCategory = category.value;
      pForCategory.textContent = 'Category: ' + helperCategory;

      let pForUrgency = document.createElement('p');
      let helperUrgency = urgency.value;
      pForUrgency.textContent = 'Urgency: ' + helperUrgency;

      let pForTeam = document.createElement('p');
      let helperForTeamP = assignedTeam.value;
      pForTeam.textContent = 'Assigned to: ' + helperForTeamP;

      let pForDescription = document.createElement('p');
      let helperDesciption = desciption.value;
      pForDescription.textContent = 'Description: ' + helperDesciption;

      let editBtn = document.createElement('button');
      editBtn.classList.add('edit-btn');
      editBtn.textContent = 'Edit';

      let continueBtn = document.createElement('button');
      continueBtn.classList.add('continue-btn');
      continueBtn.textContent = 'Continue';

      previewList.appendChild(li);

      li.appendChild(article);

      article.appendChild(pForName);
      article.appendChild(pForCategory);
      article.appendChild(pForUrgency);
      article.appendChild(pForTeam);
      article.appendChild(pForDescription);

      li.appendChild(editBtn);
      li.appendChild(continueBtn);



      employeeName.value = '';
      category.value = '';
      urgency.value = '';
      assignedTeam.value = '';
      desciption.value = '';

      addBtn.disabled = true;

      editBtn.addEventListener('click', (e) => {

        e.preventDefault();

        li.remove();

        employeeName.value = helperName;
        category.value = helperCategory;
        urgency.value = helperUrgency;
        assignedTeam.value = helperForTeamP;
        desciption.value = helperDesciption;

        addBtn.disabled = false;
      });

      continueBtn.addEventListener('click', (e) => {

        e.preventDefault();

        let pendingList = document.getElementsByClassName('pending-list')[0];

        let liPending = document.createElement('li');
        liPending.classList.add('problem-content');

        let articlePending = document.createElement('article');

        let pForNamePending = document.createElement('p');
        pForNamePending.textContent = pForName.textContent;

        let pForCategoryPending = document.createElement('p');
        pForCategoryPending.textContent = pForCategory.textContent;

        let pForUrgencyPending = document.createElement('p');
        pForUrgencyPending.textContent = pForUrgency.textContent;

        let pForTeamPending = document.createElement('p');
        pForTeamPending.textContent = pForTeam.textContent;

        let pForDescriptionPending = document.createElement('p');
        pForDescriptionPending.textContent = pForDescription.textContent;

        let resolvedBtn = document.createElement('button');
        resolvedBtn.classList.add('resolve-btn');
        resolvedBtn.textContent = 'Resolved';

        pendingList.appendChild(liPending);

        liPending.appendChild(articlePending);

        articlePending.appendChild(pForNamePending);
        articlePending.appendChild(pForCategoryPending);
        articlePending.appendChild(pForUrgencyPending);
        articlePending.appendChild(pForTeamPending);
        articlePending.appendChild(pForDescriptionPending);

        liPending.appendChild(resolvedBtn);

        li.remove();

        resolvedBtn.addEventListener('click', (e) => {

          e.preventDefault();

          let resolvedList = document.getElementsByClassName('resolved-list')[0];

          let liResolved = document.createElement('li');
          liResolved.classList.add('problem-content');

          let articleResolved = document.createElement('article');

          let pForNameResolved = document.createElement('p');
          pForNameResolved.textContent = pForNamePending.textContent;

          let pForCategoryResolved = document.createElement('p');
          pForCategoryResolved.textContent = pForCategoryPending.textContent;

          let pForUrgencyResolved = document.createElement('p');
          pForCategoryResolved.textContent = pForCategoryPending.textContent;

          let pForTeamResolved = document.createElement('p');
          pForTeamResolved.textContent = pForTeamPending.textContent;

          let pForDescriptionResolved = document.createElement('p');
          pForDescriptionResolved.textContent = pForDescriptionPending.textContent;

          let clearBtn = document.createElement('button');
          clearBtn.classList.add('clear-btn');
          clearBtn.textContent = 'Clear';

          resolvedList.appendChild(liResolved);

          liResolved.appendChild(articleResolved);

          articleResolved.appendChild(pForNameResolved);
          articleResolved.appendChild(pForCategoryResolved);
          articleResolved.appendChild(pForUrgencyResolved);
          articleResolved.appendChild(pForTeamResolved);
          articleResolved.appendChild(pForDescriptionResolved);

          liResolved.appendChild(clearBtn);

          liPending.remove();

          clearBtn.addEventListener('click', (e) => {

            e.preventDefault();

            liResolved.remove();

            addBtn.disabled = false;

          })

        })
      })

    }
  })
}




