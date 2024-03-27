
import {html,render} from '../node_modules/lit-html/lit-html.js';
import page from '../node_modules/page/page.mjs';

const root = document.getElementById('main'); 

export function renderer(templateResult){

    render(templateResult,root);
}

export{

    html,
    page

}