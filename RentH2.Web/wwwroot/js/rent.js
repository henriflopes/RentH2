var datePickerValue;

$(function () {
	$("#datepicker").datepicker({
		dateFormat: "yy-mm-dd",
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