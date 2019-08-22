namespace DecoratorPattern
{
    using System;
    using DecoratorPattern.VisualComponent;

    class Program
    {
        static void Main(string[] args)
        {
            VisualComponent.VisualComponent txtBox = new TextBox();
            var lstBox = new ListBox();

            var borderListBox = new BlackBorderDecorator(lstBox);
            var scrollBorderListBox = new ScrollBarDecorator(borderListBox);
            var scrollTextBox = new ScrollBarDecorator(txtBox);

            borderListBox.Display();
            scrollBorderListBox.Display();
            scrollTextBox.Display();

            Console.ReadKey();
        }
    }
}
