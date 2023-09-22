using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;
    public Vector3 cameraPos;
    Vector3 offset = new Vector3(0f, 4f, -5f);

    float roatationSpeed = 0.05f;
    float yR;
    private float angle = 0.0f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void CameraMove()
    {
        float mouseX = Input.GetAxis("Mouse X") * roatationSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * roatationSpeed;
        //y축 회전 제한
        yR = Mathf.Clamp(yR + mouseY, 1, 8);

        angle += mouseX;

        float x = Mathf.Cos(angle) * 8;
        float z = Mathf.Sin(angle) * 8;

        cameraPos = target.transform.position + new Vector3(x, yR, z);
        transform.position = cameraPos;

        transform.LookAt(target.transform.position);

    }


    private void LateUpdate()
    {
        CameraMove();
    }

}
