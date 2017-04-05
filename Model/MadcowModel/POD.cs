using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadcowModel
{
  public class WorkoutSet
  {
    public WorkoutSet()
    {
      completedReps = undoneRep;
      maxReps = 5;
    }

    public static int undoneRep = -1;

    // how many reps in this set
    public int completedReps;
    public int maxReps;
    public float weight;
  }

  public class WorkoutMovement
  {
    public enum Type
    {
      squat,
      benchPress,
      overheadPress,
      row,
      deadlift
    }
    Type type = Type.squat;
    public List<WorkoutSet> sets = new List<WorkoutSet>();
  }

  public class Workout
  {
    public List<WorkoutMovement> movements = new List<WorkoutMovement>();
  }

  public class WeightStatus
  {
    public enum WeightType
    {
      pound,
      kilogram
    }

    // lb or kg?
    public WeightType type = WeightType.pound;
    public float body = 0;
    public float squat = 0;
    public float benchPress = 0;
    public float overheadPress = 0;
    public float row = 0;
    public float deadlift = 0;
  }
}
