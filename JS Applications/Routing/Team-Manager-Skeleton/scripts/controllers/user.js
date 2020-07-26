import { login, register, logout } from '../data.js';
import * as validate from '../validate.js';

export async function loginGet() {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
        loginForm: await this.load('./templates/login/loginForm.hbs')
    };

    this.partial('./templates/login/loginPage.hbs', this.app.userData);
}

export async function loginPost() {
    const result = await login(this.params.username, this.params.password);

    try {
        if (result.hasOwnProperty('errorData')) {
            const error = new Error();
            Object.assign(error, result);
            throw error;
        }
        this.app.userData.loggedIn = true;
        this.app.userData.username = this.params.username;
        this.app.userData.userId = this.params.objectId;

        localStorage.setItem('userToken', result['user-token']);
        localStorage.setItem('username', result.username);
        localStorage.setItem('userId', result.objectId);


        this.redirect('#/home');
    } catch (error) {
        alert(error.message);
    }
}

export async function registerGet() {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
        registerForm: await this.load('./templates/register/registerForm.hbs')
    };
    this.partial('./templates/register/registerPage.hbs', this.app.userData);
}

export async function registerPost() {
    const result = await register(this.params.username, this.params.password);
    validate.errors(result);
    this.redirect('#/login');
}

export async function logoutPost() {
    this.app.userData.loggedIn = false;
    this.app.userData.username = '';

    localStorage.removeItem('userToken');

    await logout();
}