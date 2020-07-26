import { auth } from './validate.js';

function host(endpoint) {
    return `https://api.backendless.com/15F27D8F-09C9-AC4A-FF88-3193BEE3C300/B91652D5-560C-49D4-B7B8-9D0FBB072BB4/${endpoint}`
}

const endpoints = {
    register: 'users/register',
    login: 'users/login',
    team: 'data/teams'
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

export async function createTeam(team) {
    auth();

    return (await fetch(host(endpoints.team), {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'user-token': localStorage.getItem('userToken')
        },
        body: JSON.stringify(team)
    })).json();
}

export async function logout() {
    auth();

    return (await fetch(host(), {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
    })).json();
}