import { getDetails, getMovies, createMovie, updateMovie, deleteMovie } from '../data.js';
import * as validate from '../helpers/validate.js';
import * as partial from '../helpers/partialHelper.js';

export async function details() {
    validate.auth();
    await partial.headers(this);

    partial.render('movies/details', await getDetails());
}

export async function cinema() {
    validate.auth();
    await partial.headers(this);

    partial.render('movies/allMovies', this, await getMovies());
}

export async function myMovies() {
    validate.auth();
    const userId = localStorage.getItem('userId');
    const result = Array.from(await getMovies()).filter(e => e.ownerId == userId);

    partial.render('movies/myMovies', result);
}

export async function createGet() {
    validate.auth();
    await partial.headers(this);

    partial.render('movies/create', this);
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
    await partial.headers(this);

    partial.render('movies/edit', this);
}