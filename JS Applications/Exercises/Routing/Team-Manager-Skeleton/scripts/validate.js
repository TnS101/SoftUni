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