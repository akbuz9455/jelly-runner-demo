using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyTrigger : MonoBehaviour
{
    private Color jellyStaticColor = new Color();
    private Color jellyCollectColor = new Color();
    Renderer JellyRenderer;
    public bool startJelly;
    private void Start()
    {
        JellyRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        ColorUtility.TryParseHtmlString("#B41502", out jellyCollectColor);
        if (!startJelly)
        {
            ColorUtility.TryParseHtmlString("#685E5D", out jellyStaticColor);
        
           
            JellyRenderer.materials[0].color = jellyStaticColor;
        }
       
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (tag=="JellyMan"&& (other.tag=="Player" || other.tag == "LittleJelly") && Input.GetMouseButton(0) && PlayerManager.Instance.readyCollect)
        {
            GameManager.Instance.addedScale += Vector3.one* PlayerManager.Instance.scaleFactor;
            GetComponent<JellyFollow>().StartFollow();
            JellyRenderer.materials[0].color = jellyCollectColor;

        }
        if (tag == "JellyMan" && (other.tag == "Player" || other.tag == "LittleJelly") && !Input.GetMouseButton(0) && PlayerManager.Instance.readyCollect)
        {
            Vector3 localScaleMain = GameManager.Instance.player.transform.localScale;
            GameManager.Instance.player.transform.localScale = (Vector3.one * PlayerManager.Instance.scaleFactor) + localScaleMain;

            GetComponent<JellyFollow>().StartFollow();

            gameObject.SetActive(false);
            JellyRenderer.materials[0].color = jellyCollectColor;
        }
    }
}
