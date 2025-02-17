$(function () {
    const datePicker = flatpickr("#datepicker", {
        dateFormat: "d-m-Y",
    });

    $("#calendar").on("click", function() {
        datePicker.toggle();
    });
});
