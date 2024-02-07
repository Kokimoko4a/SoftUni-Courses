class Rectangle{

    width;
    height;
    color;

    constructor(width, height, color){

        this.width = width;
        this.height = height;
        this.color = color;

    }

    calcArea(){

        return this.width * this.height;
    }

}