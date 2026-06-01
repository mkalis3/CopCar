using UnityEngine;
using UnityEngine.UI;

public partial class MainScript : MonoBehaviour
{
    void Update()
    {
        createsec += Time.deltaTime;

        if (dev == 1)
        {
            fpscounter += (Time.deltaTime - fpscounter) * 0.1f;
            float fps = 1.0f / fpscounter;
            fpstext.GetComponent<Text>().text = "" + (int)fps;
        }

        if (playing == 1)
        {
            Vector3 coppos = copcar.GetComponent<Transform>().transform.position;
            copcar.GetComponent<Transform>().transform.position = new Vector3(coppos.x, coppos.y, coppos.z + drivespeed * 2);

            Vector3 chasepos = chasecar.GetComponent<Transform>().transform.position;
            chasecar.GetComponent<Transform>().transform.position = new Vector3(chasepos.x, chasepos.y, chasepos.z + drivespeed * 2);

            roadcount += drivespeed * 2;

            if (right == 1 || Input.GetKey(KeyCode.D))
            {
                Right();
            }

            if (left == 1 || Input.GetKey(KeyCode.A))
            {
                Left();
            }

            int nextStarTime = StarTiming.GetThresholdForCollectedStars(nstars, starThresholds);
            if (nextStarTime > 0 && timec < nextStarTime)
            {
                timec += Time.deltaTime;
            }

            for (int i = 0; i < carnum; i++)
            {
                if (cars[i] == 0)
                {
                    int carrandom = UnityEngine.Random.Range(1, 10);
                    if (carrandom < 3)
                    {
                        carobject[i] = Instantiate(car1);
                    }
                    else if (carrandom > 2 && carrandom < 5)
                    {
                        carobject[i] = Instantiate(car2);
                    }
                    else if (carrandom > 4 && carrandom < 7)
                    {
                        carobject[i] = Instantiate(car3);
                    }
                    else if (carrandom == 7)
                    {
                        carobject[i] = Instantiate(taxi);
                    }
                    else if (carrandom == 8)
                    {
                        carobject[i] = Instantiate(bus1);
                    }
                    else if (carrandom == 9)
                    {
                        carobject[i] = Instantiate(bus2);
                    }
                    cars[i] = 1;
                    CreateCar(i, chasepos);
                    carobject[i].transform.parent = clones.transform;
                }
                else
                {
                    carpos[i] = carobject[i].GetComponent<Transform>().transform.position;
                    carobject[i].GetComponent<Transform>().transform.position = new Vector3(carpos[i].x, carpos[i].y, carpos[i].z - drivespeed);
                    if(carpos[i].z + 5 < coppos.z)
                    {
                        ChaseCollision script3 = (ChaseCollision)chasecoll.GetComponent(typeof(ChaseCollision));
                        int id = 0;
                        int.TryParse(carobject[i].gameObject.tag.ToString(), out id);
                        script3.TakenOff(id);
                        cars[i] = 0;
                        Destroy(carobject[i]);
                    }

                    if (StarTiming.ShouldSpawnStar(timec, nstars, starThresholds))
                    {
                        CreateStar(StarTiming.GetSpawnIdForCollectedStars(nstars));
                    }
                }
            }
            if(roadcount > 8)
            {
                Vector3 roadpos = road[roadobj].GetComponent<Transform>().transform.position;
                road[roadobj].GetComponent<Transform>().transform.position = new Vector3(roadpos.x, roadpos.y, roadpos.z + 160.00002f);
                roadobj++;
                if(roadobj == 21)
                {
                    roadobj = 1;
                }
                roadcount = 0;
            }

        }
    }
}
