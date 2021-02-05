using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class goToNext : MonoBehaviour
{
    private Button button;
    private Text text;
    public GameObject nextTextObject;

    private Transform parentTransform;
    private Text parentText;

    public bool isFirst=false;
    public bool isLast=false;
    public float fadeOutTime=0.4f;

    public float fadeInTime=1f;
    public CanvasGroup canvasGroup=null;

    
    
    // Start is called before the first frame update
    void Start()
    {

        button = gameObject.GetComponent<Button>();
        text = gameObject.GetComponent<Text>();
        button.onClick.AddListener(OnClick);
        parentTransform=transform.parent;
        parentText=parentTransform.GetComponent<Text>();
        canvasGroup= gameObject.GetComponent<CanvasGroup>();
        FadeIn(isFirst);
    }

    private void OnClick()
    {
           FadeOut(HasParent());
    }

    private void ChangeTextObject(bool last){

        if(HasParent()){
            parentTransform.gameObject.SetActive(false);
        }
        else{
            this.gameObject.SetActive(false);
        }
        if(!last){
            nextTextObject.SetActive(true);
        }
            
        else{
            SceneManager.LoadScene(1);
        }
            
    }

    private bool HasParent(){
        if(parentText!=null)
            return true;
        return false;
    }

             //Fade time in seconds

         public void FadeOut(bool hasParent)
         {
            StartCoroutine(FadeOutRoutine(hasParent));
         }
         private IEnumerator FadeOutRoutine(bool hasParent)
         { 
             if(hasParent){
                 canvasGroup=parentTransform.GetComponent<CanvasGroup>();
             }
            for (float t = 0.01f; t < fadeOutTime; t += Time.deltaTime)
             {
                    //text.color = Color.Lerp(originalButtonColor, Color.clear, Mathf.Min(1, t/fadeOutTime));    
                    canvasGroup.alpha=Mathf.Lerp(1, 0, Mathf.Min(1, t/fadeOutTime));
                    yield return null;
             }

             ChangeTextObject(isLast);    
         }
         
         public void FadeIn(bool isFirst)
         {
            StartCoroutine(FadeInRoutine(isFirst));

         }
         private IEnumerator FadeInRoutine(bool isFirst)
         {
            canvasGroup=gameObject.GetComponent<CanvasGroup>();
            if(HasParent()){

                canvasGroup=parentTransform.GetComponent<CanvasGroup>();
            }
            if(!isFirst)
            for (float t = 0.01f; t < fadeInTime; t += Time.deltaTime)
             {
                    //text.color = Color.Lerp(originalButtonColor, Color.clear, Mathf.Min(1, t/fadeOutTime));    
                    canvasGroup.alpha=Mathf.Lerp(0, 1, Mathf.Min(1, t/fadeInTime));
                    yield return null;
             }
             else
             yield break;
   
         }
}
