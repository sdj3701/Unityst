using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWall : MonoBehaviour
{
    public float moveSpeed = 10.0f;

    void Start()
    {
        Invoke("Death", 3.0f);
    }

    void Update()
    {

        transform.Translate(Vector3.left *Time.deltaTime * moveSpeed );
    }

    void Death()
    {
        Destroy(this.gameObject);
    }
    
}

#region
/*
 *  사용법  
 *  Invoke(함수명, 시간);
 * 
 */
#endregion