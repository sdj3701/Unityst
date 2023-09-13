using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    //������ ���� �� ���ΰ�?
    public Transform target;
    //�Ÿ��� 30����?
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(target !=null)
        {
            transform.position = target.transform.position + offset;
        }
    }
    
}
