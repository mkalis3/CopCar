using NUnit.Framework;

public class StarTimingTests
{
    [Test]
    public void LevelOneUsesThreeStarThresholds()
    {
        int[] thresholds = StarTiming.GetThresholdsForLevel(1);

        Assert.AreEqual(3, thresholds.Length);
        Assert.AreEqual(5, thresholds[0]);
        Assert.AreEqual(10, thresholds[1]);
        Assert.AreEqual(15, thresholds[2]);
    }

    [TestCase(4.9f, 0, false)]
    [TestCase(5f, 0, true)]
    [TestCase(9.9f, 1, false)]
    [TestCase(10f, 1, true)]
    [TestCase(15f, 2, true)]
    [TestCase(20f, 3, false)]
    public void ShouldSpawnStarUsesCollectedStarCount(float elapsedSeconds, int collectedStars, bool expected)
    {
        Assert.AreEqual(expected, StarTiming.ShouldSpawnStar(elapsedSeconds, collectedStars, StarTiming.GetThresholdsForLevel(1)));
    }

    [TestCase(0, 1)]
    [TestCase(1, 1)]
    [TestCase(2, 2)]
    [TestCase(5, 2)]
    public void GetSpawnIdMatchesRoadblockTiming(int collectedStars, int expectedSpawnId)
    {
        Assert.AreEqual(expectedSpawnId, StarTiming.GetSpawnIdForCollectedStars(collectedStars));
    }
}
