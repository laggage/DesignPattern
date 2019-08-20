namespace SimpleFactoryPattern.Shape
{
    using System;

    public class ShapeFactory
    {
        public static Shape CreateShape(string type)
        {
            string shape = type.ToLower();
            switch(shape)
            {
                case "circle":
                    return new Circle();
                case "triangle":
                    return new Triangle();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}

