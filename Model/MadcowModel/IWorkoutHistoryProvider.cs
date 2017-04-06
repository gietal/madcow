using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadcowModel
{
  abstract class IWorkoutHistoryProvider
  {
    static uint allDays = unchecked((uint)-1);

    public abstract List<Workout> getWorkoutHistory(uint previousDays);
    public abstract Workout getLatestWorkout(Workout.Type type);
  }
}
