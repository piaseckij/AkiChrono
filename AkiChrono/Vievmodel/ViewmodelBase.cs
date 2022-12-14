using System.ComponentModel;
using System.Runtime.CompilerServices;
using AkiChrono.Annotations;

namespace AkiChrono.Vievmodel;

public class ViewmodelBase : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}