public static class LaneLayout
{
    public const int FirstLane = 1;
    public const int LastLane = 4;

    public const float LaneOneX = -16.34f;
    public const float LaneTwoX = -18.337f;
    public const float LaneThreeX = -20.34f;
    public const float LaneFourX = -22.228f;

    public const float RightEdgeX = LaneOneX;
    public const float LeftEdgeX = LaneFourX;

    public static bool IsValidLane(int lane)
    {
        return lane >= FirstLane && lane <= LastLane;
    }

    public static int ClampLane(int lane)
    {
        if (lane < FirstLane)
        {
            return FirstLane;
        }

        if (lane > LastLane)
        {
            return LastLane;
        }

        return lane;
    }

    public static float GetX(int lane)
    {
        switch (ClampLane(lane))
        {
            case 1:
                return LaneOneX;
            case 2:
                return LaneTwoX;
            case 3:
                return LaneThreeX;
            default:
                return LaneFourX;
        }
    }

    public static int GetNearestLane(float x)
    {
        int nearestLane = FirstLane;
        float nearestDistance = Distance(x, GetX(nearestLane));

        for (int lane = FirstLane + 1; lane <= LastLane; lane++)
        {
            float distance = Distance(x, GetX(lane));
            if (distance < nearestDistance)
            {
                nearestLane = lane;
                nearestDistance = distance;
            }
        }

        return nearestLane;
    }

    static float Distance(float first, float second)
    {
        float value = first - second;
        return value < 0 ? -value : value;
    }
}
