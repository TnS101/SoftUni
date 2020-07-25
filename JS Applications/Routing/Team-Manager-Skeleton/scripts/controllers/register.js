import { register } from '../data.js';

export async function get() {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
        registerForm: await this.load('./templates/register/registerForm.hbs')
    };
    this.partial('./templates/register/registerPage.hbs', this.app.userData);
}

export async function post() {
    const result = await register(this.params.username, this.params.password);

    this.redirect('#/login');
}