using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform target; // takip edilecek hedef
    public float followSpeed = 2f; // takip h�z�

    private void FixedUpdate()
    {
        transform.position = target.transform.position;
    }
}
