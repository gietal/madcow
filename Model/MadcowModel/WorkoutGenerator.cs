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

    public float getRoundedWeight(float targetWeight, float minimumPlateWeight = 2.5f)
    {
      var rounded = (float) Math.Round(targetWeight / (2 * minimumPlateWeight), 0, MidpointRounding.AwayFromZero);
      return rounded * 2 * minimumPlateWeight;
    }

    public WorkoutMovement createWorkoutMovementA(WorkoutMovement.Type type, float targetWeight, float incrementPercentage = 0.125f)
    {
      var movement = new WorkoutMovement();
      const int repCount = 5;

      float[] weightPercentage = new float[repCount];
      for( int i = 0; i < repCount; ++i)
      {
        // 1 - 4r, 1 - 3r, 1 - 2r, 1 - r, 1
        var reduction = incrementPercentage * i;
        var index = repCount - 1 - i;
        weightPercentage[index] = 1.0f - reduction;
      }

      foreach (var wp in weightPercentage)
      {
        var set = new WorkoutSet();
        set.maxReps = repCount;
        set.weight = getRoundedWeight(wp * targetWeight);
        movement.sets.Add(set);
      }

      return movement;
    }

    public WorkoutMovement createWorkoutMovementB(WorkoutMovement.Type type, float targetWeight)
    {
      var movement = new WorkoutMovement();

      return movement;
    }

    public WorkoutMovement createWorkoutMovementC(WorkoutMovement.Type type, float targetWeight)
    {
      var movement = new WorkoutMovement();

      return movement;
    }
  }
}
