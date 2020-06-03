using System;

namespace DecoratorPattern.VisualComponent
{
    public abstract class ComponentDecorator : VisualComponent
    {
        VisualComponent _component;

        public ComponentDecorator(VisualComponent component)
        {
            _component = component;
        }

        public override void Display()
        {
            _component.Display();
        }
    }

    public abstract class VisualComponent
    {
        public abstract void Display();
    }

    public class Window : VisualComponent
    {
        public override void Display()
        {
            Console.WriteLine("--- Window ---");
        }
    }

    public class TextBox : VisualComponent
    {
        public override void Display()
        {
            Console.WriteLine("--- Textbox ---");
        }
    }

    public class ListBox : VisualComponent
    {
        public override void Display()
        {
            Console.WriteLine("--- ListBox ---");
        }
    }

    public class ScrollBarDecorator : ComponentDecorator
    {
        public ScrollBarDecorator(VisualComponent component) : base(component)
        {
        }

        public override void Display()
        {
            ShowScrollBar();
            base.Display();
        }

        private void ShowScrollBar()
        {
            Console.WriteLine("--- ScrollBar ---");
        }
    }

    public class BlackBorderDecorator : ComponentDecorator
    {
        public BlackBorderDecorator(VisualComponent component) : base(component)
        {
        }

        public override void Display()
        {
            Console.WriteLine("<==== BlackBorder ====>");
            base.Display();
            Console.WriteLine("<==== BlackBorder ====>\r\n");
        }
    }
}
