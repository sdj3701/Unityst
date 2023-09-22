using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public GameObject target = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //LookAt_3();
        LookAt_2();

    }

    void LookAt_3()
    {
        Vector3 dirToTarget = target.transform.position - this.transform.position;
        transform.rotation = Quaternion.LookRotation(dirToTarget,Vector3.up);
    }

    void LookAt_2()
    {
        //Vector3 dirToTarget = target.transform.position - this.transform.position;
        transform.LookAt(target.transform);
    }

    void LookAt_1()
    {
        Vector3 dirToTarget = target.transform.position - this.transform.position;
        this.transform.forward = dirToTarget.normalized;
    }
}
