using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern.Sample.Wpf
{
    interface ICommandSource
    {
        ICommand Command
        {
            get;
        }

        object CommandParameter
        {
            get;
        }

        IInputElement CommandTarget
        {
            get;
        }
    }
}
