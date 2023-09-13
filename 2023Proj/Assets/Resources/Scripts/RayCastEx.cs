using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastEx : MonoBehaviour
{

    [Range(0, 50)]
    public float distance = 10.0f;
    //����ĳ��Ʈ ����� ������ ����
    private RaycastHit rayHit;
    //��� �������� ���
    private Ray ray;
    //�迭
    private RaycastHit[] rayHits;
    
    void Start()
    {
        ray = new Ray();
        //������ ��ġ�� ����
        ray.origin = this.transform.position;
        ray.direction = this.transform.forward ;
        //ray = new Ray(this.transform.position, this.transform.forward); ���� ����
    }

    // Update is called once per frame
    void Update()
    {

        Ray_4();

    }

    void Ray_4()
    {
        ray.origin = this.transform.position;
        ray.direction = this.transform.forward;

        rayHits = Physics.RaycastAll(ray, distance);

        for (int index = 0; index < rayHits.Length; index++)
        {
            //Layer�̸��� Cube�� �ָ� ������ �ϰڴ�. LayerMask�� Ư¡�̴� ���� ���̾�� 2d�� �����ϴ� �÷��̾�� �� ���� �ڿ� ����� �� �ִ�.
            if (rayHits[index].collider.gameObject.layer == LayerMask.NameToLayer("Cube"))
                Debug.Log(rayHits[index].collider.gameObject.name + "Hit!! - Layer");

            //�ױ� �϶�
            if (rayHits[index].collider.gameObject.tag == "Sphere")
                Debug.Log(rayHits[index].collider.gameObject.name + "Hit!! - Tag");
        }
    }

    void Ray_3()
    {
        //spherecast �������� üũ
        //overrab ����ź ���� ���� �ȿ� �������� �ְ� ���� �� ���
        //�ݶ��̴� ȸ���� �ʹ� ������ üũ�� ���ϴ��� overrab�� ����ϸ� ����
        rayHits = Physics.SphereCastAll(ray, 2.0f, distance);
        string objName = "";
        foreach (RaycastHit hit in rayHits)
            objName += hit.collider.name + " , ";
        print(objName);

    }
    
    void Ray_2()
    {
        //�迭�� Ȯ�� ��ü
        rayHits = Physics.RaycastAll(ray,distance);

        for(int index = 0;index < rayHits.Length;index++)
        { 
            Debug.Log(rayHits[index].collider.gameObject.name + "Hit!!");
        }

    }

    void Ray_1()
    {
        //�տ� �ִ°͸� Ȯ��
        if (Physics.Raycast(ray.origin, ray.direction, out rayHit, distance))
        {
            Debug.Log(rayHit.collider.gameObject.name);
        }
    }

    private void OnDrawGizmos()
    {
        //Debug.DrawRay(ray.origin, ray.direction * distance, Color.red);
        //ray.direction�� ���� �����̹Ƿ� distance�� ���ؾ� ���ϴ� ���� ������ �Ҽ� �ִ�.
        Gizmos.DrawLine(ray.origin, ray.direction * distance + ray.origin);

        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(ray.origin, 0.1f);

        //�ݻ�
        if(this.rayHits != null)
        {
            for(int i =0;i<this.rayHits.Length;i++)
            {

                //collision point
                Gizmos.color = Color.red;
                //������ ���� �׷���
                Gizmos.DrawSphere(this.rayHits[i].point, 0.1f);

                //draw line ���� �ֵ� ���� ���� ����
                Gizmos.color = Color.cyan;
                Gizmos.DrawLine(this.transform.position, transform.forward * rayHits[i].distance + ray.origin);

                // : normal vector 
                Gizmos.color = Color.yellow;
                Gizmos.DrawLine(this.rayHits[i].point , this.rayHits[i].point + this.rayHits[i].normal);

                // : reflection vector �ݻ簢
                Gizmos.color = new Color(255.0f,0.0f, 255.0f);
                Vector3 reflect = Vector3.Reflect(this.transform.forward, this.rayHits[i].normal);
                Gizmos.DrawLine(this.rayHits[i].point , rayHits[i].point + reflect);
            }
        }

    }

}

#region ��Ʈ
/*
    �����ɽ�Ʈ�� ����� �� �������� �ȿ� �ִ��� Ȯ���ϸ� ����.
    �ȿ� ������ �ڱ� �ڽ��� ������ �� �ִ�.

    ����� ������ ��� �͵��� update���� ����ϸ� ���� �ʴ�.
    
    ���̸���ũ��°� �ִµ� ���ϴ� �ֵ鸸 �����ϰڴ�.




*/

#endregion