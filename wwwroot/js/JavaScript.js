$(document).ready(function () {
    
    new DataTable('#mytable');
    FetchManagersList();
});

$("#add").click(function () {
    $("#exampleModal").modal('show');
});

$("#savebtn").click(function () {
    var obj = $("#managerform").serialize();

    $.ajax({
        url: '/Ajax/AddManager',
        type: 'POST',
        data: obj,
        dataType: 'json',
        success: function () {
            alert("Manager Added Success");
            FetchManagersList();
            $("#exampleModal").modal('hide');
        },
        error: function () {
            alert("Something is wrong");
        }
    });
});

/*
Manager_Id = managerId
ManagerId = managerId
ManagerEmpId=managerEmpId
*/
function FetchManagersList() {
    $.ajax({
        url: '/Ajax/FetchManagers',
        type: 'Get',
        dataType: 'json',
        success: function (res) {
            var obj = '';
            $.each(res, function (index, item) {
                obj += '<tr>';
                obj += '<td>' + item.mid + '</td>';
                obj += '<td>' + item.mname + '</td>';
                obj += '</tr>';
            });
            $("#managerdata").html(obj);
        },
        error: function () {
            alert("wrong");
        }
    });
}

$("#str").keyup(function () {
    var str = $("#str").val();

    $.ajax({
        url: '/Ajax/SearchManagers?name='+str,
        type: 'Get',
        dataType: 'json',
        success: function (res) {
            var obj = '';
            $.each(res, function (index, item) {
                obj += '<tr>';
                obj += '<td>' + item.mid + '</td>';
                obj += '<td>' + item.mname + '</td>';
                obj += '</tr>';
            });
            $("#managerdata").html(obj);
        },
        error: function () {
            alert("wrong");
        }
    });
});