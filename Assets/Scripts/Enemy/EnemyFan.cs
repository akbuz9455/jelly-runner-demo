using UnityEngine;
using DG.Tweening;
public class EnemyFan : MonoBehaviour
{

    public bool left;
    private void OnTriggerStay(Collider other)
    {
        if ((other.tag == "Player"|| other.tag == "LittleJelly") && Input.GetMouseButton(0))
        {
            if (left)
            {
                other.transform.DOMoveX(other.transform.position.x + 1.15f,.25f).SetEase(Ease.OutSine);
            }
            else
            {
                other.transform.DOMoveX(other.transform.position.x -1.15f, .25f).SetEase(Ease.OutSine);
            }
          
        }
 
    }
}
