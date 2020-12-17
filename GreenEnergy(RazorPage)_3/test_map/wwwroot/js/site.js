function refreshDesc() {
    $('.description').html("");   
    $('.for_config').html("");
}



function findRegion(id) {
    var name = id;
    $.ajax({
        type: 'GET',
        url: '?handler=FindRaion',
        data: { name },
        success: function (data) {
            $('.for_config').html(data);
        },
        error: function (error) {
            alert("Error: " + error);
        }
    })
}

function findUsers(id) {
    var name = id;
    $.ajax({
        type: 'GET',
        url: '?handler=FindUser',
        data: { name },
        success: function (data) {
            $('.description').html(data);
        },
        error: function (error) {
            alert("Error: " + error);
        }
    })
}

