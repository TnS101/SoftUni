import { getDetails, getMovies, createMovie, updateMovie, deleteMovie } from '../data.js';
import * as validate from '../validate.js';

function renderPartial(route, data) {
    return data == undefined ? this.partial(route, this.app.userData) : this.partial(route, Object.assign(data, this.app.userData));
}

async function setPartials() {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
    };
}

export async function details() {
    validate.auth();
    await setPartials();

    renderPartial('./templates/movies/details.hbs', await getDetails());
}

export async function cinema() {
    validate.auth();
    await setPartials();

    renderPartial('./templates/movies/allMoviesPage.hbs', await getMovies());
}

export async function createGet() {
    validate.auth();
    await setPartials();

    renderPartial('./templates/movies/createPage.hbs');
}

export async function createPost() {
    validate.auth();

    const movie = {
        name = this.params.name,
        description = this.params.description,
    }

    validate.fields(movie);

    const result = await createMovie(movie);

    validate.errors(result);
}