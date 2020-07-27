import * as common from './controllers/common.js';
import * as user from './controllers/user.js';

$(() => {
    const app = new Sammy('#main', function() {
        this.use('Handlebars', 'hbs');

        this.userData = {
            loggedIn: false
        }

        this.get('/', common.home);
        this.get('#/home', common.home);

        this.get('#/register', user.registerGet);
        this.post('#/register', (ctx) => { user.registerPost.call(ctx); });

        this.get('#/login', user.loginGet);
        this.post('#/login', (ctx) => { user.loginPost.call(ctx); });
    });

    app.run();
})