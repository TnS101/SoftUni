import { login, register, logout } from '../data.js';
import * as validate from '../helpers/validate.js';
import * as partial from '../helpers/partialHelper.js';

export async function loginGet() {
    await partial.headers(this)
    partial.render('user/login', this);
}

export async function loginPost() {
    const result = await login(this.params.email, this.params.password);

    validate.errors(result);

    this.app.userData.loggedIn = true;
    this.app.userData.username = result.email;
    this.app.userData.userId = result.objectId;

    localStorage.setItem('userToken', result['user-token']);
    localStorage.setItem('username', result.email);
    localStorage.setItem('userId', result.objectId);

    this.redirect('#/home');
}

export async function registerGet() {
    await partial.headers(this);
    partial.render('user/register', this);
}

export async function registerPost() {
    const result = await register(this.params.email, this.params.password);
    validate.errors(result);
    this.redirect('#/login');
}

export async function logoutPost() {
    this.app.userData.loggedIn = false;
    this.app.userData.username = '';

    localStorage.removeItem('userToken');

    await logout();
    this.redirect('#/home');
}