using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static MecanimControl;

public class Player3D : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public float rotationSpeed = 720.0f;

    CameraController cameraPosition;
    public Animator animator;

    Vector3 moveInput;
    Vector3 cameraPos;

    CharacterController pcController;
    NavMeshAgent agent;

    public GameObject LBowdHand;
    public GameObject RSwowrdHand;
    public GameObject BSwowrd;
    bool damage = false;
    bool check = false;

    // Start is called before the first frame update
    void Awake()
    {
        InitData();
        
    }

    private void FixedUpdate()
    {
        animator.SetFloat("Speed", agent.velocity.magnitude);
    }

    // Update is called once per frame
    void Update()
    {
        CharacterController_Slerp();
        //NavMesh_Control();
    }

    private void NavMesh_Control()
    {
        if(Input.GetMouseButton(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                //agent.destination = hit.point;
                agent.SetDestination(hit.point);
            }
        }
    }
    private void CharacterController_Slerp()
    {
        moveInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        //ī�޶� �ٶ󺸴� ����
        Vector3 forwarDirection = Camera.main.transform.forward;
        forwarDirection.y = 0;

        if (moveInput.sqrMagnitude > 0.01f)
        {
            //ī�޶� ȸ���� �ϸ� ĳ���͵� ȸ���ϰ� �ϴ� ����
            Vector3 moveDirection = Quaternion.LookRotation(forwarDirection) * moveInput;
            Vector3 forword = Vector3.Slerp(transform.forward, forwarDirection, rotationSpeed * Time.deltaTime / Vector3.Angle(transform.forward, forwarDirection));
            transform.LookAt(transform.position + forword);

            pcController.Move(moveDirection * moveSpeed * Time.deltaTime + Physics.gravity * Time.deltaTime);

        }
        else
        {

        }
        animator.SetFloat("Speed", pcController.velocity.magnitude);


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
    private void InitData()
    {
        pcController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        cameraPosition = FindObjectOfType<CameraController>();
    }
}
