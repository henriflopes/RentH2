var dataTable;

function placeAnOrder(data) {
    const jsonData = JSON.stringify(data);
    const inputValue = data.Total.toString().replace(/[^0-9]/g, '');
    const formattedValue = (parseInt(inputValue)).toLocaleString('pt-BR', {
        style: 'currency',
        currency: 'BRL'
    });

    swal({
        title: "Você tem certeza?",
        text: "O valor cobrado será de " + formattedValue + "! \nVocê deseja encerrar está locação?",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((confirm) => {
        if (confirm) {
            $('#jsonData').val(jsonData);
            $('#rentUserDetailsForm').submit();
        }
    });
};