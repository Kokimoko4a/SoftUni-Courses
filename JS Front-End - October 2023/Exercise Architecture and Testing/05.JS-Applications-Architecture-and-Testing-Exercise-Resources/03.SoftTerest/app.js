import { hasUser } from "./src/utils/userUtils.js";
import { showRegisterView } from "./src/views/registerView.js";

document.querySelectorAll("div[data-selection = 'section']").forEach(element => {

    element.remove();
});;


let main = document.getElementsByTagName('main')[0];

const nav = document.querySelector('nav');

nav.addEventListener('click', onNavigate);
updateNav();


const routes = {

    "/": () => console.log('home'),
    "/03.SoftTerest/home": () => console.log('home'),
    '/03.SoftTerest/dashboard': () => console.log('dashboard'),
    '/03.SoftTerest/create': () => console.log('create'),
    '/03.SoftTerest/login': () => console.log('login'),
    '/03.SoftTerest/logout': () => console.log('logout'),
    '/03.SoftTerest/register': showRegisterView,
    '/03.SoftTerest/detais': () => console.log('details'),
    '*': () => console.log("Error 404 not found")


}

function updateNav() {

    const userAvaible = hasUser();

    const userBars = document.querySelectorAll("a[data-permission='user']");
    const guestBars = document.querySelectorAll("a[data-permission='guest']");

    if (userAvaible) {

        guestBars.forEach(bar => bar.style.display = 'none');
        userBars.forEach(bar => bar.style.display = 'block');
    }

    else {

        userBars.forEach(bar => bar.style.display = 'none');
        guestBars.forEach(bar => bar.style.display = 'block');
    }

}


function renderer(view){

    main.replaceChildren(view);
}


function onNavigate(e) {

    e.preventDefault();

    let element = e.target;

    if (e.target.tagName !== "A" && e.target.tagName !== 'IMG') {

        return
    }

    if (e.target.tagName === 'IMG') {

        element = e.target.parentElement;

    }

    let viewName = new URL(element.href).pathname;

    goTo(viewName);

}

let ctx = {
    render: renderer
};

function goTo(name) {

    const handler = routes[name];

    console.log(name);

    if (typeof handler !== 'function') {

        return routes['*'];
    }

    handler(ctx);
}
