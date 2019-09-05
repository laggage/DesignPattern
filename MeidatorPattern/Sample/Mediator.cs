namespace MeidatorPattern.Sample
{
    using System;

    abstract class Mediator
    {
        public ListBox List { get; set; }
        public Button Button { get; set; }
        public ComboxBox ComboBox { get; set; }
        public TextBox TextBox { get; set; }


        public abstract void ComponentChanged(Component component);
    }

    class ConcreteMediator: Mediator
    {
        public override void ComponentChanged(Component component)
        {
            if (component == Button)
            {
                Console.WriteLine("----- 单击增加按钮 -----");
                ComboBox.Update();
                List.Update();
                TextBox.Update();
            }
            else if (component == List)
            {
                Console.WriteLine("----- 列表框选择客户 -----");
                ComboBox.Select();
                TextBox.SetText();
            }
            else if (component == ComboBox)
            {
                Console.WriteLine("----- 组合选择客户 -----");
                List.Select();
                TextBox.SetText();
            }
        }
    }
}
