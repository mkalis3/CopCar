using UnityEngine;

public partial class MainScript : MonoBehaviour
{
    int dev, start, right, left, carnum, playing, roadobj, nlastpos, stars, nstars, createnow;
    float fpscounter, defspeed, drivespeed, roadcount, createsec, timec;
    int[] cars;
    int[] starThresholds;

    GameObject[] carobject, road;
    Vector3[] carpos, roadpos;

    GameObject copcar, chasecar, fpstext, car1, car2, car3, taxi, bus1, bus2, star, chasecoll, replay, roadblock, clones;
}
