using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadcowModel
{
  public class AppModel
  {
    IWorkoutHistoryProvider historyProvider;
    AppModel(IWorkoutHistoryProvider historyProvider)
    {
      this.historyProvider = historyProvider;
    }
  }
}
