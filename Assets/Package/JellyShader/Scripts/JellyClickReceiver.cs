using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyClickReceiver : MonoBehaviour {

    RaycastHit hit;
    Ray clickRay;

    Renderer modelRenderer;
    float controlTime;

	// Use this for initialization
	void Start () {
        modelRenderer = GetComponent<SkinnedMeshRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        controlTime += Time.deltaTime;


            clickRay = Camera.main.ScreenPointToRay(Input.mousePosition);

          
                controlTime = 0;

                modelRenderer.material.SetVector("_ModelOrigin", transform.position);
           
            
        

        modelRenderer.material.SetFloat("_ControlTime", controlTime);
	}
}
