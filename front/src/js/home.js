const datePicker = flatpickr("#datepicker", {
    dateFormat: "m-d-Y h:i K",
    time_24hr: false,
    minDate: "today",
    onChange: function (selectedDates, dateStr, instance) {
        let now = new Date();
        let selectedDate = selectedDates[0];

        if (!selectedDate) {
            return;
        }

        let selectedFormatted = instance.formatDate(selectedDate, "Y-m-d");
        let todayFormatted = instance.formatDate(now, "Y-m-d");

        if (selectedFormatted === todayFormatted) {
            instance.set("minTime", now.getHours() + ":" + now.getMinutes());
        } else {
            instance.set("minTime", "00:00");
        }
    },
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

$("#createTaskBtn").on("click", function () {
    const date = new Date();
    const dateTomorrow = new Date();
    dateTomorrow.setDate(date.getDate() + 1);

    const dateNowFull = `${String(date.getMonth() + 1).padStart(2, "0")}-${String(date.getDate()).padStart(
        2,
        "0"
    )}-${date.getFullYear()} ${String(date.getHours()).padStart(2, "0")}:${String(date.getMinutes()).padStart(2, "0")}`;
    const dateStringTomorrow = `${String(dateTomorrow.getMonth() + 1).padStart(2, "0")}-${String(
        dateTomorrow.getDate()
    ).padStart(2, "0")}-${dateTomorrow.getFullYear()} ${String(dateTomorrow.getHours()).padStart(2, "0")}:${String(
        dateTomorrow.getMinutes()
    ).padStart(2, "0")}`;

    let taskName = $("#inputTaskName").val();
    let taskDesc = $("#inputTaskName").val();
    let taskDateFull = $("#datepicker").val();
    let taskDate = taskDateFull.substring(0, taskDateFull.indexOf(" "));
    let taskDateTime = taskDateFull.substring(taskDateFull.indexOf(" ") + 1);
    let dateNow = dateNowFull.substring(0, dateNowFull.indexOf(" "));
    let isTaskDateToday = taskDate == dateNow;
    let isTaskDateTomorrow = taskDate == dateStringTomorrow.substring(0, dateStringTomorrow.indexOf(" "));
    let dateAttribute = isTaskDateToday ? "1" : isTaskDateTomorrow ? "2" : "3";
    let dayFilter = $("#dropdownDays").children("p").attr("dayFilter");

    if (dayFilter != dateAttribute) {
        $("#formTask").addClass("hidden").removeClass("flex");

        return;
    }

    let div = document.createElement("div");
    div.setAttribute("completed", "false");
    div.setAttribute("taskId", "1");
    div.setAttribute("date", dateAttribute);
    div = $(div);
    div.addClass("flex items-center space-x-3 bg-[#363636] rounded-sm px-2 py-3");
    div.html(`
            <div class="transition-colors duration-300 taskCompleteBtn border-[2px] border-white/87 w-[16px] h-[16px] rounded-full"></div>
            <div class="text-white">
                <h1 class="font-bold text-[15px]">${taskName}</h1>
                <h2 class="text-[15px] text-[#AFAFAF]">${taskDesc}</h2>
                <h2 class="text-[13px] text-[#ffffff]">${
                    dateAttribute == 1 || dateAttribute == 2
                        ? taskDateTime
                        : `${taskDate.replaceAll("-", "/")} at ${taskDateTime}`
                }</h2>
            </div>    
        `);
    div.children(".taskCompleteBtn").on("click", function (e) {
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

    sectionIncompleteTasks.append(div);
    $("#formTask").addClass("hidden").removeClass("flex");
});
