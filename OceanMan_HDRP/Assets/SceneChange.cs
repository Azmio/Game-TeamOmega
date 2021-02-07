using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;

public class SceneChange : MonoBehaviour
{
    private IEnumerator coroutine;
    public float waitTime;
    private float t0;
    private bool fade = false;
    
    public Volume volume;

    

    private void OnTriggerEnter(Collider other) {
        if(other.tag=="Player")
        {
            t0 = Time.time;
            fade = true;
            coroutine = goNext();
            StartCoroutine(coroutine);
        }
    }
    private void Update()
    {
        if (fade)
            volume.weight = Mathf.Lerp(0, 1, (Time.time - t0) / (waitTime - 1));
    }
    private IEnumerator goNext()
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(3);
        
    }
}
