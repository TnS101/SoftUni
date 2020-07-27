export async function headers(context) {
    context.partials = {
        header: await context.load('./templates/common/header.hbs'),
        footer: await context.load('./templates/common/footer.hbs'),
    };
}

export function render(input, context, data) {
    const path = `./templates/${input}.hbs`;
    return data == undefined ? context.partial(path, context.app.userData) : context.partial(path, Object.assign(data, context.app.userData));
}