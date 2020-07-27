$(() => {
    const app = new Sammy('#main', function() {
        this.use('Handlebars', 'hbs');

        this.userData = {
            loggedIn: false
        }

        this.get('/', );
    });

    app.run();
})