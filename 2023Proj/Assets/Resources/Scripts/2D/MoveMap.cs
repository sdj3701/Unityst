using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;

public class MoveMap : MonoBehaviour
{
    public float speed = 10.0f;
    Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float moveMap = Mathf.Repeat(Time.time * speed, 1900f);
        transform.position = startPos + Vector3.left * moveMap;
    }

}
