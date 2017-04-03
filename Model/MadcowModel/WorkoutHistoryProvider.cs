using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadcowModel
{
  class WorkoutHistoryProvider: IWorkoutHistoryProvider
  {
    public override List<Workout> getWorkoutHistory(uint previousDays)
    {
      return new List<Workout>();
    }
  }
}
