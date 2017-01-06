//***** DATEPICKER FOR DATE *****//
$(document).ready(function () {
    $('#dateRangePicker')
        .datepicker({
            clearBtn: true,
            language: "sv",
            calendarWeeks: true,
            autoclose: true,
            todayHighlight: true,
            format: 'yyyy-mm-dd'
        });
});