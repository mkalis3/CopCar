using UnityEngine;

public class EndColl : MonoBehaviour
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
            MainScript script = (MainScript)copcar.GetComponent(typeof(MainScript));
            script.EndLevel();
        }
    }
}
