public static class TrafficSpawnPlanner
{
    public static int SelectNextLane(int previousLane, int randomChoice)
    {
        int choice = NormalizeChoice(randomChoice);

        switch (previousLane)
        {
            case 1:
                return Pick(choice, 2, 3, 4);
            case 2:
                return Pick(choice, 1, 3, 4);
            case 3:
                return Pick(choice, 1, 2, 4);
            case 4:
                return Pick(choice, 1, 2, 3);
            default:
                return Pick(choice, 1, 2, 3);
        }
    }

    static int NormalizeChoice(int randomChoice)
    {
        if (randomChoice < 1)
        {
            return 1;
        }

        if (randomChoice > 3)
        {
            return 3;
        }

        return randomChoice;
    }

    static int Pick(int choice, int first, int second, int third)
    {
        if (choice == 1)
        {
            return first;
        }

        if (choice == 2)
        {
            return second;
        }

        return third;
    }
}
