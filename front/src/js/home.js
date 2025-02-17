$(function () {
    const datePicker = flatpickr("#datepicker", {
        dateFormat: "m-d-Y",
    });

    $("#calendar").on("click", function () {
        datePicker.toggle();
    });

    $("#addTaskBtn").on("click", function () {
        $("#formTask").removeClass("hidden").addClass("flex");
    });

    $("#closeBtn").on("click", function () {
        $("#formTask").addClass("hidden").removeClass("flex");
    });
});
