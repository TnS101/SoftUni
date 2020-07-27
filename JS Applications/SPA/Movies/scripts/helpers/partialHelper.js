export function render(route, context, data) {
    return data == undefined ? context.partial(route, context.app.userData) : context.partial(route, Object.assign(data, context.app.userData));
}

export async function headers(context) {
    context.partials = {
        header: await context.load('./templates/common/header.hbs'),
        footer: await context.load('./templates/common/footer.hbs'),
    };
}