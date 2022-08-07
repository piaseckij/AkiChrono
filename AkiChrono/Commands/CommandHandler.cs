using System;
using System.Windows.Input;

namespace AkiChrono.Commands;

public abstract class CommandHandler : ICommand
{
    public virtual bool CanExecute(object? parameter)
    {
        return true;
    }

    public abstract void Execute(object? parameter);

    public event EventHandler? CanExecuteChanged;

    public void OnCanExecuteChanged()
    {
        CanExecuteChanged.Invoke(this, EventArgs.Empty);
    }
}