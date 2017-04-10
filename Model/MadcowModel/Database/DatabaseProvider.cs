using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace MadcowModel.Database
{
  public class DatabaseProvider
  {
    private Database database;

    public DatabaseProvider(string filepath)
    {
      database = new Database(filepath);
    }

    public Workout getWorkout(int id)
    {
      var entity = database.GetItem<WorkoutEntity>(id);
      if(entity == null)
      {
        return null;
      }

      var workout = JsonConvert.DeserializeObject<Workout>(entity.json);
      return workout;
    }

    public int saveWorkout(Workout workout)
    {
      // convert to json and put in database
      var dbEntity = new WorkoutEntity();
      dbEntity.json = JsonConvert.SerializeObject(workout);
      return database.SaveItem(dbEntity);
    }
  }
}
