using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastEx : MonoBehaviour
{

    [Range(0, 50)]
    public float distance = 10.0f;
    //레이캐스트 결과를 저장할 변수
    private RaycastHit rayHit;
    //어느 방향으로 쏘면
    private Ray ray;
    //배열
    private RaycastHit[] rayHits;
    
    void Start()
    {
        ray = new Ray();
        //오리진 위치는 어디냐
        ray.origin = this.transform.position;
        ray.direction = this.transform.forward ;
        //ray = new Ray(this.transform.position, this.transform.forward); 위와 같음
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
            //Layer이름이 Cube인 애만 나오게 하겠다. LayerMask의 특징이다 소팅 레이어는 2d에 유용하다 플레이어는 앞 적은 뒤에 출력할 수 있다.
            if (rayHits[index].collider.gameObject.layer == LayerMask.NameToLayer("Cube"))
                Debug.Log(rayHits[index].collider.gameObject.name + "Hit!! - Layer");

            //테그 일때
            if (rayHits[index].collider.gameObject.tag == "Sphere")
                Debug.Log(rayHits[index].collider.gameObject.name + "Hit!! - Tag");
        }
    }

    void Ray_3()
    {
        //spherecast 원통으로 체크
        //overrab 슈류탄 일정 범위 안에 데미지를 넣고 싶을 때 사용
        //콜라이더 회전이 너무 빠르면 체크를 못하느데 overrab을 사용하면 좋다
        rayHits = Physics.SphereCastAll(ray, 2.0f, distance);
        string objName = "";
        foreach (RaycastHit hit in rayHits)
            objName += hit.collider.name + " , ";
        print(objName);

    }
    
    void Ray_2()
    {
        //배열로 확인 전체
        rayHits = Physics.RaycastAll(ray,distance);

        for(int index = 0;index < rayHits.Length;index++)
        { 
            Debug.Log(rayHits[index].collider.gameObject.name + "Hit!!");
        }

    }

    void Ray_1()
    {
        //앞에 있는것만 확인
        if (Physics.Raycast(ray.origin, ray.direction, out rayHit, distance))
        {
            Debug.Log(rayHit.collider.gameObject.name);
        }
    }

    private void OnDrawGizmos()
    {
        //Debug.DrawRay(ray.origin, ray.direction * distance, Color.red);
        //ray.direction은 방향 벡터이므로 distance를 곱해야 원하는 길이 설정을 할수 있다.
        Gizmos.DrawLine(ray.origin, ray.direction * distance + ray.origin);

        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(ray.origin, 0.1f);

        //반사
        if(this.rayHits != null)
        {
            for(int i =0;i<this.rayHits.Length;i++)
            {

                //collision point
                Gizmos.color = Color.red;
                //맞으면 원을 그려라
                Gizmos.DrawSphere(this.rayHits[i].point, 0.1f);

                //draw line 맞은 애들 까지 색이 변함
                Gizmos.color = Color.cyan;
                Gizmos.DrawLine(this.transform.position, transform.forward * rayHits[i].distance + ray.origin);

                // : normal vector 
                Gizmos.color = Color.yellow;
                Gizmos.DrawLine(this.rayHits[i].point , this.rayHits[i].point + this.rayHits[i].normal);

                // : reflection vector 반사각
                Gizmos.color = new Color(255.0f,0.0f, 255.0f);
                Vector3 reflect = Vector3.Reflect(this.transform.forward, this.rayHits[i].normal);
                Gizmos.DrawLine(this.rayHits[i].point , rayHits[i].point + reflect);
            }
        }

    }

}

#region 노트
/*
    레이케스트를 사용할 때 오브젝은 안에 있는지 확인하면 좋다.
    안에 있으면 자기 자신이 맞을수 도 있다.

    디버그 관련한 모든 것들은 update에서 사용하면 좋지 않다.
    
    레이마스크라는게 있는데 원하는 애들만 검출하겠다.




*/

#endregion