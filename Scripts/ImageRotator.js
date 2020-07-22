// JavaScript source code
$("input:radio[value='1']").prop('checked', true);
jQuery(function($){
    var slider = $("#jquery-slideshow"),
        item_width = slider.parent().outerWidth();
    var currLocation = 1;
    var prevLocation = undefined;
    var interval = 'Henry';

    // Adjust the slider when/if the window gets resized

    // We have more than one slide,
    // let's add the pagination buttons
    if (slider.children("li").length > 1) {
        //prevLocation = currLocation;
        //currLocation = $(this).attr("value");
        //autoRotate(currLocation, prevLocation);
        $("input").on("click", function () {
            prevLocation = currLocation;
            currLocation = $(this).attr("value");
            console.log(currLocation);
            
            if (currLocation > prevLocation) {
                var numForward = currLocation - prevLocation;
                while (numForward) {
                    forward();
                    numForward--;
                }
            } else {
                var numBackward = currLocation - prevLocation;
                while (numBackward) {
                    backward();
                    numBackward++;
                }
            }
        })
        
    }

    
    // Helpers
    function forward() {
        slider.animate({
            left: -item_width
        }, 300, "swing", function () {
            slider.children().next().prependTo(slider);
            slider.css("left", 0);
        });
    }

    function backward() {
        slider.animate({
            left: item_width
        }, 300, "swing", function () {
            slider.children("li:last").prependTo(slider);
            slider.css("left", 0);
        });
    }

    function autoRotate(currentLocation, previousLocation) {
        var value = $("input").attr("value");
        interval = setInterval(function (currentLocation, previousLocation) {
            while (currentLocation > prevLocation) {

            }
            /* Find element that is radio button and use .checked = true
             * Currlocation + 1 for da rotation and if at last radio button modulus 4 + 1
            /* Call the forward() function and increment the value of the checked radio button by 1 */
        }, 3000)
        previousLocation = currentLocation;
        currentLocation = currentLocation + 1;
    }

});
