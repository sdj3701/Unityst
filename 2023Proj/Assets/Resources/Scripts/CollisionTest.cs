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
        //리지드바디 받아오기
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

    //충돌에 떨림을 덜하게 하게 부드럽게 하는 법
    private void FixedUpdate()
    {
        float rot = Input.GetAxis("Horizontal");
        float mov = Input.GetAxis("Vertical");

        // 회전은 쿼터니언
        Quaternion deltaRot = Quaternion.Euler(new Vector3(0,rot,0) * speedRotate * Time.deltaTime);
        rigidbody.MoveRotation(rigidbody.rotation * deltaRot);

        // 이동
        Vector3 move = transform.forward * mov;
        Vector3 newPos = rigidbody.position + move * speedMove * Time.deltaTime;
        rigidbody.MovePosition(newPos);

    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject hitObject = collision.gameObject;
        print("Collider 충돌 " + hitObject.name + " 와 충돌 했다.");
    }

    //발생한 상태의
    private void OnCollisionStay(Collision collision)
    {
        GameObject hitObject = collision.gameObject;
        print("Collider 충돌 " + hitObject.name + " 와 충돌 중.");
    }

    private void OnCollisionExit(Collision collision)
    {
        GameObject hitObject = collision.gameObject;
        print("Collider 충돌 " + hitObject.name + " 와 충돌 끝.");
    }

    //콜라이더
    private void OnTriggerEnter(Collider other)
    {
        GameObject hitObject = other.gameObject;
        print("Trigger 충돌 " + hitObject.name + " 와 충돌 했다.");
    }

    private void OnTriggerStay(Collider other)
    {
        GameObject hitObject = other.gameObject;
        print("Trigger 충돌 " + hitObject.name + " 와 충돌 중.");
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject hitObject = other.gameObject;
        print("Trigger 충돌 " + hitObject.name + " 와 충돌 끝.");
    }

}

#region 노트
/*
 *  Rigidbody에서 충돌을 하는데 회전을 방지 하고 싶으면
 *  Freeze Rotation을 xz 축을 잠궈라
 *  
 *  FixedUpdate는 많은 코드를 넣지 마라
 *  움직임 코드 하나만 넣어주면 처리가 빠라져 충돌 체크에 도움이 됨
 *  
 *  레이스 종료 트레일 체크하는 법
 *  투명한 벽을 하나 만들어
 *  메쉬를 끄고 Collider에서 isTrigger를 체크
 *  그리고 OnTrigger를 사용해서 하면된다
 *  
 *  차이점 트리거
 *  둘중 하나는 리지드 바디가 필요 (움직이는 애가 가지고 있는게 좋음) isTrigger체크 필수
 *  
 *  리지드 바디에
 *  Collision Detection 정밀 충돌
 *  
 */
#endregion