using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadcowModel
{
  class WorkoutManager
  {
    public Workout workout;

    public void finishWorkout()
    {

    }
    public void setCompletedRep(int movementIndex, int setIndex, int repCount)
    {
      if(movementIndex >= workout.movements.Count)
      {
        return;
      }

      if(setIndex >= workout.movements[movementIndex].sets.Count)
      {
        return;
      }

      var set = workout.movements[movementIndex].sets[setIndex];
      if (repCount > set.maxReps || repCount < 0)
      {
        set.completedReps = Set.undoneRep;
      }
      else
      {
        set.completedReps = repCount;
      }
    }

  }
}
