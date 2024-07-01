
$(document).ready(function () {
    $('table').dataTable({
        pageLength: '2',//預設為'10'，若需更改初始每頁顯示筆數，才需設定
        fixedHeader: {
            header: true,
        },
        language: {
            url: '//cdn.datatables.net/plug-ins/2.0.8/i18n/zh-HANT.json',
        },
        responsive: true,
        columnDefs: [
            {
                targets: "_all",
                width: "20%", // 設定寬度
                className: "text-center",// 新增class...等其他參數
            }
        ],


    });
});