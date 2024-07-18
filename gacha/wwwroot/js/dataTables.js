$(document).ready(function () {
    $('table').DataTable({
        // pageLength: '2',//預設為'10'，若需更改初始每頁顯示筆數，才需設定
        fixedHeader: {
            header: true,
        },
        language: {
            url: '//cdn.datatables.net/plug-ins/2.0.8/i18n/zh-HANT.json',
        },
        columnDefs: [
            {
                targets: '_all',
                className: 'text-center',
            }
        ],
    });
    // 換頁時回到最上面
    $('table').on('page.dt', function () {
        $('html, body').animate({
            scrollTop: $(".dataTables_wrapper").offset().top
        }, 50);
    });
});