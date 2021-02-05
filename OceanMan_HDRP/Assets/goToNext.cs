using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class goToNext : MonoBehaviour
{
    private Button button;
    private Text text;
    public GameObject nextTextObject;

    private Transform parentTransform;
    private Text parentText;

    public bool isLast=false;
    public float fadeOutTime=0.4f;

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
        if(!last)
            nextTextObject.SetActive(true);
        else
            Debug.Log("Change Scene");
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
}
