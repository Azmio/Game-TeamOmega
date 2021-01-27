using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody Character;
    public float MouseSensitivity = 30f;
    public Transform MovePoint;
    Vector3 Dir;
    public Transform xAxis;
    public Transform yAxis;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float MouseX = Input.GetAxisRaw("Mouse X");
        float MouseY = Input.GetAxisRaw("Mouse Y");

        if (Input.GetKey(KeyCode.W))
        {
            Dir = MovePoint.position - transform.position;
            Character.AddForce(Dir.normalized * 20f * Time.deltaTime);
        }

        if (MouseX > 0)
            xAxis.Rotate(Vector3.up.normalized * MouseSensitivity * Time.deltaTime, Space.Self);

        if (MouseX < 0)
            xAxis.Rotate(Vector3.down.normalized * MouseSensitivity * Time.deltaTime, Space.Self);

        if (MouseY > 0)
            yAxis.Rotate(Vector3.left.normalized * MouseSensitivity * Time.deltaTime, Space.Self);

        if (MouseY < 0)
            yAxis.Rotate(Vector3.right.normalized * MouseSensitivity * Time.deltaTime, Space.Self);

    }
}
