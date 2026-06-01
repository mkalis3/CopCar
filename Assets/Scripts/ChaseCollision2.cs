using UnityEngine;

public class ChaseCollision2 : MonoBehaviour
{
    GameObject chasecoll;

    void Start()
    {
        chasecoll = GameObject.Find("chasecoll");
    }

    private void OnCollisionEnter(Collision collision)
    {
        ChaseCollision script = (ChaseCollision)chasecoll.GetComponent(typeof(ChaseCollision));
        int id;
        if (int.TryParse(collision.collider.gameObject.tag.ToString(), out id))
        {
            script.TakenOff(id);
        }
    }
}
