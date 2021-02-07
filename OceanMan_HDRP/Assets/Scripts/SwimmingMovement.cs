using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SwimmingMovement : MonoBehaviour
{
    CharacterController controller;
    public float speed = 0.7f;
    private float targetSpeed;
    public float speedVariationRate;

    private float targetFxIntensity;
    public float intensityRate;

    public float sensitivity = 1f;
    public Light spot1;
    public Light spot2;
    private Transform transf;
    private float yaw = 0.0f;
    private float pitch = 0.0f;
    private Volume fx;
    // Start is called before the first frame update
    void Start()
    {  
        controller = GetComponent<CharacterController>();
        transf = gameObject.transform;
        targetSpeed = speed;
        fx = gameObject.GetComponent<Volume>();
        targetFxIntensity = fx.weight;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 move = transf.right * Input.GetAxis("Horizontal") + transf.forward * Input.GetAxis("Forward") + transf.up * Input.GetAxis("Vertical");
        controller.Move(move * Time.deltaTime * speed);
        yaw += Input.GetAxis("Mouse X") * sensitivity;
        pitch -= Input.GetAxis("Mouse Y") * sensitivity;

        transf.localEulerAngles = new Vector3(pitch, yaw, 0.0f);

        // Update speed
        speed = GetUpdatedValue(speed, targetSpeed, speedVariationRate);
        fx.weight = GetUpdatedValue(fx.weight, targetFxIntensity, intensityRate);
    }

    private float GetUpdatedValue(float a, float b, float rate)
    {
        if (b - a != 0)
            return Mathf.Lerp(a, b, rate * Time.deltaTime / Mathf.Abs(b - a));
        else
            return a;
    }

    private void OnTriggerEnter(Collider other)
    {
        SpeedFxTriggerBehavior script;
        if (script = other.gameObject.GetComponent<SpeedFxTriggerBehavior>())
        {
            targetSpeed = script.speed;
            targetFxIntensity = script.fxIntensity;
            if (script.spotlight == 1)
            {
                spot1.enabled = true;
                spot2.enabled = false;
            } else
            {
                spot1.enabled = false;
                spot2.enabled = true;
            }
            
        }
        
    }
}
