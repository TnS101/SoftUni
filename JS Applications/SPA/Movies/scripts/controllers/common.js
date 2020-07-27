import * as helper from '../helpers/partialHelper.js';

export async function home() {
    await helper.headers(this);
    await helper.render('./templates/home/home.hbs', this);
}