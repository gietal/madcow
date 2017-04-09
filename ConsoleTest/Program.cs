using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MadcowModel;
using MadcowModel.Database;
using Newtonsoft.Json;

namespace ConsoleTest
{
  class Program
  {
    static void Main(string[] args)
    {
      var w = new WeightStatus();
      w.squat = 100;
      w.benchPress = 100;
      w.row = 100;
      w.deadlift = 100;
      w.overheadPress = 100;

      var generator = new WorkoutGenerator();
      var a = generator.createWorkoutA(w);

      Console.WriteLine("------------------- original ------------------------");
      var json = JsonConvert.SerializeObject(a, Formatting.Indented);
      Console.WriteLine(json);

      var deserialized = JsonConvert.DeserializeObject<Workout>(json);

      Console.WriteLine("------------------- deserialized ------------------------");

      var json2 = JsonConvert.SerializeObject(deserialized, Formatting.Indented);
      Console.WriteLine(json2);

      Console.WriteLine("-------------------------------------");
      Console.WriteLine("match = " + (json2 == json));
      Console.ReadKey();
    }
  }
}
