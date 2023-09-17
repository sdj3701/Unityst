using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float runSpeed = 10.0f;
    float rotationSpeed = 720.0f;

    Animation spartanKing;
    Rigidbody playerRig;
    GameObject player;
    public GameObject objSword;
    bool isAttack;
    // Start is called before the first frame update
    void Start()
    {
        spartanKing = gameObject.GetComponentInChildren<Animation>();
        player = GetComponent<GameObject>();
        objSword.SetActive(false);
        isAttack = objSword.activeSelf;
    }

    // Update is called once per frame
    void Update()
    {
        Move_1();
    }

    IEnumerator AttackToIdle()
    {
        if (spartanKing["attack"].enabled == true) yield break;

        Debug.Log("1");

        objSword.SetActive(true);
        spartanKing.wrapMode = WrapMode.Once;
        spartanKing.CrossFade("attack", 0.3f);
        float delayTime = spartanKing.GetClip("attack").length - 0.3f;
        yield return new WaitForSeconds(delayTime);
        objSword.SetActive(false);
    }

    void Move_1()
    {

        if (Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine("AttackToIdle");
        }

        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        transform.position += direction * Time.deltaTime * runSpeed;

        if (direction.sqrMagnitude > 0.01f)
        {
            spartanKing.wrapMode = WrapMode.Loop;
            spartanKing.CrossFade("run", 0.3f);
            Vector3 forward = Vector3.Slerp(transform.forward, direction, rotationSpeed * Time.deltaTime / Vector3.Angle(transform.forward, direction));
            transform.LookAt(transform.position + forward);
        }
        /*else
        {
            spartanKing.wrapMode = WrapMode.Loop;
            spartanKing.CrossFade("idle", 0.3f);
        }*/
    }
}
/*
 * 
 *  일단 움직이면서 공격 하는게 중요
 *  Enemy를 하나 만들어 큐브로 달려가게 만들기
 * 
*/