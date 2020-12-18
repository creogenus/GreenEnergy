var regionID;

function refreshDesc(nameR) {
    $('.description').html("");   
    $('.for_config').html("");
    regionID = nameR;
}



function findRegion(province_id) {
    let str = province_id + "|" + regionID;
    var name = str;
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

function findUsers(province_id) {
    let str = province_id + "|" +regionID;
    var name = str;
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

