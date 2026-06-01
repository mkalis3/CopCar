public static class StarTiming
{
    static readonly int[] LevelOneThresholds = { 5, 10, 15 };

    public static int[] GetThresholdsForLevel(int level)
    {
        if (level < 1)
        {
            level = 1;
        }

        return Copy(LevelOneThresholds);
    }

    public static int GetThresholdForCollectedStars(int collectedStars, int[] thresholds)
    {
        if (thresholds == null || thresholds.Length == 0)
        {
            return 0;
        }

        if (collectedStars < 0)
        {
            collectedStars = 0;
        }

        if (collectedStars >= thresholds.Length)
        {
            return 0;
        }

        return thresholds[collectedStars];
    }

    public static bool ShouldSpawnStar(float elapsedSeconds, int collectedStars, int[] thresholds)
    {
        int threshold = GetThresholdForCollectedStars(collectedStars, thresholds);
        return threshold > 0 && elapsedSeconds >= threshold;
    }

    public static int GetSpawnIdForCollectedStars(int collectedStars)
    {
        return collectedStars >= 2 ? 2 : 1;
    }

    static int[] Copy(int[] values)
    {
        int[] copy = new int[values.Length];
        for (int i = 0; i < values.Length; i++)
        {
            copy[i] = values[i];
        }

        return copy;
    }
}
