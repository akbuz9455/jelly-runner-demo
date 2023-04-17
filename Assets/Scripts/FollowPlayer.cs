using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform target; // takip edilecek hedef
    public float followSpeed = 2f; // takip h�z�

    void Update()
    {
        // takip edilecek hedefin konumuna do�ru hareket et
        transform.Translate((target.position - transform.position) * followSpeed * Time.deltaTime);
    }
}
