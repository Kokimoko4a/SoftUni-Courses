import {page} from './lib.js'
import { showCatalog } from './views/catalog.js';
import { showHome } from './views/home.js';

console.log(1);
page('/', showHome);
page('/home', showHome);
page('/catalog', showCatalog);

page.start();


