var dataTable;

$(document).ready(() => {
    loadDataTable();
});

function deleteQuestion(id) {
    swal({
        title: "Você tem certeza?",
        text: "Você tem certeza que quer deletar este pedido?",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((confirm) => {
        if (confirm) {
            $('#Id').val(id);
            $('#deleteForm').submit();
        }
    });
};

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        columnDefs: [
            {
                targets: 0,
                className: 'dt-center'
            },
            {
                targets: 1,
                render: DataTable.render.number('.', ',', 2, 'R$ '),
                className: 'dt-center'
            },
            {
                targets: 2,
                render: DataTable.render.moment("YYYY-MM-DDTHH:mm:ss.SSS-03:00", "DD/MM/YYYY HH:mm:ss"),
                className: 'dt-center'
            },
            {
                targets: 3,
                className: 'dt-center'
            },
            {
                targets: 4,
                className: 'dt-center'
            }
        ],
        language: {
            "info": 'Exibindo páginas _PAGE_ de _PAGES_',
            "infoEmpty": 'Nenhum informação disponível',
            "infoFiltered": '(filtrado de _MAX_ registros)',
            "lengthMenu": 'Mostrando _MENU_ registros por página',
            "zeroRecords": 'Nenhuma informação encontrada',
            "loadingRecords": "Carregando...",
            "processing": "",
            "search": "Procurar:",
            "paginate": {
                "first": "Primeiro",
                "last": "Último",
                "next": "Próximo",
                "previous": "Anterior"
            },
        },
        order: [[0, 'desc']],
        "ajax": { url: "/order/getall" },
        "columns": [
            { data: 'id', "width": "30%" },
            {
                data: 'shippingTax',
                "width": "25%"
            },
            { data: 'timestamp', "width": "20%" },
            { data: 'status', "width": "15%" },
            {
                data: 'id',
                "render": function (data) {
                    return '<div class="w-55 btn-group text-center" role="group">' +
                        '<a href="/order/OrderEdit?id=' + data + '" class="btn btn-primary mx-2"><i class="bi bi-pencil-square" style="color:#63E6BE;"></i></a>' +
                        '<a onclick="deleteQuestion(\'' + data + '\')" class="btn btn-primary mx-2"><i class="bi bi-trash" style="color:#ff0550;"></i></a>' +
                        '</div>'
                },
                "width": "10%"
            }
        ]
    })
}