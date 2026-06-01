using UnityEngine;

public partial class ChaseCollision : MonoBehaviour
{
    void Start()
    {
        taken = new int[5];
        chasecar = GameObject.Find("chasecar");
        isnow = 1;
    }

    void Update()
    {
        MoveTo();
        Vector3 pos = chasecar.GetComponent<Transform>().transform.position;

        if (ismoving == 0)
        {
            isnow = LaneLayout.GetNearestLane(pos.x);
        }
    }
}
