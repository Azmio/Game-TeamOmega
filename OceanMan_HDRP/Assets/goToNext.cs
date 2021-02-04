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
    
    // Start is called before the first frame update
    void Start()
    {

        button = gameObject.GetComponent<Button>();
        text = gameObject.GetComponent<Text>();
        /*text.enabled = enable;
        button.enabled = enable;*/
        button.onClick.AddListener(OnClick);
        parentTransform=transform.parent;
        parentText=parentTransform.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (!isChoice)
        //{
        //    neighbor1 = GameObject.Find((int.Parse(gameObject.name) + 1).ToString());
        //}
        
    }
    private void OnClick()
    {
        /*button.enabled = false;
        text.enabled = false;*/
        ChangeTextObject(isLast);       
        //button = neighbor1.GetComponent<Button>();
        //text = neighbor1.GetComponent<Text>();
        /*button.enabled = true;
        text.enabled = true;*/
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
}
