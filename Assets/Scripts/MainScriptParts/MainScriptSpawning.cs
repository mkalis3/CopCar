using UnityEngine;

public partial class MainScript : MonoBehaviour
{
    const float TrafficCarY = -13.95181f;
    const float TrafficSpawnDistance = 60f;
    const float TrafficSpacing = 30f;

    void CreateCar(int i, Vector3 chasepos)
    {
        if (createsec <= 0.5f || createnow != 1)
        {
            cars[i] = 0;
            Destroy(carobject[i]);
            return;
        }

        int randomChoice = UnityEngine.Random.Range(1, 4);
        int lane = TrafficSpawnPlanner.SelectNextLane(nlastpos, randomChoice);
        PlaceTrafficCar(i, lane, chasepos, TrafficSpawnDistance);
        createsec = 0;
    }

    void PlaceTrafficCar(int i, int lane, Vector3 chasepos, float zOffset)
    {
        carobject[i].GetComponent<Transform>().transform.position = new Vector3(LaneLayout.GetX(lane), TrafficCarY, chasepos.z + zOffset);
        carobject[i].tag = lane.ToString();
        carobject[i].transform.localEulerAngles = new Vector3(0, 180, 0);
        nlastpos = lane;
    }

    bool RangeOf(float pos, int id)
    {
        float target = Mathf.Abs(pos);
        for (int i = 0; i < carnum; i++)
        {
            if (i == id || cars[i] != 1)
            {
                continue;
            }

            float existing = Mathf.Abs(carpos[i].z);
            return Mathf.Abs(existing - target) > TrafficSpacing;
        }

        return false;
    }
}
