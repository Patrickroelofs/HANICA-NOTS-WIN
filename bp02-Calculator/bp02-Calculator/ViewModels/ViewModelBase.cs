using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace bp02_Calculator.ViewModels;

// Source https://stackoverflow.com/questions/36149863/how-to-write-a-viewmodelbase-in-mvvm
// And a bit of help from Github Copilot
public class ViewModelBase : INotifyPropertyChanged
{
  public event PropertyChangedEventHandler? PropertyChanged;

  protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
  {
    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
  }
}