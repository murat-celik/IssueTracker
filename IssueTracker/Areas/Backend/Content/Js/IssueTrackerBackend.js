function managerCreateTeam() {

    ajax('CreateTeam', $('#manager-create-team').serialize(), function (data) {

        console.log(data);

    }, true, false);
}