import { auth } from './helpers/validate.js';

function host(endpoint) {
    return `https://api.backendless.com/3A098463-C602-719E-FFBB-CD0CC44AED00/762C6AA9-AAE3-4B3C-95C2-C686F71E8DAD/${endpoint}`
}

const endpoints = {
    register: 'users/register',
    login: 'users/login',
    movies: 'data/movies',
    logout: 'users/logout'
}

export async function getMovies() {
    return (await fetch(host(endpoints.movies))
        .then(result => result.json()));
}

export async function getDetails(id) {
    return await (fetch(host(`${endpoints.movies}/${id}`))
        .then(result => result.json()));
}

export async function createMovie(movie) {
    return (await fetch(host(endpoints.movies), {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'user-token': localStorage.getItem('userToken')
        },
        body: JSON.stringify(movie)
    })).json();
}

export async function register(username, password, repeatPassword) {
    return (await fetch(host(endpoints.register), {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            email: username,
            password
        })
    })).json();
}

export async function login(username, password) {
    return (await fetch(host(endpoints.login), {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            login: username,
            password
        })
    })).json();
}

export async function updateMovie(id, movie) {
    auth();

    return (await fetch(host(`${endpoints.movies}/${id}`), {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
            'user-token': localStorage.getItem('userToken')
        },
        body: JSON.stringify(movie)
    })).json();
}

export async function deleteMovie(id) {
    auth();

    return (await fetch(host(`${endpoints.movies}/${id}`), {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json',
            'user-token': localStorage.getItem('userToken')
        },
    })).json();
}

export async function logout() {
    return (await fetch(host(endpoints.logout), {
        method: 'GET',
    }));
}

export async function likeMovie(id, email) {
    auth();
    const movie = await getDetails(id);
    var toAdd = '';
    if (!movie.people.split(',').includes(email)) {
        toAdd = email;
    }

    return (await fetch(host(`${endpoints.movies}/${id}`), {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
            'user-token': localStorage.getItem('userToken')
        },
        body: JSON.stringify({ likes: ++movie.likes, people: movie.people += toAdd })
    })).json();
}