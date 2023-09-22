using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animation spartanKing;
    float speed = 7.0f;
    public GameObject objSword = null;
    GameObject target;
    bool isLife = false;
    float rotationSpeed = 540.0f;


    // Start is called before the first frame update
    void Start()
    {
        spartanKing = gameObject.GetComponentInChildren<Animation>();
        objSword.SetActive(false);
        Invoke("Death", 10.0f);
    }

    // Update is called once per frame
    void Update()
    {
        target = GameObject.FindWithTag("Cube");
        Move_1();
    }

    void Move_1()
    {
        if(!isLife)
        {
            Vector3 direction = target.transform.position - transform.position;
            transform.Translate(-direction.normalized * speed * Time.deltaTime);
            spartanKing.wrapMode = WrapMode.Loop;
            spartanKing.CrossFade("run", 0.3f);
            Vector3 forward = Vector3.Slerp(transform.forward, direction, rotationSpeed * Time.deltaTime / Vector3.Angle(transform.forward, direction));
            transform.LookAt(transform.position + forward);
        }
        else
        {
            Vector3 direction = new Vector3(0,0,0);
            transform.Translate(direction.normalized * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Sword")
        {
            isLife = true;
            spartanKing.Play("diehard");
            StartCoroutine(DieToIDestroy());
        }
    }

    IEnumerator DieToIDestroy()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(this.gameObject);
    }

    void Death()
    {
        DestroyImmediate(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Cube")
        {
            StartCoroutine("AttackToIdle");
        }
    }

    IEnumerator AttackToIdle()
    {
        if (spartanKing["attack"].enabled == true) yield break;

        objSword.SetActive(true);
        spartanKing.wrapMode = WrapMode.Once;
        spartanKing.CrossFade("attack", 0.3f);
        float delayTime = spartanKing.GetClip("attack").length - 0.3f;
        yield return new WaitForSeconds(delayTime);
        Destroy(target.gameObject);
        DestroyImmediate(gameObject, true);
        gameObject.SetActive(false);
        objSword.SetActive(false);
    }

}
