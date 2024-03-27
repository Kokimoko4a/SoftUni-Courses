import { logout } from './data/user.js';
import {page} from './lib.js'
import { getUserData, updateNav } from './utils.js';
import { showCatalog } from './views/catalog.js';
import { showCreate } from './views/create.js';
import { showHome } from './views/home.js';
import { showLogin } from './views/login.js';
import { showRegister } from './views/register.js';

updateNav();

console.log(1);
page('/', showHome);
page('/home', showHome);
page('/catalog', showCatalog);
page('/login', showLogin);
page('/register', showRegister);
page('/add', showCreate);

page.start();

document.getElementById('logoutBtn').addEventListener( 'click',async() =>{

    await logout();
    updateNav();
    page.redirect('/');
});


