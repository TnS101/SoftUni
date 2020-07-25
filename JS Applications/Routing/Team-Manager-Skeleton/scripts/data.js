function host(endpoint) {
    return `https://api.backendless.com/15F27D8F-09C9-AC4A-FF88-3193BEE3C300/B91652D5-560C-49D4-B7B8-9D0FBB072BB4/${endpoint}`
}

const endpoints = {
    register: 'users/register',
    login: 'users/login',
}

export async function register(username, password, repeatPassword) {
    return (await fetch(host(endpoints.register), {
        method: 'POST',
        headers: {
            'Content-Type': 'application.json'
        },
        body: JSON.stringify({
            email: username,
            password: password
        })
    })).json();
}

export function login(username, password) {

}