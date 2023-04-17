using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    public static TargetManager Instance;
  public  List<GameObject> TargetList = new List<GameObject>();

    private void Awake()
    {
        Instance = this;
        if (transform.childCount > 0)
        {
            // Loop through all child objects
            foreach (Transform child in transform)
            {
                // Add child to list
                TargetList.Add(child.gameObject);
            }
        }
    }
    public void removeTarget(GameObject currentTarget)
    {
        if (currentTarget.GetComponent<TargetState>()!=null)
        {
            currentTarget.GetComponent<TargetState>().isFill = false;
        }
       

    }
    public GameObject CheckFreeTarget()
    {
        GameObject currentObj= TargetList[0];

       

        for (int i = 0; i < TargetList.Count; i++)
        {
            if (!TargetList[i].GetComponent<TargetState>().isFill)
            {
                currentObj = TargetList[i];

                break;
            }
        }

   

        currentObj.GetComponent<TargetState>().isFill=true;

        return currentObj;


    }

}
