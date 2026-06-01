using NUnit.Framework;

public class ChaseLaneDecisionTests
{
    [Test]
    public void EdgeLanesMoveTowardTheRoadCenter()
    {
        Assert.AreEqual(2, ChaseLaneDecision.SelectTargetLane(1, new int[5], 1));
        Assert.AreEqual(3, ChaseLaneDecision.SelectTargetLane(4, new int[5], 1));
    }

    [Test]
    public void MiddleLaneUsesPreferredOpenLane()
    {
        Assert.AreEqual(1, ChaseLaneDecision.SelectTargetLane(2, new int[5], 1));
        Assert.AreEqual(3, ChaseLaneDecision.SelectTargetLane(2, new int[5], 2));
        Assert.AreEqual(2, ChaseLaneDecision.SelectTargetLane(3, new int[5], 1));
        Assert.AreEqual(4, ChaseLaneDecision.SelectTargetLane(3, new int[5], 2));
    }

    [Test]
    public void MiddleLaneFallsBackWhenPreferredLaneIsBlocked()
    {
        int[] blocked = new int[5];
        blocked[1] = 1;
        blocked[4] = 1;

        Assert.AreEqual(3, ChaseLaneDecision.SelectTargetLane(2, blocked, 1));
        Assert.AreEqual(2, ChaseLaneDecision.SelectTargetLane(3, blocked, 2));
    }
}
