export function auth() {
    if (!localStorage.getItem('userToken')) {
        const message = 'You must be logged in!';
        alert(message);
        throw new Error(message);
    }
}

export function errors(result) {
    try {
        if (result.hasOwnProperty('errorData')) {
            const error = new Error();
            Object.assign(error, result);
            throw error;
        }
    } catch (error) {
        alert(error.message);
    }
}

export function fields(input) {
    if (Object.entries(input).some(v => v.length == 0)) {
        alert('All fields are required!');
        return;
    }
}