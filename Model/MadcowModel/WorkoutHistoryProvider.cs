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

    public override Workout getLatestWorkout(Workout.Type type)
    {
      // need data service
      // get 3 latest workout and start walking backward until history.type == type
      return null;
    }
  }
}
