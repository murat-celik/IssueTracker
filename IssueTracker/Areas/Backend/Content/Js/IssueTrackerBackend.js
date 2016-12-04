function managerCreateTeam() {
    ajax('Manager/CreateTeam', $('#manager-create-team').serialize(), function (data) {
        $("#list-group-teams").append('<li class="list-group-item"><a href="/Backend/Team/Details/' + data.ID + '">' + data.Name + '</a></li>');
        $("#team-modal").modal("hide");
    }, true, false);
}

function CreateProject() {
    ajax('/Backend/Project/Create', $('#create-project').serialize(), function (data) {
        $("#list-group-projects").append('<li class="list-group-item"><a href="/Backend/Project/Details/' + data.ID + '">' + data.Name + '</a></li>');
        $("#project-modal").modal("hide");
    }, true, false);
}

function CreateState() {
    ajax('/Backend/State/Create', $('#create-state').serialize(), function (data) {
        $("#list-group-states").append('<li class="list-group-item"><a>' + data.Name + '</a></li>');
        $("#state-modal").modal("hide");
    }, true, false);
}

function CreateType() {
    ajax('/Backend/Type/Create', $('#create-type').serialize(), function (data) {
        $("#list-group-types").append('<li class="list-group-item"><a>' + data.Name + '</a></li>');
        $("#type-modal").modal("hide");
    }, true, false);
}

function CreatePriority() {
    ajax('/Backend/Priority/Create', $('#create-priority').serialize(), function (data) {
        $("#list-group-priorities").append('<li class="list-group-item"><a>' + data.Name + '</a> <label class="pull-right label" style="background-color:'+data.Color+'">Color</label></li>');
        $("#priority-modal").modal("hide");
    }, true, false);
}
function CreateTag() {
    ajax('/Backend/Tag/Create', $('#create-tag').serialize(), function (data) {
        $("#list-group-tags").append('<li class="list-group-item"><a>' + data.Name + '</a></li>');
        $("#tag-modal").modal("hide");
    }, true, false);
}
