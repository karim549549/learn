$(document).ready(function () {
    $('.landing .container').animate({
        opacity: '1',
        'margin-top': '0',
    }, 800);
});
/******animations***********/
$('.togglebtn1').click(function (e) {
    e.preventDefault();
    toggleForm('.toggleform1');
});
$('.togglebtn2').click(function (e) {
    e.preventDefault();
    toggleForm('.toggleform2');
});
$('.togglebtn3').click(function (e) {
    e.preventDefault();
    toggleForm('.toggleform3');
});
$('.togglebtn4').click(function (e) {
    e.preventDefault();
    toggleForm('.toggleform4');
});
/**************Toggles ***************/
function toggleForm(formClass) {
    if ('.toggleform1' != formClass) {
        $('.toggleform1').slideUp(500);
    }
    if ('.toggleform2' != formClass) {
        $('.toggleform2').slideUp(500);
    }
    if ('.toggleform3' != formClass) {
        $('.toggleform3').slideUp(500);
    }
    if ('.toggleform4' != formClass) {
        $('.toggleform4').slideUp(500);
    }
    $(formClass).slideToggle(500);
}
/**************Toggles***************/





/************validations*************/
function validateDate(startDate, endDate, formClass) {
    var currentDate = new Date();
    if (startDate < currentDate || endDate <= startDate) {
        errorMessage(startDate, endDate, formClass);
        return false;
    }
    RemoveErrorMessage();
    return true;
}
/************validations**************/











$(".toggleform2 form").submit(function (event) {
    event.preventDefault();
    var startDate = new Date($(".toggleform2 input[type='date']").eq(0).val());
    var endDate = new Date($(".toggleform2 input[type='date']").eq(1).val());

    if (validateDate(startDate, endDate, '.toggleform2')) {
        /* processForm('.toggleform2', $(".toggleform2 select option:selected").val(), $(".toggleform2 select option:selected").text());*/
        processForm('.toggleform2', startDate, endDate);
    }
});

$(".toggleform1 form").submit(function (event) {
    event.preventDefault();
    var startDate = new Date($(".toggleform1 input[type='date']").eq(0).val());
    var endDate = new Date($(".toggleform1 input[type='date']").eq(1).val());

    if (validateDate(startDate, endDate, '.toggleform1')) {
        processForm('.toggleform1', startDate, endDate);
    }
});

$(".toggleform3 form").submit(function (event) {
    event.preventDefault();
    var startDate = new Date($(".toggleform3 input[type='date']").eq(0).val());
    var endDate = new Date($(".toggleform3 input[type='date']").eq(1).val());

    if (validateDate(startDate, endDate, '.toggleform3')) {
        processForm('.toggleform3', startDate, endDate, 500);
    }
});

$(".toggleform4 form").submit(function (event) {
    event.preventDefault();
    var startDate = new Date($(".toggleform4 input[type='date']").eq(0).val());
    var endDate = new Date($(".toggleform4 input[type='date']").eq(1).val());

    if (validateDate(startDate, endDate, '.toggleform4')) {
        processForm('.toggleform4', startDate, endDate, 1);
    }
});



function processForm(formClass, startDate, endDate) {
    var currentDate = new Date();
    var days = Math.ceil((endDate.getTime() - startDate.getTime()) / (1000 * 60 * 60 * 24));
    if (formClass === '.toggleform1') {
        addOrder('Car Rental',
            currentDate.toLocaleDateString(),
            `Model: ${$(".toggleform1 select option:selected").text()}`,
            `For: ${days} Days`,
            cost);
    }
    else if (formClass === '.toggleform2') {
        var cost = $('.toggleform2 input[type="number"]').val() * $('.toggleform2 select').val();
        addOrder(
            'Flights',
            currentDate.toLocaleDateString(),
            `Tickets: ${$(".toggleform2 input[type='number']").val()}`,
            `Class: ${$('.toggleform2 select option:selected').text()}`,
            cost
        );
    }

    else if (formClass === '.toggleform3') {
        addOrder(
            'Crusies',
            currentDate.toLocaleDateString(),
            `Localation: Nile Cruise`,
            `Passangers: ${$('.toggleform3 input[type="number"]').val()}`,
            `${$('.toggleform3 input[type="number"]').val() * 500 * days}`
        );
    }

    else if (formClass === '.toggleform4') {
        var cost = days * $('.toggleform4 select').val();
        addOrder('Hotel',
            currentDate.toLocaleDateString(),
            `Type: ${$(".toggleform4 select option:selected").text()}`,
            `For: ${days} Days`,
            cost);

    }
    updateTotals();
}

function addOrder(span1, span2, span3, span4, span5) {
    $('.orders').append(`
    <div class="order  pad1  ">
    <div class="row">
        <span class="col">${span1}</span>
        <span  class="col">Date:${span2}</span>
        <span  class="col">${span3}</span>
        <span  class="col">${span4}</span>
        <span  class="col">EGP ${span5}.00</span>
    </div>
    </div>
    `);
}


function updateTotals() {
    var orders = $('.orders .order');
    var subtotal = 0;
    orders.each(function () {
        var ordercost = $(this).find('span:last').text().replace(/[^\d.]/g, '');
        var totalCost = parseFloat(ordercost);
        subtotal += totalCost;
    });

    $('.subTotal').text(`EGP ${subtotal.toFixed(2)}`);
    $('.Fee').text(` EGP ${(0.14 * subtotal).toFixed(2)}`);
    $('.Total').text(` EGP ${((0.14 * subtotal) + subtotal).toFixed(2)}`);
}

function errorMessage(startDate, endDate, formClass) {
    $('.alert').remove();
    $(formClass).prepend(`
    <div class="alert text-center" role="alert">
    U can not Reserve In  ${startDate.toLocaleDateString()} to ${endDate.toLocaleDateString()}
    </div>
    `);
}

function RemoveErrorMessage() {
    $('.alert').fadeOut(1000);
    $('.alert').hide();
}
