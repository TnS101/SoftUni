import * as helper from '../helpers/partialHelper.js';
import { getMovies } from '../data.js';

export async function home() {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
    };

    helper.render('home/home', this, { movies: await getMovies() });
}