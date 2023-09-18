using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MecanimControl : MonoBehaviour
{

    public float runSpeed = 10.0f;
    public float rotationSpeed = 720.0f;
    bool damage = false;
    bool check = false;

    CharacterController pcController;
    Vector3 direction;

    public GameObject LBowdHand;

    public GameObject RSwowrdHand;
    public GameObject BSwowrd;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        pcController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(check);

        CharacterController_Slerp();
    }

    void Input_Animation()
    {
        if(Input.GetMouseButtonDown(0))
        {
            
        }
    }

    private void CharacterController_Slerp()
    {
        direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if(direction.sqrMagnitude > 0.01f)
        {
            Vector3 forword = Vector3.Slerp(transform.forward, direction, rotationSpeed * Time.deltaTime / Vector3.Angle(transform.forward,direction));
            transform.LookAt(transform.position + forword);
        }
        else
        {

        }

        animator.SetFloat("Speed",pcController.velocity.magnitude);
        pcController.Move(direction * runSpeed * Time.deltaTime + Physics.gravity * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (!check)
            {
                LBowdHand.SetActive(false);
                BSwowrd.SetActive(false);
                RSwowrdHand.SetActive(true);
                animator.SetTrigger("Pull");
                check = true;
            }
            else
            {
                LBowdHand.SetActive(true);
                BSwowrd.SetActive(true);
                RSwowrdHand.SetActive(false);
                animator.SetTrigger("Putin");
                check = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            animator.SetTrigger("Draw");
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (!check)
            {
                animator.SetTrigger("BAttack");
            }
            else
            {
                animator.SetTrigger("SAttack");
            }
        }
    }

    IEnumerator Die()
    {
        while(true)
        {
            yield return new WaitForSeconds(0);
            if(damage && animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Damage"))
            {
                if(animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f)
                {
                    damage = false;
                    animator.SetBool("Damage", damage);
                    break;
                }
            }
        }
    }

    IEnumerator AttackBow()
    {
        while (true)
        {
            yield return new WaitForSeconds(0);
            if ( animator.GetCurrentAnimatorStateInfo(1).IsName("Upperbody.Attack"))
            {
                if (animator.GetCurrentAnimatorStateInfo(1).normalizedTime >= 0.9f)
                {
                    animator.SetTrigger("Attack");
                    break;
                }
            }
        }
    }

    private void LateUpdate()
    {
        
    }

    private void FixedUpdate()
    {
        
    }

    void StartIdle()
    {
        Debug.Log("1");
    }


    void FinishIdle()
    {
        Debug.Log("2");
    }

}

#region
/*
 * 
 *  조건을 걸고 특정 애니메이션을 작동시키기 위해서는 any State를 사용하면 됨
 *  Greater 크거나 Less 작거나
 *  Has Exit Time은 Idle의 애니메이션이 끝나야지만 실행하게 한다
 *  Rig Animation Type 휴먼로이드는 사람 Generic은 사족보행 같은 다양한 것
 *  스킨 문제 materials에서 textures Materials를 해줘야함
 *  트리거는 비워나도 됨
 *  
 *  애니메이션 이벤트 추가 이벤트 
 *  
 *  tip
 *  애니메이션 다운 받고 나서 Rig에서 애니메이션 타입을 휴먼으로 바꿔 주면 됨
 *  
 */
#endregion