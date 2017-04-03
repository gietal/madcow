using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadcowModel
{
  class Set
  {
    public Set()
    {
      completedReps = undoneRep;
      maxReps = 5;
    }

    public static int undoneRep = -1;

    // how many reps in this set
    public int completedReps;
    public int maxReps;
  }

  class Movement
  {
    public List<Set> sets;
  }

  class Workout
  {
    public List<Movement> movements;
  }
}
