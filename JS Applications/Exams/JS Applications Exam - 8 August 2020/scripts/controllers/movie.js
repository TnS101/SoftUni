import { getDetails, getMovies, createMovie, updateMovie, deleteMovie, likeMovie } from '../data.js';
import * as validate from '../helpers/validate.js';
import * as partial from '../helpers/partialHelper.js';

export async function details() {
    validate.auth();
    await partial.headers(this);
    const movie = await getDetails(this.params.id);
    const email = localStorage.getItem('username');

    if (this.app.userData.userId == movie.ownerId) {
        movie.owner = true;
    } else {
        movie.owner = false;
    }

    if (movie.people != undefined && movie.people.split(',').includes(email)) {
        movie.liked = true;
    } else {
        movie.liked = false;
    }

    partial.render('movies/details', this, movie);

}

export async function search() {
    validate.auth();
    await partial.headers(this);
    const result = await getMovies();
    partial.render('movies/details', this, result.find(m => m.title == this.params.title));
}

export async function cinema() {
    validate.auth();
    partial.render('movies/allMovies', this, await getMovies());
}

export async function myMovies() {
    validate.auth();
    await partial.headers(this);

    const userId = localStorage.getItem('userId');
    const result = Array.from(await getMovies()).filter(e => e.ownerId == userId);

    console.log({ movies: result });
    partial.render('movies/myMovies', this, { movies: result });
}

export async function createGet() {
    validate.auth();
    await partial.headers(this);

    partial.render('movies/create', this);
}

export async function createPost() {
    validate.auth();

    const movie = {
        title: this.params.title,
        description: this.params.description,
        image: this.params.image,
        people: '',
        likes: 0,
    }

    validate.fields(movie);

    const result = await createMovie(movie);

    validate.errors(result);

    this.redirect('#/home');
}

export async function updateGet() {
    validate.auth();
    await partial.headers(this);

    const movie = await getDetails(this.params.id);

    partial.render('movies/edit', this, movie);
}

export async function updatePost() {
    validate.auth();

    const movie = {
        title: this.params.title,
        description: this.params.description,
        image: this.params.image,
    }

    validate.fields(movie);

    const result = await updateMovie(this.params.id, movie);

    validate.errors(result);

    this.redirect('#/');
}

export async function deletePost() {
    validate.auth();

    const result = await deleteMovie(this.params.id);
    validate.errors(result);
    this.redirect('#/');
}

export async function like() {
    validate.auth();
    const userId = localStorage.getItem('userId');
    if (this.params.ownerId == userId) {
        window.alert("Cannot like own movie!");
        return;
    }
    const email = localStorage.getItem('username');

    const result = await likeMovie(this.params.id, email);

    this.redirect(`#/details/${this.params.id}`);
}