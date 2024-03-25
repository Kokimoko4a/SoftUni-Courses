import {page} from './lib.js'
import { showEx } from './views/example.js';
import * as api  from './data/request.js';
import * as userApi from './data/user.js'

page('/', showEx);

page.start();

window.api = api;
window.userApi = userApi;