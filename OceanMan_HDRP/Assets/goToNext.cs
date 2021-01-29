using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class goToNext : MonoBehaviour
{
    public bool isChoice;
    private Button button;
    private Text text;
    private GameObject neighbor1;
    private GameObject neighbor2;
    public bool enable;
    
    // Start is called before the first frame update
    void Start()
    {

        button = gameObject.GetComponent<Button>();
        text = gameObject.GetComponent<Text>();
        /*text.enabled = enable;
        button.enabled = enable;*/
        button.onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isChoice)
        {
            neighbor1 = GameObject.Find((int.Parse(gameObject.name) + 1).ToString());
        }
    }
    private void OnClick()
    {
        /*button.enabled = false;
        text.enabled = false;*/

        
        button = neighbor1.GetComponent<Button>();
        text = neighbor1.GetComponent<Text>();
        /*button.enabled = true;
        text.enabled = true;*/
    }
}
