using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animation spartanKing;
    float speed = 5.0f;
    public GameObject objSword = null;
    GameObject target;
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
        Vector3 direction = target.transform.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Sword")
        {
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
