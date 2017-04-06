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
      var beforeRounded = targetWeight / (2 * minimumPlateWeight);
      var rounded = (float) Math.Round(beforeRounded, 0, MidpointRounding.AwayFromZero);
      return rounded * 2 * minimumPlateWeight;
    }

    private float[] getRampingWeight(float targetWeight, float incrementPercentage, int setCount)
    {
      float[] weights = new float[setCount];
      for (int i = 0; i < setCount; ++i)
      {
        // 1 - 4r, 1 - 3r, 1 - 2r, 1 - r, 1
        var reduction = incrementPercentage * i;
        var index = setCount - 1 - i;
        weights[index] = (1.0f - reduction) * targetWeight;
      }
      return weights;
    }

    private WorkoutMovement createRampingWeightWorkoutMovement(WorkoutMovement.Type type, float targetWeight, int targetSet, int targetRep, float incrementPercentage, float minimumPlate)
    {
      var movement = new WorkoutMovement(type);

      var rampingWeight = getRampingWeight(targetWeight, incrementPercentage, targetSet);
      foreach (var weight in rampingWeight)
      {
        var set = new WorkoutSet();
        set.maxReps = targetRep;
        set.weight = getRoundedWeight(weight, minimumPlate);
        movement.sets.Add(set);
      }

      return movement;
    }

    public WorkoutMovement createWorkoutMovementA(WorkoutMovement.Type type, float targetWeight, float incrementPercentage = 0.125f)
    {
      // 5x5:	Ramping weight to top set of 5 (which should equal the previous Friday's heavy triple)
      return createRampingWeightWorkoutMovement(type, targetWeight, 5, 5, incrementPercentage, 2.5f);
    }

    //public WorkoutMovement createWorko

    public WorkoutMovement createWorkoutMovementBSquat(WorkoutMovement squatFromWorkoutA)
    {
      var movement = new WorkoutMovement(WorkoutMovement.Type.squat);

      // 4x5: First 3 sets are the same as Monday, the 4th set is repeating the 3rd set again
      if(squatFromWorkoutA.sets.Count < 3 || squatFromWorkoutA.type != WorkoutMovement.Type.squat)
      {
        throw new InvalidOperationException("squat from workout A needed to have at least 3");
      }

      for(int i = 0; i < 3; ++i)
      {
        var previousSet = squatFromWorkoutA.sets[i];
        movement.sets.Add(new WorkoutSet(5, previousSet.weight));
      }

      // the 4th one is repeating the 3rd one
      movement.sets.Add(new WorkoutSet(5, movement.sets[2].weight));

      return movement;
    }

    public WorkoutMovement createWorkoutMovementB(WorkoutMovement.Type type, float targetWeight, float incrementPercentage = 0.125f)
    {
      if(type == WorkoutMovement.Type.squat)
      {
        throw new InvalidOperationException("use createWorkoutMovementBSquat for squat");
      }

      // 4x5 Ramping weight to top set of 5
      return createRampingWeightWorkoutMovement(type, targetWeight, 4, 5, incrementPercentage, 2.5f);
    }

    public WorkoutMovement createWorkoutMovementB(WorkoutMovement lastWeekWorkoutB)
    {
      float targetWeight = getRoundedWeight(lastWeekWorkoutB.sets.Last().weight * (1.025f)); // 2.5% weight increase from last week's workout
      return createWorkoutMovementB(lastWeekWorkoutB.type, targetWeight);
    }

    public WorkoutMovement createWorkoutMovementC(WorkoutMovement workoutA)
    {
      if(workoutA.sets.Count < 5)
      {
        throw new InvalidOperationException("monday's workout has to have 5 sets");
      }

      var movement = new WorkoutMovement(workoutA.type);

      // 4x5, 1x3, 1x8 

      // First 4 sets are the same as Monday's, 
      for (int i = 0; i < 4; ++i)
      {
        var mondaySet = workoutA.sets[i];
        movement.sets.Add(new WorkoutSet(mondaySet));
      }

      // the triple is 2.5% above your Monday top set of 5, 
      float tripleWeight = getRoundedWeight(workoutA.sets.Last().weight * 1.025f);
      movement.sets.Add(new WorkoutSet(3, tripleWeight));

      // use the weight from the 3rd set for a final set of 8
      movement.sets.Add(new WorkoutSet(8, movement.sets[2].weight));

      return movement;
    }
  }
}
