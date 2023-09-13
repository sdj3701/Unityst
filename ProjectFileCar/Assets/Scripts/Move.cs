using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class Move : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public Angle turnangle;
    Rigidbody rigidbody;
    int count;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = this.gameObject.GetComponent<Rigidbody>();
        turnangle.turn = 0;
    }

    private void FixedUpdate()
    {
        AutomaticMove();

    }

    // Update is called once per frame
    void Update()
    {
    }

    void InputMove()
    {
        //angle에 있는 변수 값을 받아 사용하기
        float valueAngle = turnangle.turn;
        float move = Input.GetAxis("Vertical");
        this.transform.Translate(new Vector3(-1f, 0, 0) * Time.deltaTime * moveSpeed * move);

        if(move == 0)
            this.transform.Rotate(new Vector3(0,0,0));
        else
            this.transform.Rotate(Vector3.up * (valueAngle/100));
    }

    //ray를 받아와서 한쪽 거리가 짧아지면 반대로 회전을 줌
    public void AutomaticMove()
    {
        float valueAngle = turnangle.turn;
        float move = 0;
        move += 0.5f;

        this.transform.Translate(new Vector3(-1f, 0, 0) * Time.deltaTime * moveSpeed * move);
        if (move == 0)
        {
            this.transform.Rotate(new Vector3(0, 0, 0));
        }
        else
        {
            this.transform.Rotate(Vector3.up * (valueAngle) * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject hitObject = other.gameObject;

        if(hitObject.name == "EndLine") 
        {
            count++;
        }
        //car에 있는 물체를 전부 검사를 해서 값이 크게 증가
        if (hitObject.name == "EndLine" && count >= 10)
        {
            GameManager.Instance.ChangeSecen("EndScene");

        }
    }
    //스타트 씬에서 main씬으로 넘어가면 물체는 이동을 하는데 센서가 작동이 안됨 그런나 car를 클릭을 하면 작동이 됨?
}


