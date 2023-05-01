using UnityEngine;
using DG.Tweening;
public class StarCollectable : MonoBehaviour
{
    public GameObject starParticle;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player" || other.tag == "JellyTrigger" )
        {
            starParticle.GetComponent<ParticleSystem>().Play();
            starParticle.transform.parent = null;
            transform.DOScale(Vector3.zero,.35f).SetEase(Ease.OutBounce);
        }

    }
}
