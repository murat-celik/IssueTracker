﻿function managerCreateTeam() {
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
        $("#list-group-priorities").append('<li class="list-group-item"><a>' + data.Name + '</a> <label class="pull-right label" style="background-color:' + data.Color + '">Color</label></li>');
        $("#priority-modal").modal("hide");
    }, true, false);
}

function CreateTag() {
    ajax('/Backend/Tag/Create', $('#create-tag').serialize(), function (data) {
        $("#list-group-tags").append('<li class="list-group-item"><a>' + data.Name + '</a></li>');
        $("#tag-modal").modal("hide");
    }, true, false);
}

function CreateBoard() {

    ajax('/Backend/Board/Create', $('#create-board').serialize(), function (data) {
        $("#list-group-boards").append('<li class="list-group-item"><a href="Backend/Board/Details/' + data.ID + '">' + data.Name + '</a></li>');
        $("#list-group-coloumn > li").each(function (index, object) {
            ajax('/Backend/Column/Create', { BoardID: data.ID, StateID: $(this).data("state-id"), SortIndex: index }, function (Columndata) {

            }, true, false);
        });
    }, true, false);

    $("#board-modal").modal("hide");
}

function CreateIssue() {
    ajax('/Backend/Issue/Create', $('#create-issue').serialize(), function (data) {
        $("#issue-modal").modal("hide");
    }, true, false);
}

function ChangeColumn(IssueID, ColumnID) {
    ajax('/Backend/Issue/ChangeColumn', { IssueID: IssueID, ColumnID: ColumnID }, function (data) {
        $("#StateName_" + IssueID).text(data);
        $("#change-column-modal").modal("hide");
    }, true, false);
}

function LoadColumns(BoardID) {
    ajax('/Backend/Column/GetColumns/' + BoardID, { BoardID: BoardID }, function (data) {
        $("#ColumnID").html("");
        $.each(data, function (key, item) {
            $("#ColumnID").append('<option value="' + item.ID + '">' + item.State.Name + '</option>');
        });
    }, true, false);
}

function LoadPriorities() {
    ajax('/Backend/Priority/GetPriorities', {}, function (data) {

        $("#PriorityID").html("");
        $.each(data, function (key, item) {
            $("#PriorityID").append('<option value="' + item.ID + '">' + item.Name + '</option>');
        });
    }, true, false);
}

function ChangePriority(IssueID, PriorityID) {
    ajax('/Backend/Issue/ChangePriority', { IssueID: IssueID, PriorityID: PriorityID }, function (data) {
        $("#PriorityName_" + IssueID).text(data.Name);
        $("#PriorityColor_" + IssueID).attr("style", "color:" + data.Color);
        $("#change-priority-modal").modal("hide");
    }, true, false);
}

function LoadTypes() {
    ajax('/Backend/Type/GetTypes', {}, function (data) {
        $("#TypeID").html("");

        $.each(data, function (key, item) {
            $("#TypeID").append('<option value="' + item.ID + '">' + item.Name + '</option>');
        });

    }, true, false);
}

function ChangeType(IssueID, TypeID) {
    ajax('/Backend/Issue/ChangeType', { IssueID: IssueID, TypeID: TypeID }, function (data) {
        $("#TypeName_" + IssueID).text(data.Name);
        $("#change-type-modal").modal("hide");
    }, true, false);
}


function DeleteIssueTag(Element) {
    ajax('/Backend/IssueTag/Delete/' + $(Element).data("issue-tag-id"), {}, function (data) {
        $(Element).parent().remove();
    }, true, false);
}

function SetInProcess(Element,InProcess) {
    ajax('/Backend/Issue/SetInProcess/', { IssueID:$(Element).data("issue-id"), InProcess: InProcess  }, function (data) {
        $("#InProcess_" + $(Element).data("issue-id")).removeAttr("style");
        $("#NotInProcess_" + $(Element).data("issue-id")).removeAttr("style");

        if (InProcess==true) {
            $(Element).attr('style', 'color:green');
        } else {
            $(Element).attr('style', 'color:green');
        }
    }, true, false);
}