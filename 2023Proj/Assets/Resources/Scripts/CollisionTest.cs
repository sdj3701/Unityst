using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour
{

    float speedMove = 10.0f;
    float speedRotate = 100.0f;
    Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        //������ٵ� �޾ƿ���
        rigidbody = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        /*float rot = Input.GetAxis("Horizontal");
        float mov = Input.GetAxis("Vertical");
        
        rot  = rot * speedRotate * Time.deltaTime;
        mov = mov * speedMove * Time.deltaTime;

        this.gameObject.transform.Rotate(Vector3.up * rot);
        this.gameObject.transform.Translate(Vector3.forward * mov);*/
    }

    //�浹�� ������ ���ϰ� �ϰ� �ε巴�� �ϴ� ��
    private void FixedUpdate()
    {
        float rot = Input.GetAxis("Horizontal");
        float mov = Input.GetAxis("Vertical");

        // ȸ���� ���ʹϾ�
        Quaternion deltaRot = Quaternion.Euler(new Vector3(0,rot,0) * speedRotate * Time.deltaTime);
        rigidbody.MoveRotation(rigidbody.rotation * deltaRot);

        // �̵�
        Vector3 move = transform.forward * mov;
        Vector3 newPos = rigidbody.position + move * speedMove * Time.deltaTime;
        rigidbody.MovePosition(newPos);

    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject hitObject = collision.gameObject;
        print("Collider �浹 " + hitObject.name + " �� �浹 �ߴ�.");
    }

    //�߻��� ������
    private void OnCollisionStay(Collision collision)
    {
        GameObject hitObject = collision.gameObject;
        print("Collider �浹 " + hitObject.name + " �� �浹 ��.");
    }

    private void OnCollisionExit(Collision collision)
    {
        GameObject hitObject = collision.gameObject;
        print("Collider �浹 " + hitObject.name + " �� �浹 ��.");
    }

    //�ݶ��̴�
    private void OnTriggerEnter(Collider other)
    {
        GameObject hitObject = other.gameObject;
        print("Trigger �浹 " + hitObject.name + " �� �浹 �ߴ�.");
    }

    private void OnTriggerStay(Collider other)
    {
        GameObject hitObject = other.gameObject;
        print("Trigger �浹 " + hitObject.name + " �� �浹 ��.");
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject hitObject = other.gameObject;
        print("Trigger �浹 " + hitObject.name + " �� �浹 ��.");
    }

}

#region ��Ʈ
/*
 *  Rigidbody���� �浹�� �ϴµ� ȸ���� ���� �ϰ� ������
 *  Freeze Rotation�� xz ���� ��Ŷ�
 *  
 *  FixedUpdate�� ���� �ڵ带 ���� ����
 *  ������ �ڵ� �ϳ��� �־��ָ� ó���� ������ �浹 üũ�� ������ ��
 *  
 *  ���̽� ���� Ʈ���� üũ�ϴ� ��
 *  ������ ���� �ϳ� �����
 *  �޽��� ���� Collider���� isTrigger�� üũ
 *  �׸��� OnTrigger�� ����ؼ� �ϸ�ȴ�
 *  
 *  ������ Ʈ����
 *  ���� �ϳ��� ������ �ٵ� �ʿ� (�����̴� �ְ� ������ �ִ°� ����) isTriggerüũ �ʼ�
 *  
 *  ������ �ٵ�
 *  Collision Detection ���� �浹
 *  
 */
#endregion