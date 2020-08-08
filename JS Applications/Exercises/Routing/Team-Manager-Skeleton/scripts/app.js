import home from './controllers/home.js';
import about from './controllers/about.js';
import * as user from './controllers/user.js';
import * as catalog from './controllers/catalog.js';

$(() => {
    const app = Sammy('#main', function() {
        this.use('Handlebars', 'hbs');

        this.userData = {
            loggedIn: false,
            hasTeam: false
        }

        this.get('/', home);
        this.get('#/home', home);

        this.get('#/about', about);

        this.get('#/register', user.registerGet);
        this.post('#/register', (ctx) => { user.registerPost.call(ctx); });

        this.get('#/login', user.loginGet);
        this.post('#/login', (ctx) => { user.loginPost.call(ctx); });

        this.get('#/logout', user.logoutPost);

        this.get('#/catalog', catalog.main);
        this.get('#/catalog/:id', catalog.details);

        this.get('#/create', catalog.create);
        this.post('#/create', (ctx) => { catalog.createPost.call(ctx); });

        this.get('#/edit/:id', catalog.edit);
        this.put('#/edit/:id', (ctx) => { catalog.editPost.call(ctx); });
    });

    app.run();
});