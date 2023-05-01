using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PlayerManager : SceneDependentSingleton<PlayerManager>
{
    public SkinnedMeshRenderer skinnedMeshRenderer;
    public GameObject mainJellyForMultiMode;
    public float scaleFactor = 0.01f; // ölçek faktörü
    public float scaleInterval = 0.15f; // ölçeklendirme aralýðý (saniye)
    public GameObject grownParticle;
    public bool readyCollect;
    Vector3 scaleSizeItem;
    public bool aloneMode;

    public void ReadyCollect()
    {
        scaleFactor = 0.025f;
        readyCollect = true;
        scaleSizeItem = transform.localScale;
    }
    IEnumerator GrowthModeOnCoroutine()
    {
        if (readyCollect)
        {

        readyCollect = false;
      
      //  scaleSizeItem = transform.localScale;
 
        transform.localScale = Vector3.one;
        transform.localScale += GameManager.Instance.addedScale;
        GameManager.Instance.addedScale = Vector3.zero;

        foreach (var item in JellyManager.Instance.jellyList)
        {
            item.GetComponent<JellyFollow>().startFollow = false;
            item.GetComponent<JellyFollow>().margeParticle.GetComponent<ParticleSystem>().Play();
            item.transform.DOMove(new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z + 2f), .25f).SetEase(Ease.Linear).OnComplete(() => {

                transform.localScale += new Vector3(scaleFactor*4, scaleFactor*4, scaleFactor*4);
                item.SetActive(false);

             

            });


          
  

        }

        yield return new WaitForSeconds(scaleInterval);
     
        mainJellyForMultiMode.transform.DOMove(new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z + .5f), .3f).SetEase(Ease.InSine).OnComplete(() => {

            mainJellyForMultiMode.SetActive(false);
        });
        mainJellyForMultiMode.GetComponent<JellyFollow>().margeParticle.GetComponent<ParticleSystem>().Play();

        grownParticle.GetComponent<ParticleSystem>().Play();
            Invoke("ReadyCollect", 0.4f);

        }
        else
        {
            Invoke("GrowthModeOnCoroutine", .25f);
            readyCollect = true;
        }
    }


    IEnumerator GrowthModeOffCoroutine()
    {
        if (readyCollect)
        {

       
            readyCollect = false;
            transform.localScale = Vector3.one;
            scaleSizeItem = transform.localScale;
        
        grownParticle.GetComponent<ParticleSystem>().Play();
 
        foreach (var item in JellyManager.Instance.jellyList)
        {
           

           transform.localScale -= new Vector3(scaleFactor, scaleFactor, scaleFactor);
            item.GetComponent<JellyFollow>().startFollow = true;
            item.SetActive(true);
            item.transform.position = transform.position;
            item.GetComponent<Animator>().SetBool("Idle", false);
            item.GetComponent<Animator>().SetBool("Run", true);
            item.transform.localScale = new Vector3(1 - ((JellyManager.Instance.jellyList.Count*scaleFactor)), 1 - ((JellyManager.Instance.jellyList.Count * scaleFactor)), 1- ((JellyManager.Instance.jellyList.Count * scaleFactor)));
            Debug.Log("JellyManager.Instance.jellyList.Count*scaleFactor : "+ JellyManager.Instance.jellyList.Count * scaleFactor);
                Debug.Log("JellyManager.Instance.jellyList.Count : " + JellyManager.Instance.jellyList.Count );
                Debug.Log("scaleFactor : " +  scaleFactor);

            }
        yield return new WaitForSeconds(scaleInterval);
       
        if (JellyManager.Instance.jellyList.Count>0)
        {
            transform.DOScale(JellyManager.Instance.jellyList[0].transform.localScale, .15f);
        }
       
        mainJellyForMultiMode.SetActive(true);
        mainJellyForMultiMode.transform.position = transform.position;
        mainJellyForMultiMode.GetComponent<Animator>().SetBool("Idle", false);
        mainJellyForMultiMode.GetComponent<Animator>().SetBool("Run", true);
        Invoke("ReadyCollect", 0.4f);
        }
        else
        {
            Invoke("GrowthModeOffCoroutine", .25f);
            readyCollect = true;
        }

    }
    public void modeChange(bool aloneMod){
        if (aloneMod)
        {
           
            aloneActive();
         
            StartCoroutine(GrowthModeOnCoroutine());
            

        }
        else
        {
           
            aloneDeActive();
            StartCoroutine(GrowthModeOffCoroutine());
        }
        this.aloneMode = aloneMod;

    }
    void aloneDeActive()
    {
        GetComponent<CapsuleCollider>().isTrigger = false;
      //  skinnedMeshRenderer.enabled = false;

    }
    void aloneActive() {
        GetComponent<CapsuleCollider>().isTrigger = true;
        //skinnedMeshRenderer.enabled = true;
    }

    private void Start()
    {
        readyCollect = true;
    }
}

