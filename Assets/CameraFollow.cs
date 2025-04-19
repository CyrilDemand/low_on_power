using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Le joueur à suivre
    public Vector3 offset = new Vector3(0, 0, -10); // Décalage : typique pour caméra 2D

    void LateUpdate()
    {
        if (target != null)
        {
            transform.position = target.position + offset;
        }
    }
}