using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    [Range(0, 50)]
    public float distance = 5.0f;
    private RaycastHit rayHit;
    Ray ray;

    float rotationAngle = 45.0f;
    Vector3 rightrotatedDirection;
    Vector3 leftrotatedDirection;

    public GameObject car;
    public Angle turnangle;
    Move moving;

    void Start()
    {
        moving = car.GetComponent<Move>();
        ray = new Ray();
        ray.origin = this.transform.position;
        //right는 x축의 양수
        ray.direction = -this.transform.right;
    }

    private void FixedUpdate()
    {
        //라인 그려주는 거와 선 회전 값
        Quaternion rotationQuaternion = Quaternion.Euler(0, rotationAngle, 0);
        rightrotatedDirection = rotationQuaternion * ray.direction;
        Quaternion rotationQuaternion1 = Quaternion.Euler(0, -rotationAngle, 0);
        leftrotatedDirection = rotationQuaternion1 * ray.direction;
    }

    // Update is called once per frame
    void Update()
    {
        ray.origin = this.transform.position;
        ray.direction = -this.transform.right;
        moving.AutomaticMove();
        Ray_1();
    }

   

    //한쪽 바라 보는 곳이 yz - 왼쪽 z+ 오른쪽
    private void OnDrawGizmos()
    { 
        Gizmos.color = Color.red;
        Gizmos.DrawLine(ray.origin, rightrotatedDirection * distance + ray.origin);
        Gizmos.DrawLine(ray.origin, leftrotatedDirection * distance + ray.origin);
    }

    void Ray_1()
    {
        float rightDistance = 0;
        float leftDistance = 0;

        if (Physics.Raycast(ray.origin, rightrotatedDirection, out rayHit, distance))
        {
            if (rayHit.collider.gameObject.layer == LayerMask.NameToLayer("Default"))
            {
                rightDistance = Vector3.Distance(ray.origin, rayHit.point);
            }
            else
                rightDistance = distance;
        }
        else
        {
                rightDistance = distance;
        }

        if (Physics.Raycast(ray.origin, leftrotatedDirection, out rayHit, distance))
        {
            if (rayHit.collider.gameObject.layer == LayerMask.NameToLayer("Default"))
            {
                leftDistance = Vector3.Distance(ray.origin, rayHit.point);
            }
            else
                leftDistance = distance;
        }
        else
        {
                leftDistance = distance;
        }

        turnangle.turn = 0;

        if (leftDistance == rightDistance)
        {
            turnangle.turn = 0;
        }
        else if (leftDistance < rightDistance)
        {
            turnangle.turn += 10000f * Time.deltaTime;
            if(turnangle.turn > 45f)
            { turnangle.turn = 0; }
        }
        else
        {
            turnangle.turn -= 10000f * Time.deltaTime;
            if (turnangle.turn < -45f)
            { turnangle.turn = 0; }
        }

    }

}

//TransformDirection함수 
