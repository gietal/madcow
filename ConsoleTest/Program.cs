using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MadcowModel;
using MadcowModel.Database;
using Newtonsoft.Json;
using System.IO;

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
      a.ID = 1234;

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

    // TODO: move this to shared project 
    public static string DatabaseFilePath
    {
      get
      {
        var sqliteFilename = "TaskDB.db3";

#if NETFX_CORE
                var path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, sqliteFilename);
#else

#if SILVERLIGHT
				// Windows Phone expects a local path, not absolute
	            var path = sqliteFilename;
#else

#if __ANDROID__
				// Just use whatever directory SpecialFolder.Personal returns
	            string libraryPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); ;
#else
        // we need to put in /Library/ on iOS5.1 to meet Apple's iCloud terms
        // (they don't want non-user-generated data in Documents)
        string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
        string libraryPath = Path.Combine(documentsPath, "../Library/"); // Library folder
#endif
        var path = Path.Combine(libraryPath, sqliteFilename);
#endif

#endif
        return path;
      }
    }
  }
}
