using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MadcowModel;

namespace UnitTests
{
  [TestClass]
  public class WorkoutGeneratorTests
  {
    WorkoutGenerator testSubject;

    [TestInitialize]
    public void TestInitialize()
    {
      testSubject = new WorkoutGenerator();
    }

    [TestMethod]
    public void testCreateWorkoutA_1()
    {
      var movement = testSubject.createWorkoutMovementA(100);

      // check set number
      Assert.AreEqual(5, movement.sets.Count, "expected 5 sets");

      // check rep target
      foreach(var s in movement.sets)
      {
        Assert.AreEqual(5, s.maxReps, "expected 5 reps on every set");
      }

      // check weights for each rep
      Assert.AreEqual(50, movement.sets[0].weight, "wrong weight");
      Assert.AreEqual(65, movement.sets[1].weight, "wrong weight");
      Assert.AreEqual(75, movement.sets[2].weight, "wrong weight");
      Assert.AreEqual(90, movement.sets[3].weight, "wrong weight");
      Assert.AreEqual(100, movement.sets[4].weight, "wrong weight");
    }
  }
}
