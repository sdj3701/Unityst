using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAngle : MonoBehaviour
{
    float num = 0;
    float angle = 0;
    public float angleSpeed  =100.0f;
    Quaternion target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AngleTurn();
    }

    void AngleTurn()
    {
        string objectName = gameObject.name;
        //float tire = 0;
        //tire += angleSpeed * Time.deltaTime;
        //transform.Rotate(Vector3.forward,angleSpeed * Time.deltaTime);
        //transform.rotation = Quaternion.Euler(1* angleSpeed ,0,0);
        num += 1 ;
        if(objectName == "Cylinder")
            target = Quaternion.Euler(num, 0f, 90.0f);
        else
            target = Quaternion.Euler(num, 0f, -90.0f);



        float inputKey = Input.GetAxis("Horizontal");

        angle += inputKey;

        if (angle > 45) angle = 45;
        if (angle < -45) angle = -45;

        if (objectName == "Cylinder")
            target = Quaternion.Euler(num, angle, 90.0f);
        else
            target = Quaternion.Euler(num, angle, -90.0f);

        this.transform.rotation = target;
    }

}
