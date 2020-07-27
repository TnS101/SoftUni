import * as common from './controllers/common.js';
import * as user from './controllers/user.js';
import * as movie from './controllers/movie.js';
import * as routeHelper from './helpers/routeHelper.js';

$(() => {
    const app = new Sammy('#main', function() {
        this.use('Handlebars', 'hbs');

        this.userData = {
            loggedIn: false
        }

        routeHelper.bulkGet('#/, /, #/home', common.home, this);

        routeHelper.mirror('#/register', user.registerGet, user.registerPost, this);
        routeHelper.mirror('#/login', user.loginGet, user.loginPost, this);

        this.get('#/logout', user.logoutPost);
        this.get('#/cinema', movie.cinema);
    });

    app.run();
})