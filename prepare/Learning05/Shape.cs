abstract class Shape{
    protected string color;

    public Shape(){

    }

    public Shape(string color){
        this.color = color;
    }

    public string GetColor(){
        return color;
    }

    public void SetColor(string color){
        this.color = color;
    }

    public virtual double GetArea(){
        return 0;
    }
}

class Square : Shape{
    protected double side;

    public Square(string color, double side){
        this.color = color;
        this.side = side;
    }

    public override double GetArea(){
        return side * side;
    }
}

class Rectangle : Shape{
    protected double length;
    protected double width;

    public Rectangle(string color, double length, double width){
        this.color = color;
        this.length = length;
        this.width = width;
    }

    public override double GetArea(){
        return length * width;
    }
}

class Circle : Shape{
    protected double radius;

    public Circle(string color, double radius){
        this.color = color;
        this.radius = radius;
    }

    public override double GetArea(){
        return radius * radius * 3.14159265;
    }
}