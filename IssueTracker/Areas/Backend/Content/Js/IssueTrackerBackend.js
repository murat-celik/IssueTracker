function managerCreateTeam() {

    ajax('Manager/CreateTeam', $('#manager-create-team').serialize(), function (data) {
        $("#list-group-teams").append('<li class="list-group-item"><a href="Team/Detail/' + data.ID + '">' + data.Name + '</a></li>');
        $("#team-modal").modal("hide");
        console.log(data);
    }, true, false);

}