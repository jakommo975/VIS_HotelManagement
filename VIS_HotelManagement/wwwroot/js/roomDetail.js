function formatBookInfoDate(date) {
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

function startDateBookInfoChangeHandler(e) {
    let endDateInput = $("#bookInfo input[name='EndDate']");

    let startDate = new Date(e.target.value);

    let endDate = new Date(endDateInput.val());

    const formValues = {
        startDate: formatDate(startDate),
        endDate: formatDate(endDate),
        roomTypeId: $("#roomTypeId").val(),
        numberOfPersons: $("#numberOfPersonsSelect").val()
    }

    $.ajax({
        url: `/Room/RoomPrices?StartDate=${formValues.startDate}&EndDate=${formValues.endDate}&roomTypeId=${formValues.roomTypeId}&numberOfPersons=${formValues.numberOfPersons}`
    }).done(function (result) {
        console.log(result)
        $("#accomodationPrice").text(`${result.accomodationPrice} €`);
        $("#totalPrice").text(`${result.totalPrice} €`);
        $("#serviceFee").text(`${result.serviceFee} €`);
    });



    endDate.setDate(endDate.getDate() - 1);

    if (startDate > endDate) {
        startDate.setDate(startDate.getDate() + 1);
        let endDateString = formatDate(startDate);

        endDateInput.val(endDateString);
        endDateInput.attr("min", endDateString);
    }

    
}

function initDateBookInfoInputs() {

    let startDateInput = $("#bookInfo input[name='StartDate']");
    startDateInput.change((e) => {
        startDateBookInfoChangeHandler(e);
    });
}


function personsSelectChangeHandler(e) {
    const formValues = {
        startDate: $("#startDate").val(),
        endDate: $("#endDate").val(),
        roomTypeId: $("#roomTypeId").val(),
        numberOfPersons: e.target.value
    }

    $.ajax({
        url: `/Room/RoomPrices?StartDate=${formValues.startDate}&EndDate=${formValues.endDate}&roomTypeId=${formValues.roomTypeId}&numberOfPersons=${formValues.numberOfPersons}`
    }).done(function (result) {
        $("#accomodationPrice").text(`${result.accomodationPrice} €`);
        $("#totalPrice").text(`${result.totalPrice} €`);
        $("#serviceFee").text(`${result.serviceFee} €`);
    });
}

function endDateBookInfoChangeHandler(e) {
    let startDateInput = $("#bookInfo input[name='StartDate']");

    let endDate = new Date(e.target.value);

    let startDate = new Date(startDateInput.val());

    const formValues = {
        startDate: formatDate(startDate),
        endDate: formatDate(endDate),
        roomTypeId: $("#roomTypeId").val(),
        numberOfPersons: $("#numberOfPersonsSelect").val()
    }

    $.ajax({
        url: `/Room/RoomPrices?StartDate=${formValues.startDate}&EndDate=${formValues.endDate}&roomTypeId=${formValues.roomTypeId}&numberOfPersons=${formValues.numberOfPersons}`
    }).done(function (result) {
        $("#accomodationPrice").text(`${result.accomodationPrice} €`);
        $("#totalPrice").text(`${result.totalPrice} €`);
        $("#serviceFee").text(`${result.serviceFee} €`);
    });
}


window.addEventListener("load", function () {
    $("#numberOfPersonsSelect").change(personsSelectChangeHandler);
    $("#bookInfo input[name='EndDate']").change(endDateBookInfoChangeHandler);
});

window.addEventListener("load", initDateBookInfoInputs)