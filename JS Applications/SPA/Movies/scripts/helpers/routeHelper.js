export function bulkGet(routes, action, context) {
    routes.split(', ').forEach(a => {
        context.get(a, action);
    });
}

export function mirror(route, get, post, context) {
    context.get(route, get);
    context.post(route, (ctx) => { post.call(ctx); });
}