using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MadcowModel;

namespace UnitTests
{
  [TestClass]
  public class WorkoutGeneratorTests
  {
    WorkoutGenerator testSubject;
    float weightIncrement = 0.125f; // 12.5%
    [TestInitialize]
    public void TestInitialize()
    {
      testSubject = new WorkoutGenerator();
    }

    [TestMethod]
    public void testCreateWorkoutA_1()
    {
      var movement = testSubject.createWorkoutMovementA(WorkoutMovement.Type.squat, 100, weightIncrement);

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

    [TestMethod]
    public void testCreateWorkoutB_squat()
    {
      var movement = testSubject.createWorkoutMovementB(WorkoutMovement.Type.squat, 100);

      // check set number
      Assert.AreEqual(4, movement.sets.Count, "wrong set number");

      // check rep target
      foreach (var s in movement.sets)
      {
        Assert.AreEqual(5, s.maxReps, "expected 5 reps on every set");
      }

      // check weights for each rep
      Assert.AreEqual(50, movement.sets[0].weight, "wrong weight");
      Assert.AreEqual(65, movement.sets[1].weight, "wrong weight");
      Assert.AreEqual(75, movement.sets[2].weight, "wrong weight");
      Assert.AreEqual(75, movement.sets[3].weight, "wrong weight");
    }

    [TestMethod]
    public void testCreateWorkoutB_overhead()
    {
      // press and deadlift
      var movement = testSubject.createWorkoutMovementB(WorkoutMovement.Type.overheadPress, 100);

      // check set number
      Assert.AreEqual(4, movement.sets.Count, "wrong set number");

      // check rep target
      foreach (var s in movement.sets)
      {
        Assert.AreEqual(5, s.maxReps, "expected 5 reps on every set");
      }

      // check weights for each rep
      Assert.AreEqual(65, movement.sets[0].weight, "wrong weight");
      Assert.AreEqual(75, movement.sets[1].weight, "wrong weight");
      Assert.AreEqual(90, movement.sets[2].weight, "wrong weight");
      Assert.AreEqual(100, movement.sets[3].weight, "wrong weight");
    }

    [TestMethod]
    public void testCreateWorkoutC_1()
    {
      // all the same
      var movement = testSubject.createWorkoutMovementB(WorkoutMovement.Type.squat, 100);

      // check set number
      Assert.AreEqual(6, movement.sets.Count, "wrong set number");

      // check rep target
      for (int i = 0; i < 4; ++i)
      {
        var s = movement.sets[i];
        Assert.AreEqual(5, s.maxReps, "expected 5 reps on every set");
      }
      Assert.AreEqual(3, movement.sets[4].maxReps, "wrong reps");
      Assert.AreEqual(8, movement.sets[5].maxReps, "wrong reps");

      // check weights for each rep
      Assert.AreEqual(50, movement.sets[0].weight, "wrong weight");
      Assert.AreEqual(65, movement.sets[1].weight, "wrong weight");
      Assert.AreEqual(75, movement.sets[2].weight, "wrong weight");
      Assert.AreEqual(90, movement.sets[3].weight, "wrong weight");
      Assert.AreEqual(100, movement.sets[4].weight, "wrong weight");
      Assert.AreEqual(75, movement.sets[5].weight, "wrong weight");
    }
  }
}
