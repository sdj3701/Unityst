using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float moveSpeed = 10.0f;

void Start()
    {
        //this.transform.position = new Vector3(0.0f, 5.0f, 0.0f);
        //월드 좌표 기준으로 이동 5.0f로 이동
        this.transform.Translate(new Vector3(0.0f, 5.0f, 0.0f));
        //로컬좌표 이동 5.5f이동을 함
    }

    void Update()
    {
        //Move_2();
        Move_Control();
    }
    void Move_Control()
    {
        float move = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward *Time.deltaTime * moveSpeed * move);
        //로컬 좌표
        float trun = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed * trun);
    }

    void Move_1()
    {
        float moveDelta = this.moveSpeed * Time.deltaTime;
        Vector3 pos = this.transform.position;
        pos.z += moveDelta;
        this.transform.position = pos;
    }

    void Move_2()
    {
        float moveDelta = this.moveSpeed * Time.deltaTime;
        //Time.deltaTime = 지연시간
        //if(oldTime - newTime <30)
        //gap = newTime - oldTime;
        //oldTime = newTime - gap;
        this.transform.Translate(Vector3.forward * moveDelta);
    }

}
