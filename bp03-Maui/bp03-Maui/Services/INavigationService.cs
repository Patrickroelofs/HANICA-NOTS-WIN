using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bp03_Maui.Services
{
  public interface INavigationService
  {
    Task NavigateBack();
    Task NavigateToMainPage();
  }
}
