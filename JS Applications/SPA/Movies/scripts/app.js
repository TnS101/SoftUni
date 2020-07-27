import * as common from './controllers/common.js';
import * as user from './controllers/user.js';
import * as movie from './controllers/movie.js';

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

        this.get('#/logout', user.logoutPost);
    });

    app.run();
})