using UnityEngine;

public partial class MainScript : MonoBehaviour
{
    void CreateStar(int id)
    {
        if (id == 1)
        {
            Vector3 lastvec = chasecar.transform.position;
            float vecz = lastvec.z;
            lastvec.y = -13.2f;
            lastvec.z = vecz + 5;
            nstars++;
            star.transform.position = lastvec;
        }
        else
        {
            Vector3 lastvec = chasecar.transform.position;
            float vecz = lastvec.z;
            lastvec.y = -13.2f;
            lastvec.z = vecz + 5;
            nstars++;
            star.transform.position = lastvec;

            Vector3 chasepos = chasecar.GetComponent<Transform>().transform.position;
            Vector3 rpos = roadblock.transform.position;
            roadblock.GetComponent<Transform>().transform.position = new Vector3(rpos.x, rpos.y, chasepos.z + 80);
            createnow = 0;
        }
    }

    void Level(int id)
    {
        createnow = 1;
        starThresholds = StarTiming.GetThresholdsForLevel(id);
    }

    public void EndLevel()
    {
        playing = 0;
        replay.transform.localScale = new Vector3(2, 2, 2);
    }

    public void Replay()
    {
        int rand = UnityEngine.Random.Range(1, 5);
        ChaseCollision script3 = (ChaseCollision)chasecoll.GetComponent(typeof(ChaseCollision));
        script3.isnow = rand;
        chasecar.GetComponent<Transform>().transform.position = new Vector3(LaneLayout.GetX(rand), -13.95181f, -102.5f);

        roadcount = 0;
        roadobj = 1;
        for (int i = 1; i < 21; i++)
        {
            road[i].transform.position = roadpos[i];
        }
        nstars = 0;
        stars = 0;
        right = 0;
        left = 0;
        timec = 0;

        copcar.transform.position = new Vector3(LaneLayout.GetX(2), -13.957f, -112.4f);

        for (int i = 0; i < carnum; i++)
        {
            cars[i] = 0;
            Destroy(carobject[i]);
        }

        foreach (Transform child in clones.transform)
        {
            GameObject.Destroy(child.gameObject);
        }


        Level(1);

        star.transform.position = new Vector3(0, 10000, 0);

        playing = 1;
        replay.transform.localScale = new Vector3(0, 0, 0);

        script3.ismoving = 0;
        script3.movingto = 0;
        script3.movingdir = 0;
    }

    public void AddStar()
    {
        stars++;
        Vector3 lastvec = chasecar.transform.position;
        float vecz = lastvec.z;
        lastvec.y = -13.2f;
        lastvec.z = vecz - 20;
        nstars++;
        star.transform.position = lastvec;
    }
}
