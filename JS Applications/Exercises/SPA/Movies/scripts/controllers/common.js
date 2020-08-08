import * as helper from '../helpers/partialHelper.js';

export async function home() {
    await helper.headers(this);
    helper.render('home/home', this);
}