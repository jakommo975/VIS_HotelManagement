function formatDate(date) {
    var d = date,
        month = '' + (d.getMonth() + 1),
        day = '' + d.getDate(),
        year = d.getFullYear();

    if (month.length < 2)
        month = '0' + month;
    if (day.length < 2)
        day = '0' + day;

    return [year, month, day].join('-');
}

function startDateChangeHandler(e) {
    let endDateInput = $(".seachr-bar-wrapper input[name='EndDate']");

    let startDate = new Date(e.target.value);

    let endDate = new Date(endDateInput.val());

    endDate.setDate(endDate.getDate() - 1);

    if (startDate > endDate) {
        startDate.setDate(startDate.getDate() + 1);
        let endDateString = formatDate(startDate);

        endDateInput.val(endDateString);
        endDateInput.attr("min", endDateString);
    }


}

function initDateInputs() {
    /*
    let startDate = new Date();
    let startDateString = formatDate(startDate);
    startDate.setDate(startDate.getDate() + 1);
    let endDateString = formatDate(startDate);
    */

    let startDateInput = $(".seachr-bar-wrapper input[name='StartDate']")
    //startDateInput.val(startDateString);
    //startDateInput.attr("min", startDateString);
    startDateInput.change((e) => {
        startDateChangeHandler(e);
    });

    /*
    let endDateInput = $("[name='EndDate']");
    endDateInput.val(endDateString);
    endDateInput.attr("min", endDateString);
    */
}

window.addEventListener("load", initDateInputs)


window.addEventListener("load", () => {
    $("#searchIcon").click(() => {
        console.log($(this));
        $("#searchForm").submit();
    });

    
});