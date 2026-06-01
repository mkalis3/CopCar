public static class ChaseLaneDecision
{
    public static int SelectTargetLane(int currentLane, int[] blockedLanes, int randomChoice)
    {
        int lane = LaneLayout.ClampLane(currentLane);

        if (lane == 1)
        {
            return 2;
        }

        if (lane == 4)
        {
            return 3;
        }

        if (lane == 2)
        {
            return randomChoice <= 1
                ? PreferAvailable(1, 3, blockedLanes)
                : PreferAvailable(3, 1, blockedLanes);
        }

        return randomChoice <= 1
            ? PreferAvailable(2, 4, blockedLanes)
            : PreferAvailable(4, 2, blockedLanes);
    }

    static int PreferAvailable(int preferredLane, int fallbackLane, int[] blockedLanes)
    {
        return IsBlocked(preferredLane, blockedLanes) ? fallbackLane : preferredLane;
    }

    static bool IsBlocked(int lane, int[] blockedLanes)
    {
        return blockedLanes != null
            && lane >= 0
            && lane < blockedLanes.Length
            && blockedLanes[lane] != 0;
    }
}
