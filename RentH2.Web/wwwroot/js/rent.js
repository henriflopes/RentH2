var datePickerValue;

$(function () {
	$("#datepicker").datepicker({
		showOn: "focus",
		dateFormat: "yy-mm-dd",
		dayNames: ["Domingo", "Segunda", "Terça", "Quarta", "Quinta", "Sexta", "Sábado"],
		dayNamesMin: ["Dom", "Seg", "Ter", "Qua", "Qui", "Sex", "Sab"],
		monthNames: ['Janeiro', 'Fevereiro', 'Março', 'Abril', 'Maio', 'Junho', 'Julho', 'Agosto', 'Setembro', 'Outubro', 'Novembro', 'Dezembro'],
		onSelect: function (dateText, inst) {
			datePickerValue =  dateText;
		}
	});
});


document.getElementById('btnPlan').addEventListener('click', function () {
	loadClick();
});

function loadClick() {
	if (datePickerValue == null) {
		toastr.error('É necessário selecionar uma data!');
	}
	else {
		window.location.href = 'Rent/SelectPlan?startDate=' + datePickerValue;
	}
}