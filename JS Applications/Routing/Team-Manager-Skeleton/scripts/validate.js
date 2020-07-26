export function auth(e) {
    if (!localStorage.getItem('userToken')) {
        const message = 'You must be logged in!';
        alert(message);
        throw new Error(message);
    }
}

export function errors(result, redirect) {
    try {
        if (result.hasOwnProperty('errorData')) {
            const error = new Error();
            Object.assign(error, result);
            throw error;
        }
        this.redirect(redirect);
    } catch (error) {
        alert(error.message);
    }
}