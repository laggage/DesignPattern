using System;

#nullable enable

namespace CommandPattern.Sample.Wpf
{
    interface ICommand
    {
        event EventHandler CanExecuteChanged;

        bool CanExecute(object? parameter);

        void Execute(object? parameter);
    }
}
