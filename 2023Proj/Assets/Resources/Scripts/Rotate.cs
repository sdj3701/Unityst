using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float speed = 30.0f;

    public GameObject target = null;

    void Start()
    {
        //this.transform.eulerAngles = new Vector3(0.0f,45.0f,0.0f);
    }

    void Update()
    {
        //Rotate_4();
        Rotate_Around();
    }
    void Rotate_Around()
    {
        float rot = speed * Time.deltaTime;
        //transform.RotateAround(new Vector3(0.0f, 0.5f, 0.0f), Vector3.up, rot);
        transform.RotateAround(target.transform.position, Vector3.up, rot);

    }
    void Rotate_1()
    {
        Quaternion target = Quaternion.Euler(0.0f, 45.0f, 0.0f);
        this.transform.rotation = target;
        //월드 기준
    }
    void Rotate_2()
    {
        this.transform.Rotate(Vector3.up * 45.0f);
        //로컬 기준
    }
    void Rotate_3()
    {
        float rot = speed * Time.deltaTime;
        transform.rotation *= Quaternion.AngleAxis(rot, Vector3.up);
        //월드 기준
    }
    void Rotate_4()
    {
        float rot = speed * Time.deltaTime;
        transform.Rotate(rot * Vector3.up);
        //로컬 기준
    }
}
