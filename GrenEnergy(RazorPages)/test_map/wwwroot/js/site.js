function test_K()
{
    $.ajax
         ({
             type: "POST",
             contentType: "application/json; charset=utf-8",
             url: "IndexModel.aspx/GetTest",
             success: (function (data) {
                 $('.description').html(data);
             }),
             error: (function () {
                 alert("Error occurred in server!");
             })
         });
}

function Call_fun(f)
{ i=f;}