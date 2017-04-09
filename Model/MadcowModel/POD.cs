using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Newtonsoft.Json;

namespace MadcowModel
{
  public interface IBusinessEntity
  {
    int ID { get; set; }
  }

  public abstract class BusinessEntityBase: IBusinessEntity
  {
    public BusinessEntityBase()
    {
      ID = 0;
    }
    [PrimaryKey, AutoIncrement]
    public int ID { get; set; }
  }

  public class WorkoutSet
  {
    [JsonConstructor]
    public WorkoutSet(int targetReps = 5, float weight = 0)
    {
      this.targetReps = targetReps;
      this.weight = weight;
    }

    public WorkoutSet(WorkoutSet other)
    {
      this.targetReps = other.targetReps;
      this.weight = other.weight;
    }
    public static int undoneRep = -1;

    // how many reps in this set
    public int completedReps = undoneRep;
    public int targetReps = 5;
    public float weight = 0;
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
    public Type type = Type.squat;
    public List<WorkoutSet> sets = new List<WorkoutSet>();

    [JsonConstructor]
    public WorkoutMovement(Type type = Type.squat)
    {
      this.type = type;
    }
  }

  public class Workout
  {
    public enum Type
    {
      A,
      B,
      C
    }

    public List<WorkoutMovement> movements = new List<WorkoutMovement>();
    public Type type;

    [JsonConstructor]
    public Workout(Workout.Type type = Type.A)
    {
      this.type = type;
    }

    // helper 

    [JsonIgnore]
    public WorkoutMovement squat
    {
      get
      {
        return getMovement(WorkoutMovement.Type.squat);
      }
    }

    [JsonIgnore]
    public WorkoutMovement benchPress
    {
      get
      {
        return getMovement(WorkoutMovement.Type.benchPress);
      }
    }

    [JsonIgnore]
    public WorkoutMovement row
    {
      get
      {
        return getMovement(WorkoutMovement.Type.row);
      }
    }

    [JsonIgnore]
    public WorkoutMovement overheadPress
    {
      get
      {
        return getMovement(WorkoutMovement.Type.overheadPress);
      }
    }

    [JsonIgnore]
    public WorkoutMovement deadlift
    {
      get
      {
        return getMovement(WorkoutMovement.Type.deadlift);
      }
    }

    private WorkoutMovement getMovement(WorkoutMovement.Type movementType)
    {
      foreach(var m in movements)
      {
        if (m.type == movementType)
        {
          return m;
        }
      }
      return null;
    }

    
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
