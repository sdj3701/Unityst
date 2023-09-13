using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlappyBird : MonoBehaviour
{
    public Camera mainCamera;
    public float jumpPower = 5.0f;
    Rigidbody rigidbody;

    Vector3 maxPos = -Vector3.forward * 45;
    void Start()
    {
        rigidbody = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPos = -Vector3.forward * Time.deltaTime * 5 * 10;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0f,jumpPower,0f);
            transform.rotation = Quaternion.Euler(0, 0, 45);
        }

        if(maxPos.z >= currentPos.z)
        {
            transform.rotation = Quaternion.Euler(0, 0, -45);
        }
        transform.Rotate(currentPos);

        Vector3 viewportPos = mainCamera.WorldToViewportPoint(transform.position);

        if (viewportPos.x < 0f || viewportPos.x > 1f || viewportPos.y < 0f || viewportPos.y > 1f)
        {
            if (GameManager.Instance.changeScene == 1)
            {
                GameManager.Instance.ChangeScene("99_End");
                GameManager.Instance.changeScene++;
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        GameManager.Instance.count++;
        GameObject hitObject = other.gameObject;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject hitObject = collision.gameObject;
        if (GameManager.Instance.changeScene == 1)
        {
            GameManager.Instance.ChangeScene("99_End");
            GameManager.Instance.changeScene++;
        }
    }
    

}
