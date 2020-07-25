import home from './controllers/home.js';
import about from './controllers/about.js';
import * as login from './controllers/login.js';
import * as register from './controllers/register.js';
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

        this.get('#/register', register.get);
        this.post('#/register', (ctx) => { register.post.call(ctx); });

        this.get('#/login', login.get);
        this.post('#/login', (ctx) => { login.post.call(ctx); });


        this.get('#/catalog', catalog.main);

        this.get('#/catalog/:id', catalog.details);

        this.get('#/create', catalog.create);

        this.get('#/edit/:id', catalog.edit);

    });

    app.run();
});