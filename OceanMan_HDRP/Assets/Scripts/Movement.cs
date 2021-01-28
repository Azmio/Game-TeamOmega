using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody Character;
    public float Speed = 20f;
    public float MouseSensitivity = 30f;
    public Transform MovePoint;
    public Transform MovePointLeft;
    public Transform MovePointRight;

    public Transform xAxis;
    public Transform yAxis;

    Vector3 FDir;
    Vector3 LDir;
    Vector3 RDir;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float MouseX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
        float MouseY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;

        if (Input.GetKey(KeyCode.W))
        {
            FDir = MovePoint.position - transform.position;
            Character.AddForce(FDir.normalized * Speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            LDir = MovePointLeft.position - transform.position;
            Character.AddForce(LDir.normalized * Speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            RDir = MovePointRight.position - transform.position;
            Character.AddForce(RDir.normalized * Speed * Time.deltaTime);
        }

        xAxis.Rotate(Vector3.up * MouseX);
        yAxis.Rotate(Vector3.left * MouseY);
    }
}
