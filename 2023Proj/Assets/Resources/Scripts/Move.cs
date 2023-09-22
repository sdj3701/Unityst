using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float moveSpeed = 10.0f;

void Start()
    {
        //this.transform.position = new Vector3(0.0f, 5.0f, 0.0f);
        //���� ��ǥ �������� �̵� 5.0f�� �̵�
        this.transform.Translate(new Vector3(0.0f, 5.0f, 0.0f));
        //������ǥ �̵� 5.5f�̵��� ��
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
        //���� ��ǥ
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
        //Time.deltaTime = �����ð�
        //if(oldTime - newTime <30)
        //gap = newTime - oldTime;
        //oldTime = newTime - gap;
        this.transform.Translate(Vector3.forward * moveDelta);
    }

}
