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

    private WorkoutGenerator generator = new WorkoutGenerator();
    private IWorkoutHistoryProvider historyProvider;

    public WorkoutManager(IWorkoutHistoryProvider historyProvider)
    {
      this.historyProvider = historyProvider;
    }

    public void setWorkoutType(Workout.Type type)
    {
      switch(type)
      {
        case Workout.Type.A:
          {
            // get latest workout C
            var latestWorkout = historyProvider.getLatestWorkout(Workout.Type.C);
            if (latestWorkout != null)
            {
              // subsequent workout
            }
            else
            {
              // first workout
            }
            break;
          }
        case Workout.Type.B:
          {
            // get latest workout A B
            var latestWorkoutA = historyProvider.getLatestWorkout(Workout.Type.A); // 2 days ago
            var latestWorkoutB = historyProvider.getLatestWorkout(Workout.Type.B); // 1 week ago
            if (latestWorkoutA != null && latestWorkoutB != null)
            {
              // subsequent workout
            }
            else
            {
              // first workout
            }
            break;
          }
        case Workout.Type.C:
          {
            // get latest workout A
            var latestWorkout = historyProvider.getLatestWorkout(Workout.Type.A);
            if (latestWorkout != null)
            {
              // subsequent workout
            }
            else
            {
              // first workout
            }
            break;
          }
      }
    }

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
      if (repCount > set.targetReps || repCount < 0)
      {
        set.completedReps = WorkoutSet.undoneRep;
      }
      else
      {
        set.completedReps = repCount;
      }
    }

  }
}
