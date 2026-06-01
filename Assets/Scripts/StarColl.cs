using UnityEngine;

public class StarColl : MonoBehaviour
{
    GameObject copcar;

    void Start()
    {
        copcar = GameObject.Find("copcar");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "copcar")
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
