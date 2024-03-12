import { html, render } from '/node_modules/lit-html/lit-html.js'

let townsInputField = document.getElementById('towns');
let buttonSubmit = document.getElementById('btnLoadTowns');
let listOfTowns = document.getElementById('root');
debugger

buttonSubmit.addEventListener('click', (e) => {


    e.preventDefault();

    let towns = townsInputField.value.split(', ');
    insertIntoDOM(generateTemplate(towns), listOfTowns);

})



function generateTemplate(data) {



    return html`

    <ul>
    ${data.map(x => html`<li>${x}</li>`)}
    </ul>

    `
}

function insertIntoDOM(temp) {

    render(temp, root);

}
