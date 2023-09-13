using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    //누구를 따라 갈 것인가?
    public Transform target;
    //거리는 30정도?
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
