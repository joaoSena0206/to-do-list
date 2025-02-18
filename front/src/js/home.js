$(function () {
    const datePicker = flatpickr("#datepicker", {
        dateFormat: "m-d-Y H:i",
        enableTime: true,
    });

    const taskCompleteBtn = $(".taskCompleteBtn");
    const sectionCompletedTasks = $("#sectionCompletedTasks");
    const sectionIncompleteTasks = $("#sectionIncompleteTasks");

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
        if ($("#dropdownOptions").css("display") == "none") {
            $("#dropdownOptions").slideDown(300);

            $("#dropdownDays").children("span").addClass("rotate-180");
        } else {
            $("#dropdownOptions").slideUp(300);

            $("#dropdownDays").children("span").removeClass("rotate-180");
        }
    });

    $("#dropdownOptions")
        .children()
        .on("click", function (e) {
            $("#dropdownOptions")
                .children(`div[dayFilter=${$("#dropdownDays").children("p").attr("dayFilter")}]`)
                .removeClass("hidden");
            $("#dropdownDays").children("p").text(e.target.textContent);
            $("#dropdownDays").children("p").attr("dayFilter", e.target.getAttribute("dayFilter"));

            e.target.classList.add("hidden");

            $("#dropdownOptions").slideUp(300);
            $("#dropdownDays").children("span").removeClass("rotate-180");
        });

    taskCompleteBtn.on("click", function (e) {
        const task = $(this).parent();

        if (task.attr("completed") == "false") {
            $(this).addClass("bg-white/87");

            task.attr("completed", "true");
            task.slideUp(250, function () {
                $(this).detach().appendTo(sectionCompletedTasks).slideDown(250);
            });
        } else {
            $(this).removeClass("bg-white/87");

            task.attr("completed", "false");
            task.slideUp(250, function () {
                $(this).detach().appendTo(sectionIncompleteTasks).slideDown(250);
            });
        }
    });
});
