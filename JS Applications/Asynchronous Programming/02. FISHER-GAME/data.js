function host(endpoint) {
    if (endpoint === undefined) {
        return 'http://localhost:8000/fishergame';
    } else {
        return `http://localhost:8000/fishergame/catches/${endpoint}.json`;
    }
}

export async function getData() {
    return (await fetch(host())).json();
}

export function deleteEntry(id) {
    return fetch(host(id), {
        method: 'DELETE'
    });
}

export async function createEntry(entry) {
    return (await fetch(host(), {
        method: 'POST',
        body: JSON.stringify(entry)
    })).json();
}