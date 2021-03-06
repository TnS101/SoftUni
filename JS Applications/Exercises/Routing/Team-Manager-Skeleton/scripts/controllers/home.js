export default async function() {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
    };

    // Render get requests without BL
    this.partial('./templates/home/home.hbs', this.app.userData);
}