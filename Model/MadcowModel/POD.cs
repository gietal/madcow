﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadcowModel
{
  public class WorkoutSet
  {
    public WorkoutSet(int maxReps = 5, float weight = 0)
    {
      this.maxReps = maxReps;
      this.weight = weight;
    }

    public WorkoutSet(WorkoutSet other)
    {
      this.maxReps = other.maxReps;
      this.weight = other.weight;
    }
    public static int undoneRep = -1;

    // how many reps in this set
    public int completedReps = undoneRep;
    public int maxReps = 5;
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
    public readonly Type type = Type.squat;
    public List<WorkoutSet> sets = new List<WorkoutSet>();

    public WorkoutMovement(Type type)
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
    public readonly Type type;

    public Workout(Workout.Type type)
    {
      this.type = type;
    }

    // helper 
    public WorkoutMovement squat
    {
      get
      {
        return getMovement(WorkoutMovement.Type.squat);
      }
    }

    public WorkoutMovement benchPress
    {
      get
      {
        return getMovement(WorkoutMovement.Type.benchPress);
      }
    }

    public WorkoutMovement row
    {
      get
      {
        return getMovement(WorkoutMovement.Type.row);
      }
    }

    public WorkoutMovement overheadPress
    {
      get
      {
        return getMovement(WorkoutMovement.Type.overheadPress);
      }
    }

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
