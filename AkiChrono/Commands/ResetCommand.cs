using System;
using System.Threading.Tasks;
using AkiChrono.Vievmodel;

namespace AkiChrono.Commands;

public class ResetCommand : CommandHandler
{
    private readonly UserWindowViewmodel _viewmodel;

    public ResetCommand(UserWindowViewmodel viewmodel)
    {
        _viewmodel = viewmodel;
    }

    public override void Execute(object? parameter)
    {
        _viewmodel.InputFlightDate = DateTime.Now.Date;
        _viewmodel.InputPilotName = "";
        _viewmodel.InputFlightTimeSum = TimeSpan.Zero;
    }

}