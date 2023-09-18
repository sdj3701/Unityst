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
 *  ������ �ɰ� Ư�� �ִϸ��̼��� �۵���Ű�� ���ؼ��� any State�� ����ϸ� ��
 *  Greater ũ�ų� Less �۰ų�
 *  Has Exit Time�� Idle�� �ִϸ��̼��� ���������� �����ϰ� �Ѵ�
 *  Rig Animation Type �޸շ��̵�� ��� Generic�� �������� ���� �پ��� ��
 *  ��Ų ���� materials���� textures Materials�� �������
 *  Ʈ���Ŵ� ������� ��
 *  
 *  �ִϸ��̼� �̺�Ʈ �߰� �̺�Ʈ 
 *  
 *  tip
 *  �ִϸ��̼� �ٿ� �ް� ���� Rig���� �ִϸ��̼� Ÿ���� �޸����� �ٲ� �ָ� ��
 *  
 */
#endregion