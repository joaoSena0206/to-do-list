$(function () {
    const datePicker = flatpickr("#datepicker", {
        dateFormat: "m-d-Y H:i",
        enableTime: true,
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

    $("#dropdownDays").on("click", function () {
        if ($("#dropdownOptions").hasClass("hidden")) {
            $("#dropdownOptions").removeClass("hidden");
        }
        else
        {
            $("#dropdownOptions").addClass("hidden");
        }
    });
});
