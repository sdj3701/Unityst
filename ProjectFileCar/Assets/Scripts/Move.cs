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
        //angle�� �ִ� ���� ���� �޾� ����ϱ�
        float valueAngle = turnangle.turn;
        float move = Input.GetAxis("Vertical");
        this.transform.Translate(new Vector3(-1f, 0, 0) * Time.deltaTime * moveSpeed * move);

        if(move == 0)
            this.transform.Rotate(new Vector3(0,0,0));
        else
            this.transform.Rotate(Vector3.up * (valueAngle/100));
    }

    //ray�� �޾ƿͼ� ���� �Ÿ��� ª������ �ݴ�� ȸ���� ��
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
        //car�� �ִ� ��ü�� ���� �˻縦 �ؼ� ���� ũ�� ����
        if (hitObject.name == "EndLine" && count >= 10)
        {
            GameManager.Instance.ChangeSecen("EndScene");

        }
    }
    //��ŸƮ ������ main������ �Ѿ�� ��ü�� �̵��� �ϴµ� ������ �۵��� �ȵ� �׷��� car�� Ŭ���� �ϸ� �۵��� ��?
}


