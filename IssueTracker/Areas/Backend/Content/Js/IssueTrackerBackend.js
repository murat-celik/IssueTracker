function managerCreateTeam() {
    ajax('Manager/CreateTeam', $('#manager-create-team').serialize(), function (data) {
        $("#list-group-teams").append('<li class="list-group-item"><a href="/Backend/Team/Details/' + data.ID + '">' + data.Name + '</a></li>');
        $("#team-modal").modal("hide");
        console.log(data);
    }, true, false);
}

function CreateProject() {
    ajax('/Backend/Project/Create', $('#create-project').serialize(), function (data) {
        $("#list-group-projects").append('<li class="list-group-item"><a href="/Backend/Project/Details/' + data.ID + '">' + data.Name + '</a></li>');
        $("#project-modal").modal("hide");
        console.log(data);
    }, true, false);
}