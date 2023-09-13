using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Angle : MonoBehaviour
{
    
    public float rotationSpeed = 90.0f;    // 회전 속도
    public float turn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localEulerAngles = new Vector3(90.0f, turn, 0.0f);
    }

    void Rotate_1()
    {
        float rotationInput = Input.GetAxis("Horizontal"); // 사용자 입력을 받아 회전값 계산
        float rotationAmount = rotationInput * Time.deltaTime * rotationSpeed;

        if(rotationInput != 0 )
        {
            turn += rotationAmount;

            if (turn > 45)
                turn = 45;
            else if (turn < -45)
                turn = -45;
        }
        else
        {
            if (turn == 0)
                turn = 0;
            else if (0 < turn && turn <= 45)
                turn -= 1;
            else if(0>turn && turn>=-45)
                turn += 1;

        }

        transform.localEulerAngles = new Vector3(90.0f, turn, 0.0f);
    }

}
