using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;

public class Enemy2D : MonoBehaviour
{
    float moveSpeed = 1000f;
    private Rigidbody2D rigidbody;
    Renderer rend;
    Color origin;

    int maxHP = 10;
    public int currentHP = 10;

    public Animator animator;
    
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rend = GetComponent<Renderer>();
        origin = rend.material.color;
        Invoke("Death", 5.0f);

    }

    void Update()
    {
        Move_1();
    }

    void Move_1()
    {
        Vector3 position =  rigidbody.transform.position;
        position = new Vector3(position.x - (moveSpeed * Time.deltaTime), position.y, position.z);

        rigidbody.MovePosition(position);
        if (currentHP <= 0)
        {
            //PlayDeathAnimation();
            Death();
        }
    }
    IEnumerator DelayedAction()
    {
        if (rend.material.color == Color.red)
        {
            yield return new WaitForSeconds(1.0f);
            rend.material.color = origin;
        }
    }
    void Death()
    {
        DestroyImmediate(this.gameObject);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        rend.material.color = Color.red;
        currentHP -= Player2D.Damage;
        StartCoroutine(DelayedAction());
    }
            
    private void PlayDeathAnimation()
    {
        if(animator !=null)
        {
            animator.SetBool("Death", true);
        }
    }

}
