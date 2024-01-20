function rectangle(width, height, color){

    let lettersOfColor = Array.from(color);
    let firstLetterOfCollor = lettersOfColor[0].toUpperCase();
    lettersOfColor[0] = firstLetterOfCollor;

    let finalColor = lettersOfColor.join("");
    console.log(finalColor);

    let rectangle = {
        width,
        height,
        color: finalColor,
        calcArea: function(){
            return width * height
        }
    }

    return rectangle;

}

rectangle(1,2,"ddd")