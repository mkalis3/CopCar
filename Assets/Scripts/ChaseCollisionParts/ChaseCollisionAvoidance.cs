using UnityEngine;

public partial class ChaseCollision : MonoBehaviour
{
    const float LaneChangeSpeed = 0.06f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name.Contains("road") || collision.collider.name.Contains("Plane"))
        {
            return;
        }

        int id;
        if (!int.TryParse(collision.collider.gameObject.tag.ToString(), out id) || !LaneLayout.IsValidLane(id))
        {
            return;
        }

        taken[id] = 1;
        bool currentLaneBlocked = isnow == id && ismoving == 0;
        bool targetLaneBlocked = movingto == id && ismoving == 1;
        if (currentLaneBlocked || targetLaneBlocked)
        {
            BeginMoveToLane(ChaseLaneDecision.SelectTargetLane(isnow, taken, UnityEngine.Random.Range(1, 3)));
        }
    }

    void BeginMoveToLane(int lane)
    {
        movingdir = 0;
        movingto = lane;
        ismoving = 1;
    }

    void MoveTo()
    {
        if (ismoving != 1)
        {
            return;
        }

        Vector3 pos = chasecar.GetComponent<Transform>().transform.position;
        float targetX = LaneLayout.GetX(movingto);
        if (movingdir == 0)
        {
            movingdir = pos.x < targetX ? 1 : 2;
        }

        float nextX = movingdir == 1 ? pos.x + LaneChangeSpeed : pos.x - LaneChangeSpeed;
        bool reachedTarget = movingdir == 1 ? nextX >= targetX : nextX <= targetX;
        if (reachedTarget)
        {
            nextX = targetX;
            isnow = movingto;
            ismoving = 0;
        }

        chasecar.GetComponent<Transform>().transform.position = new Vector3(nextX, pos.y, pos.z);
    }

    public void TakenOff(int id)
    {
        if (LaneLayout.IsValidLane(id))
        {
            taken[id] = 0;
        }
    }
}
