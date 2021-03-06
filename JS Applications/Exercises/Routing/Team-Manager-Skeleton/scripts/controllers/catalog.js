import { createTeam, getTeams, getDetails, updateTeam } from '../data.js';
import * as validate from '../validate.js';

export async function details() {
    validate.auth();

    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
        teamControls: await this.load('./templates/catalog/teamControls.hbs'),
        teamMember: await this.load('./templates/catalog/teamMember.hbs'),
    };

    const data = await getDetails(this.params.id);
    Object.assign(data, this.app.userData);

    if (data.ownerId === this.app.userData.userId) {
        data.isAuthor = true;
    }
    if (data.objectId === this.app.userData.teamId) {
        data.isOnTeam = true;
    }

    this.partial('./templates/catalog/details.hbs', data);
}

export async function main() {
    validate.auth();

    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
        team: await this.load('./templates/catalog/team.hbs'),
    };
    const data = Object.assign({}, this.app.userData);
    data.teams = await getTeams();

    this.partial('./templates/catalog/teamCatalog.hbs', data);
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
    validate.errors(result);
    this.redirect(`#/catalog/${result.objectId}`);
}

export async function edit() {
    validate.auth();

    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
        editForm: await this.load('./templates/edit/editForm.hbs')
    }

    const data = Object.assign({}, this.app.userData);
    data.id = this.params.id;
    this.partial('./templates/edit/editPage.hbs', data);
}

export async function editPost() {
    validate.auth();

    const editTeam = {
        name: this.params.name,
        comment: this.params.comment
    }

    if (Object.entries(editTeam).some(v => v.length == 0)) {
        alert('All fields are required!');
        return;
    }

    const result = await updateTeam(this.params.id, editTeam);

    validate.errors(result);
    this.redirect('#/catalog');
}