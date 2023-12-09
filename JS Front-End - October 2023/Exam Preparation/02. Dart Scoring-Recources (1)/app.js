window.addEventListener("load", solve);

function solve() {


  let buttonForAdding = document.getElementById("add-btn");

  let playerName = document.getElementById('player');
  let score = document.getElementById('score');
  let round = document.getElementById('round');

  let sureList = document.getElementById('sure-list');
  let scoreboard = document.getElementById('scoreboard-list');
  let clearButton = document.getElementsByClassName('btn clear')[0];

  clearButton.addEventListener('click', clear);

  buttonForAdding.addEventListener('click', add);

  function add() {

    if (playerName.value !== "" && score.value !== "" && round.value !== "") {


      let listItem = document.createElement('li');

      sureList.appendChild(listItem);
      listItem.className = 'dart-item';

      let article = document.createElement('article');

      listItem.appendChild(article);

      let paraForName = document.createElement('p');
      let paraForScore = document.createElement('p');
      let paraForRound = document.createElement('p');

      let heplerForScore = score.value;
      let heplerForRound = round.value;

      paraForName.textContent = playerName.value;
      paraForScore.textContent = `Score: ${score.value}`;
      paraForRound.textContent = `Round: ${round.value}`;

      article.appendChild(paraForName);
      article.appendChild(paraForScore);
      article.appendChild(paraForRound);

      playerName.value = "";
      score.value = '';
      round.value = '';

      let buttonEdit = document.createElement('button');
      let buttonOk = document.createElement('button');

      buttonEdit.className = 'btn edit';
      buttonOk.className = 'btn ok';

      buttonOk.textContent = 'ok';
      buttonEdit.textContent = 'edit';

      listItem.appendChild(buttonEdit);
      listItem.appendChild(buttonOk);

      buttonForAdding.disabled = true;

      buttonEdit.addEventListener('click', edit);
      buttonOk.addEventListener('click', sendToScoreboard);

      function edit() {

        score.value = heplerForScore;
        playerName.value = paraForName.textContent;
        round.value = heplerForRound;

        listItem.remove();

        buttonForAdding.disabled = false;
      }

      function sendToScoreboard() {

        buttonForAdding.disabled = false;

        let listItemForBoard = document.createElement('li');

        listItemForBoard.className = 'dart-item';

        scoreboard.appendChild(listItemForBoard);

        let articleForBoard = document.createElement('article');

        listItemForBoard.appendChild(articleForBoard);

        let paraForNameBoard = document.createElement('p');
        let paraForScoreBoard = document.createElement('p');
        let paraForRoundBoard = document.createElement('p');

        paraForNameBoard.textContent = paraForName.textContent;
        paraForScoreBoard.textContent = paraForScore.textContent;
        paraForRoundBoard.textContent = paraForRound.textContent;

        articleForBoard.appendChild(paraForNameBoard);
        articleForBoard.appendChild(paraForScoreBoard);
        articleForBoard.appendChild(paraForRoundBoard);

        listItem.remove();

        /*  paraForName.textContent = playerName.value;
            paraForScore.textContent = `Score: ${score.value}`;
            paraForRound.textContent = `Round: ${round.value}`; */
      }
    }

  }

  function clear() {

    window.location.reload(true);
  }

}


