$('#gold').click(function (e) {
    e.preventDefault();
    $('.bubbles span:odd').css('background-color', '#fdd114');
    $('.bubbles span:odd').css('box-shadow', '0 0 0 10px #fdd11444,0 0 50px #fdd114,0 0 100px #fdd114');

    $('.bubbles span:even').css('background-color', '#2f00f9');
    $('.bubbles span:even').css('box-shadow', '0 0 0 10px #2f00f944,0 0 50px #2f00f9,0 0 100px #2f00f9');
    
    $('.landing').css('background', ' linear-gradient(-200deg, #fdd118 0%,#0e004a 30%, #0b003d 88%)')

    $('.container').addClass('gold');
    $('.container').removeClass('day');
    $('.container').removeClass('dark');

    $('img').remove();
    $('.inputs i').css('color', '#fdd114');
});
$('#day').click(function (e) {
    e.preventDefault();
    $('.bubbles span:even').css('background-color', '#ff2d75');
    $('.bubbles span:even').css('box-shadow', ' 0 0 0 10px  #ff2d7544,0 0 50px  #ff2d75,0 0 100px  #ff2d75');

    $('.bubbles span:odd').css('background-color', '#4fc3dc');
    $('.bubbles span:odd').css('box-shadow', '0 0 0 10px #4fc3dc44,0 0 50px #4fc3dc,0 0 100px #4fc3dc');

    $('.container').addClass('day');
    $('.container').removeClass('gold');
    $('.container').removeClass('dark');

    $('.landing').css('background', 'linear-gradient(-211deg, rgb(71, 59, 123) 25%, rgb(53, 132, 167) 66%, rgb(48, 210, 190) 88%)');
    $('img').remove();
    $('.inputs i').css('color', '#ff2d75');
});
$('#dark').click(function (e) {
    e.preventDefault();
    $('.bubbles span').css('background-color', '#FFFFFF');
    $('.bubbles span').css('box-shadow', ' 0 0 0 10px #FFFFFF44, 0 0 50px #FFFFFF,0 0 100px #FFFFFF');

    $('.container').addClass('dark');
    $('.container').removeClass('gold');
    $('.container').removeClass('day');

    $('.landing').css('background', 'linear-gradient(-211deg, #ffffff 0%, #050531 15%, #02023D 100%)')
    $('<img src="—Pngtree—the surface of a round_5955908.png" class="position-absolute darkimg" alt="">').appendTo('body');
    $('.inputs i').css('color', '#050531');
});