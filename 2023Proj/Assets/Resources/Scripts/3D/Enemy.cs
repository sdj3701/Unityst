using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animation spartanKing;
    float speed = 5.0f;
    public GameObject objSword = null;
    GameObject target;
    bool isLife = false;

    // Start is called before the first frame update
    void Start()
    {
        spartanKing = gameObject.GetComponentInChildren<Animation>();
        target = GameObject.FindWithTag("Cube");
        objSword.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Move_1();
    }

    void Move_1()
    {
        if(!isLife)
        {
            Vector3 direction = target.transform.position - transform.position;
            transform.Translate(direction.normalized * speed * Time.deltaTime);
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
        yield return new WaitForSeconds(3.0f);
        Destroy(this.gameObject);
    }

}
