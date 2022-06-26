var dataTable;
$(function () {
    GetDataCreateTable();
});
function GetDataCreateTable() {
    AjaxServiceRequest({ url: "/Datatable/GetUserList", type: 'POST', data: "" }).done(function (UserDataList) {

        let columns = [];
        let columnItem;
        for (let i = 0; i < UserDataList.columns.length; i++) {
            columnItem = UserDataList.columns[i];
            columns.push({
                width: "20%",
                data: {
                    _: camelize(columnItem.prop),
                    sort: camelize(columnItem.prop),
                },
                title: columnItem.title,
                render: function (data, type, full, meta) {
                    return data;
                }
            });
        }
        $("#dtUserData").DataTable({
            data: UserDataList.data,
            columns: columns,
            responsive: true
        });

    });
}
function camelize(str) {
    return str.replace(/(?:^\w|[A-Z]|\b\w)/g, function (word, index) {
        return index === 0 ? word.toLowerCase() : word.toUpperCase();
    }).replace(/\s+/g, '');
}

//ajax requestler için yapıdı reqParams objesinde data ile post edilecek data, servis url için url, post,get için type, async durumu için async, data taşınması için Additional property'leri bulunmaktadır.
function AjaxServiceRequest(reqParams) {
    var postdata = typeof reqParams.data != "string" ? JSON.stringify(reqParams.data) : reqParams.data;
    return $.ajax({
        url: reqParams.url,
        type: reqParams.type,
        data: postdata,
        contentType: 'application/json; charset=utf-8',
        async: reqParams.async || true,
        additionalParams: reqParams.Additional
    });
}