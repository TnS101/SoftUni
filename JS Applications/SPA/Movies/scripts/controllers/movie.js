import { getDetails, getMovies, createMovie, updateMovie, deleteMovie } from '../data.js';
import * as validate from '../helpers/validate.js';
import * as helper from '../helpers/partialHelper.js';

export async function details() {
    validate.auth();
    helper.headers;

    renderPartial('./templates/movies/details.hbs', await getDetails());
}

export async function cinema() {
    validate.auth();
    await setPartials();

    renderPartial('./templates/movies/allMoviesPage.hbs', await getMovies());
}

export async function myMovies() {
    validate.auth();
    const userId = localStorage.getItem('userId');
    const result = Array.from(await getMovies()).filter(e => e.ownerId == userId);

    renderPartial('./templates/movies/myMoviesPage.hbs', result);
}

export async function createGet() {
    validate.auth();
    await setPartials();

    renderPartial('./templates/movies/createPage.hbs');
}

export async function createPost() {
    validate.auth();

    const movie = {
        name: this.params.name,
        description: this.params.description,
        image: this.params.image,
        genres: this.params.genres,
        tickets: this.params.tickets
    }

    validate.fields(movie);
    const result = await createMovie(movie);
    validate.errors(result);

    this.redirect('#/myMovies');
}

export async function updateGet() {
    validate.auth();
    await setPartials();

    renderPartial('./templates/movies/editPage.hbs');
}