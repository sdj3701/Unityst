using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check : MonoBehaviour
{
    public GameObject enemy;
    Animation spartanKing;
    public GameObject objSword;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "Enemy")
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
        Destroy(this.gameObject);
        DestroyImmediate(enemy.gameObject, true);
        enemy.gameObject.SetActive(false);
        objSword.SetActive(false);
    }

}
