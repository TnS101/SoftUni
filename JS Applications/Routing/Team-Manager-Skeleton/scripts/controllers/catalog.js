import { createTeam } from '../data.js';
import * as validate from '../validate.js';

export async function details() {
    validate.auth();

    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
        teamControls: await this.load('./templates/catalog/teamControls.hbs'),
        teamMember: await this.load('./templates/catalog/teamMember.hbs'),
    };

    this.partial('./templates/catalog/details.hbs', this.app.userData);
}

export async function main() {
    validate.auth();

    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
        team: await this.load('./templates/catalog/team.hbs'),
    };
    this.partial('./templates/catalog/teamCatalog.hbs', this.app.userData);
}

export async function create() {
    validate.auth();

    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
        createForm: await this.load('./templates/create/createForm.hbs')
    }

    this.partial('./templates/create/createPage.hbs', this.app.userData);
}

export async function createPost() {
    const newTeam = {
        name: this.params.name,
        comment: this.params.comment
    }

    if (Object.entries(newTeam).some(v => v.length == 0)) {
        alert('All fields are required!');
        return;
    }

    const result = await createTeam(newTeam);
    validate.errors(result, `#/details/:${result.objectId}`);
}

export async function edit() {
    validate.auth();

    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
        editForm: await this.load('./templates/edit/editForm.hbs')
    }

    this.partial('./templates/edit/editPage.hbs', this.app.userData);
}

export async function editPost() {

}