namespace MeidatorPattern.Sample
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    class SampleClient
    {
        public static void Run()
        {
            ListBox lstBox = new ListBox();
            Button btn = new Button();
            ComboxBox cbx = new ComboxBox();
            TextBox txtBox = new TextBox();

            Mediator mediator = new ConcreteMediator()
            {
                List = lstBox,
                Button = btn,
                ComboBox = cbx,
                TextBox = txtBox
            };

            lstBox.SetMediator(mediator);
            btn.SetMediator(mediator);
            cbx.SetMediator(mediator);
            txtBox.SetMediator(mediator);

            btn.Changed();
            lstBox.Changed();
            cbx.Changed();
        }
    }
}
