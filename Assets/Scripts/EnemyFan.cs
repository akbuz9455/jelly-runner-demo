using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFan : MonoBehaviour
{

    public bool left;
    private void OnTriggerStay(Collider other)
    {
        if ((other.tag == "Player"|| other.tag == "LittleJelly") && Input.GetMouseButton(0))
        {
            if (left)
            {
                other.transform.position = new Vector3(other.transform.position.x+.15f, other.transform.position.y, other.transform.position.z- 0.1f);
            }
            else
            {
                other.transform.position = new Vector3(other.transform.position.x - .15f, other.transform.position.y, other.transform.position.z - 0.1f);
            }
          
        }
 
    }
}
