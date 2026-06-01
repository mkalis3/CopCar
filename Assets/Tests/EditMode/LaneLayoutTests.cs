using NUnit.Framework;

public class LaneLayoutTests
{
    [TestCase(1, -16.34f)]
    [TestCase(2, -18.337f)]
    [TestCase(3, -20.34f)]
    [TestCase(4, -22.228f)]
    public void GetXReturnsConfiguredLanePosition(int lane, float expectedX)
    {
        Assert.AreEqual(expectedX, LaneLayout.GetX(lane), 0.0001f);
    }

    [TestCase(-4, 1)]
    [TestCase(0, 1)]
    [TestCase(5, 4)]
    public void ClampLaneKeepsLaneInsideRoad(int lane, int expectedLane)
    {
        Assert.AreEqual(expectedLane, LaneLayout.ClampLane(lane));
    }

    [TestCase(-16.1f, 1)]
    [TestCase(-18.4f, 2)]
    [TestCase(-20.2f, 3)]
    [TestCase(-22.0f, 4)]
    public void GetNearestLaneFindsClosestLane(float x, int expectedLane)
    {
        Assert.AreEqual(expectedLane, LaneLayout.GetNearestLane(x));
    }
}
