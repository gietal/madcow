using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadcowModel
{
  public class WorkoutGenerator
  {
    IWorkoutHistoryProvider historyProvider;

    public WorkoutMovement createWorkoutMovementA(float targetWeight)
    {
      var movement = new WorkoutMovement();

      float[] weightPercentage = { 0.5f, 0.65f, 0.75f, 0.9f, 1.0f };

      foreach (var wp in weightPercentage)
      {
        var set = new WorkoutSet();
        set.maxReps = 5;
        set.weight = wp * targetWeight;
        movement.sets.Add(set);
      }

      return movement;
    }

    public WorkoutMovement createWorkoutMovementB(float targetWeight)
    {
      var movement = new WorkoutMovement();

      return movement;
    }

    public WorkoutMovement createWorkoutMovementC(float targetWeight)
    {
      var movement = new WorkoutMovement();

      return movement;
    }
  }
}
