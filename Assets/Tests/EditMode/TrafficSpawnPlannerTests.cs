using NUnit.Framework;

public class TrafficSpawnPlannerTests
{
    [TestCase(0, 1, 1)]
    [TestCase(0, 2, 2)]
    [TestCase(0, 3, 3)]
    [TestCase(1, 1, 2)]
    [TestCase(1, 2, 3)]
    [TestCase(1, 3, 4)]
    [TestCase(2, 1, 1)]
    [TestCase(2, 2, 3)]
    [TestCase(2, 3, 4)]
    [TestCase(3, 1, 1)]
    [TestCase(3, 2, 2)]
    [TestCase(3, 3, 4)]
    [TestCase(4, 1, 1)]
    [TestCase(4, 2, 2)]
    [TestCase(4, 3, 3)]
    public void SelectNextLaneAvoidsPreviousLane(int previousLane, int randomChoice, int expectedLane)
    {
        Assert.AreEqual(expectedLane, TrafficSpawnPlanner.SelectNextLane(previousLane, randomChoice));
    }

    [TestCase(2, -10, 1)]
    [TestCase(2, 99, 4)]
    public void SelectNextLaneClampsRandomChoice(int previousLane, int randomChoice, int expectedLane)
    {
        Assert.AreEqual(expectedLane, TrafficSpawnPlanner.SelectNextLane(previousLane, randomChoice));
    }
}
