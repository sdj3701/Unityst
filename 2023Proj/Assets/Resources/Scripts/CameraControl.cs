using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveCamera();
        RotateCamera();
        ZoomCamera();
    }

    void MoveCamera()
    {
        if(Input.GetMouseButton(0))
        {
            transform.Translate(Input.GetAxis("Mouse X") / 10f, Input.GetAxis("Mouse Y") / 10f, 0f);
        }
    }

    void RotateCamera()
    {
        if(Input.GetMouseButton(1))
        {
            //회전은 y축 기준으로 해야해서 y가 먼저
            transform.Rotate(Input.GetAxis("Mouse Y") * -10f, Input.GetAxis("Mouse X") * 10f, 0f);
        }
    }

    void ZoomCamera()
    {
        mainCamera.fieldOfView += (20 * Input.GetAxis("Mouse ScrollWheel"));

        if(mainCamera.fieldOfView < 10)
            mainCamera.fieldOfView = 10;
        if (mainCamera.fieldOfView > 150)
            mainCamera.fieldOfView = 150;

    }

}

#region
/*
 * 
 *  카메라는 앞으로 확대를 하는 것이 아니라 View를 좁혀서 화면을 확장 시키는 것이다.
 *  
 *  카메라 하나 더 생성하고 Viewport Rect의 xy를 축소하면 미니 맵을 만들수 있다
 *  조심해야할 것은 Audio Listener은 메인 카메라에서만 켜야 한다.
 *  Depth 우선 순위
 *  
 *  Clear Flags는 원하는 것만 그려달라
 *  Culling Mask에 Layer를 설정하면 특정 Layer만 보여줄수 있다.
 *  미니맵에 적을 확인하고 우리팀을 확인 할 때 사용하면 좋다.
 *  
 *  TIP
 *  카메라 FPS 같은 게임 스코프만 확대 할려면 카메라를 두개를 사용해야 한다.
 *  잠입 게임 같은거는 플레이어 한테 사운드 적용
 *  
 */

#endregion