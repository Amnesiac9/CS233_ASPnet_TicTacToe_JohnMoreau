// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



// SOURCE: https://stackoverflow.com/questions/29911143/how-can-i-animate-the-drawing-of-text-on-a-web-page

// My Edits:
// Added function name and parameters (id, letter, speed, color)
// Changed strokeText arguments y axis to 72 to center text

// Nice red: #821e1e
// BlueGreen: #30665c
// Green: #306644


function drawLetters(id, letter, speed) {

    var ctx = document.getElementById(id).getContext("2d"),
        dashLen = 220, dashOffset = dashLen, //speed = 5,
        txt = letter, x = 30, i = 0;


        
    var color = letter == "X" ? "#821e1e" : "#306644";

    ctx.font = "50px Comic Sans MS, cursive, TSCu_Comic, sans-serif";
    ctx.lineWidth = 5; ctx.lineJoin = "round"; ctx.globalAlpha = 2 / 3;
    ctx.strokeStyle = ctx.fillStyle = color;

    (function loop() {
        ctx.clearRect(x, 0, 60, 150);
        ctx.setLineDash([dashLen - dashOffset, dashOffset - speed]); // create a long dash mask
        dashOffset -= speed;                                         // reduce dash length
        ctx.strokeText(txt[i], x, 72);                               // stroke letter

        if (dashOffset > 0) requestAnimationFrame(loop);             // animate
        else {
            ctx.fillText(txt[i], x, 72);                               // fill final letter
            dashOffset = dashLen;                                      // prep next char
            x += ctx.measureText(txt[i++]).width + ctx.lineWidth * Math.random();
            ctx.setTransform(1, 0, 0, 1, 0, 3 * Math.random());        // random y-delta
            ctx.rotate(Math.random() * 0.005);                         // random rotation
            if (i < txt.length) requestAnimationFrame(loop);
        }
    })();
}



//function drawLetter(id, letter, speed) {
//    var ctx = document.getElementById(id).getContext("2d"),
//        dashLen = 220, dashOffset = dashLen //speed = 5,
//        txt = letter, x = 30, i = 0;

//    var color = letter == "X" ? "#821e1e" : "#306644";
    

//    ctx.font = "50px Comic Sans MS, cursive, TSCu_Comic, sans-serif";
//    ctx.lineWidth = 5; ctx.lineJoin = "round"; ctx.globalAlpha = 2 / 3;
//    ctx.strokeStyle = ctx.fillStyle = color;

//    (function loop() {
//        ctx.clearRect(x, 0, 60, 150);
//        ctx.setLineDash([dashLen - dashOffset, dashOffset - speed]); // create a long dash mask
//        dashOffset -= speed;                                         // reduce dash length
//        ctx.strokeText(txt[i], x, 72);                               // stroke letter

//        if (dashOffset > 0) requestAnimationFrame(loop);             // animate
//        else {
//            ctx.fillText(txt[i], x, 72);                               // fill final letter
//            dashOffset = dashLen;                                      // prep next char
//            x += ctx.measureText(txt[i++]).width + ctx.lineWidth * Math.random();
//            ctx.setTransform(1, 0, 0, 1, 0, 3 * Math.random());        // random y-delta
//            ctx.rotate(Math.random() * 0.005);                         // random rotation
//            if (i < txt.length) requestAnimationFrame(loop);
//        }
//    })();
//}


