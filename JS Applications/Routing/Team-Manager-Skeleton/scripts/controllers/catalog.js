export async function details() {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
        teamControls: await this.load('./templates/catalog/teamControls.hbs'),
        teamMember: await this.load('./templates/catalog/teamMember.hbs'),
    };

    const data = {
        _id: '123',
        name: 'Some Name',
        comment: 'Komentar',
        members: [
            { username: 'Pesho' },
            { username: 'Goshko' }
        ]
    };

    Object.assign(data, this.app.userData);

    this.partial('./templates/catalog/details.hbs', data);
}

export async function main() {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
        team: await this.load('./templates/catalog/team.hbs'),
    };
    this.partial('./templates/catalog/teamCatalog.hbs', this.app.userData);
}

export async function create() {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
        createForm: await this.load('./templates/create/createForm.hbs')
    }

    this.partial('./templates/create/createPage.hbs', this.app.userData);
}

export async function edit() {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
        editForm: await this.load('./templates/edit/editForm.hbs')
    }

    this.partial('./templates/edit/editPage.hbs', this.app.userData);
}