// PLACE POSITIONING
const LEFT_INDENT = 202;
const TOP_INDENT_FOR_TOP_PLACES = -10;
const TOP_INDENT_FOR_BOTTOM_PLACES = 40;
const PLACE_WIDTH = 35;
const BETWEEN_OPPOSITE_PLACES = 29;
const BORDER_WIDTH = 5;
const BETWEEN_BORDER_AND_PLACES = 3;
const BETWEEN_ROOMS = BETWEEN_BORDER_AND_PLACES * 2 + PLACE_WIDTH * 2 + BETWEEN_OPPOSITE_PLACES + BORDER_WIDTH;

const NUM_PLACES_IN_COACH = 20;

console.log(BETWEEN_ROOMS);

let places = $('.containerPlace');
for (let place of places) {
    place = $(place);
    console.log(place.find('label')[0].textContent);
    let placeId = parseInt(place.find('label')[0].textContent) - 1;

    // top indent
    if (placeId % 2 == 1) {
        place.css('top', TOP_INDENT_FOR_TOP_PLACES + 'px');
    } else {
        place.css('top', TOP_INDENT_FOR_BOTTOM_PLACES + 'px');
    }

    // left indent
    let roomNumber = Math.floor(placeId / 4);
    if (isLeftPlace(placeId)) {
        place.css('left', LEFT_INDENT + BETWEEN_ROOMS * roomNumber);
    } else {
        place.css('left', LEFT_INDENT + BETWEEN_ROOMS * roomNumber + BETWEEN_OPPOSITE_PLACES + PLACE_WIDTH);
    }
}

function isLeftPlace(placeId) {
    return placeId % 4 == 0 || placeId % 4 == 1;
}






// COACH TYPE SELECTION
$(document).ready(function() {
    $('#platzcartCoaches').show();
    $('#kupeCoaches').hide();

    $("#platzcartBtn").click(function(){
        $(this).addClass('active');
        $('#kupeBtn').removeClass('active');

        $('#platzcartCoaches').show();
        $('#kupeCoaches').hide();
    });
    $("#kupeBtn").click(function(){
        $(this).addClass('active');
        $('#platzcartBtn').removeClass('active');

        $('#kupeCoaches').show();
        $('#platzcartCoaches').hide();
    });  
});