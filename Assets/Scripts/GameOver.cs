using UnityEngine;

public class GameOver : MonoBehaviour
{
    GameObject copcar;

    void Start()
    {
        copcar = GameObject.Find("copcar");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.name.Contains("road") && !collision.collider.name.Contains("Plane") && !collision.collider.name.Contains("star") && !collision.collider.name.Contains("cop") && !collision.collider.name.Contains("Cube") && !collision.collider.name.Contains("Game"))
        {
            MainScript script = (MainScript)copcar.GetComponent(typeof(MainScript));
            script.EndLevel();
        }
    }
}
