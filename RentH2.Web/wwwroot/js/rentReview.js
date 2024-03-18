var dataTable;

function placeAnOrder(data){
    swal({
        title: "Você tem certeza?",
        text: "Você deseja efetuar a contratação?",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((confirm) => {
        if (confirm) {
            $('#jsonData').val(JSON.stringify(data));
            $('#orderDetailsForm').submit();
        }
    });
};