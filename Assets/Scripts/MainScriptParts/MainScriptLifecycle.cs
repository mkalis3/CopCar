using UnityEngine;

public partial class MainScript : MonoBehaviour
{
    void Start()
    {
        if (start == 0)
        {
            dev = 1;

            playing = 0;

            carnum = 20;
            roadobj = 1;
            defspeed = 0.1f;
            drivespeed = defspeed;

            starThresholds = new int[3];

            Level(1);


            fpstext = GameObject.Find("fpstext");
            copcar = GameObject.Find("copcar");
            chasecar = GameObject.Find("chasecar");
            car1 = GameObject.Find("car1");
            car2 = GameObject.Find("car2");
            car3 = GameObject.Find("car3");
            taxi = GameObject.Find("taxi");
            bus1 = GameObject.Find("bus1");
            bus2 = GameObject.Find("bus2");
            star = GameObject.Find("star");
            chasecoll = GameObject.Find("chasecoll");
            replay = GameObject.Find("replay");
            roadblock = GameObject.Find("roadblock");
            clones = GameObject.Find("clones");

            replay.transform.localScale = new Vector3(2, 2, 2);


            Application.targetFrameRate = 60;
            QualitySettings.vSyncCount = 0;

            cars = new int[carnum];
            carobject = new GameObject[carnum];
            carpos = new Vector3[carnum];

            road = new GameObject[21];
            roadpos = new Vector3[21];

            start = 1;


            for (int i = 1; i < 21; i++)
            {
                road[i] = GameObject.Find("road"+i);
                if (road[i] != null)
                {
                    roadpos[i] = road[i].transform.position;
                }
            }
        }
    }
}
