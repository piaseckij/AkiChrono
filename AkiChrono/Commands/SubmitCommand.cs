using System;
using System.Windows;
using AkiChrono.Services;
using AkiChrono.Vievmodel;

namespace AkiChrono.Commands;

public class SubmitCommand : CommandHandler
{
    private readonly UserWindowViewmodel _viewmodel;

    public SubmitCommand(UserWindowViewmodel viewmodel)
    {
        _viewmodel = viewmodel;
    }

    public override bool CanExecute(object? parameter)
    {
        return true;
    }

    public override void Execute(object? parameter)
    {
        _viewmodel.AddFlight();
    }
}