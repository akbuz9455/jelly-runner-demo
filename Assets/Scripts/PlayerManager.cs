using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PlayerManager : SceneDependentSingleton<PlayerManager>
{
    public SkinnedMeshRenderer skinnedMeshRenderer;
    public GameObject mainJellyForMultiMode;
    public float scaleFactor = 0.1f; // ölçek faktörü
    public float scaleInterval = 0.075f; // ölçeklendirme aralýðý (saniye)
    public GameObject grownParticle;
    public bool readyCollect;
    

    public void ReadyCollect()
    {
        readyCollect = true;

    }
    IEnumerator GrowthModeOnCoroutine()
    {
        readyCollect = false;
        foreach (var item in JellyManager.Instance.jellyList)
        {
            item.GetComponent<JellyFollow>().startFollow = false;
            item.GetComponent<JellyFollow>().margeParticle.GetComponent<ParticleSystem>().Play();
              item.transform.DOMove(new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z + 2f), .35f).SetEase(Ease.Linear).OnComplete(() => {
                
                
                item.SetActive(false); 
                
                
               transform.localScale += new Vector3(scaleFactor, scaleFactor, scaleFactor);
            });

           
             
            
            yield return new WaitForSeconds(scaleInterval);
        }
        mainJellyForMultiMode.transform.DOMove(new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z + .5f), .3f).SetEase(Ease.InSine).OnComplete(() => {

            mainJellyForMultiMode.SetActive(false);
        });
        mainJellyForMultiMode.GetComponent<JellyFollow>().margeParticle.GetComponent<ParticleSystem>().Play();

        grownParticle.GetComponent<ParticleSystem>().Play();
        Invoke("ReadyCollect", 1.1f);
    }


    IEnumerator GrowthModeOffCoroutine()
    {
        readyCollect = false;
        Vector3 scaleSizeItem = transform.localScale;
        grownParticle.GetComponent<ParticleSystem>().Play();
        foreach (var item in JellyManager.Instance.jellyList)
        {
           

           transform.localScale -= new Vector3(scaleFactor, scaleFactor, scaleFactor);
            item.GetComponent<JellyFollow>().startFollow = true;
            item.SetActive(true);
            item.transform.position = transform.position;
            item.GetComponent<Animator>().SetBool("Idle", false);
            item.GetComponent<Animator>().SetBool("Run", true);
            item.transform.localScale = new Vector3(scaleSizeItem.x-(JellyManager.Instance.jellyList.Count*scaleFactor * 1.25f), scaleSizeItem.y - (JellyManager.Instance.jellyList.Count * scaleFactor *1.25f), scaleSizeItem.z - (JellyManager.Instance.jellyList.Count * scaleFactor * 1.25f));

                yield return new WaitForSeconds(scaleInterval);
        }
        GameManager.Instance.firstJelly.transform.localScale = new Vector3(scaleSizeItem.x - (JellyManager.Instance.jellyList.Count * scaleFactor * 1.25f), scaleSizeItem.y - (JellyManager.Instance.jellyList.Count * scaleFactor  *1.25f), scaleSizeItem.z - (JellyManager.Instance.jellyList.Count * scaleFactor  *1.25f));

        mainJellyForMultiMode.SetActive(true);
        mainJellyForMultiMode.transform.position = transform.position;
        mainJellyForMultiMode.GetComponent<Animator>().SetBool("Idle", false);
        mainJellyForMultiMode.GetComponent<Animator>().SetBool("Run", true);
        Invoke("ReadyCollect", 1.1f);

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

    }
    void aloneDeActive()
    {
        GetComponent<CapsuleCollider>().isTrigger = false;
        skinnedMeshRenderer.enabled = false;

    }
    void aloneActive() {
        GetComponent<CapsuleCollider>().isTrigger = true;
        skinnedMeshRenderer.enabled = true;
    }

    private void Start()
    {
        readyCollect = true;
    }
}

