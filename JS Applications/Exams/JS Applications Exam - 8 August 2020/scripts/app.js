import * as common from './controllers/common.js';
import * as user from './controllers/user.js';
import * as movie from './controllers/movie.js';
import * as router from './helpers/routeHelper.js';

$(() => {
    const app = new Sammy('#main', function() {
        this.use('Handlebars', 'hbs');

        this.userData = {
            loggedIn: false
        }

        router.bulkGet('#/, /, #/home', common.home, this);

        router.mirror('#/register', user.registerGet, user.registerPost, this);
        router.mirror('#/login', user.loginGet, user.loginPost, this);
        router.mirror('#/create', movie.createGet, movie.createPost, this);
        router.mirror('#/edit/:id', movie.updateGet, movie.updatePost, this);

        this.get('#/like/:id/:ownerId', movie.like);
        this.get('#/search', movie.search);

        this.get('#/logout', user.logoutPost);
        this.get('#/myMovies', movie.myMovies);
        this.get('#/details/:id', movie.details);
        this.get('#/delete/:id', (ctx) => { movie.deletePost.call(ctx); });
    });

    app.run();
})