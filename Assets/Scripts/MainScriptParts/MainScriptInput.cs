using UnityEngine;

public partial class MainScript : MonoBehaviour
{
    public void RightDown()
    {
        right = 1;
    }

    public void RightUp()
    {
        right = 0;
    }

    public void Right()
    {
        Vector3 coppos = copcar.GetComponent<Transform>().transform.position;
        if (coppos.x < LaneLayout.RightEdgeX)
        {
            copcar.GetComponent<Transform>().transform.position = new Vector3(coppos.x + 0.06f, coppos.y, coppos.z);
        }
    }

    public void LeftDown()
    {
        left = 1;
    }

    public void LeftUp()
    {
        left = 0;
    }

    public void Left()
    {
        Vector3 coppos = copcar.GetComponent<Transform>().transform.position;
        if (coppos.x > LaneLayout.LeftEdgeX)
        {
            copcar.GetComponent<Transform>().transform.position = new Vector3(coppos.x - 0.06f, coppos.y, coppos.z);
        }
    }
}
