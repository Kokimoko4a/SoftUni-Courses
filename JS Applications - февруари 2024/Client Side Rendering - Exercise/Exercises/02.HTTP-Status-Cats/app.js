import { html, render } from '/node_modules/lit-html/lit-html.js'
import { cats } from './catSeeder.js';

let allCats = document.getElementById('allCats');

render(generateTemp(cats), allCats);

let infos = document.getElementsByClassName('info');

let arr = Array.from(infos);

arr.forEach(element => {

    let showBtn = element.getElementsByClassName('showBtn')[0];

    showBtn.addEventListener('click', (e) => {

        e.preventDefault();
        let textOfBtn = showBtn.textContent;

        if (textOfBtn == 'Hide status code') {
            let hiddenInfo = element.getElementsByClassName('status')[0];

            hiddenInfo.style.display = 'none';
            showBtn.textContent = 'Show status code';
        }

        else{

            let hiddenInfo = element.getElementsByClassName('status')[0];
            hiddenInfo.style.display = 'block';
            showBtn.textContent = 'Hide status code';
        }

    })
})



function generateTemp(cats) {

    return html`

        <ul>
            ${cats.map(x => html` <li>
            <img src="./images/${x.imageLocation}.jpg" width="250" height="250" alt="Card image cap">
            <div class="info">
                <button class="showBtn">Show status code</button>
                <div class="status" style="display: none" id=${x.id}>
                    <h4>Status Code: ${x.statusCode}</h4>
                    <p>${x.statusMessage}</p>
                </div>
            </div>
        </li>`)}
        </ul>
  
    `
}