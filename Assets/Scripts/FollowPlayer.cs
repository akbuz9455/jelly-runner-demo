using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform target; // takip edilecek hedef
    public float followSpeed = 2f; // takip hýzý

    void Update()
    {
        // takip edilecek hedefin konumuna doðru hareket et
        transform.Translate((target.position - transform.position) * followSpeed * Time.deltaTime);
    }
}
