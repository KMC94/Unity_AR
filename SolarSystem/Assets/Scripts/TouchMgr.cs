using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMgr : MonoBehaviour
{

    private Camera ARCam;
    private Ray ray;
    private RaycastHit hit;

    void Start()
    {
        //ARCamera를 추출
        ARCam = GameObject.Find("ARCamera").GetComponent<Camera>();
    }

    void Update()
    {
#if UNITY_EDITOR
        //유니티 에디터에서만 동작
        if (Input.GetMouseButtonDown(0))
        {
            //마우스로 클릭한 스크린 좌표를 기준으로 3차원 광선을 생성
            ray = ARCam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f, 1 << 8))
            {
                hit.transform.Find("Canvas").gameObject.SetActive(true);
            }
        }
#endif

#if UNITY_ANDROID || UNITY_IOS
        //모바일에만 동작
        //터치의 개수가 0이상이고 첫 번째 터치일 경우
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            //손가락으로 터치한 스크린 좌표를 기준으로 3차원 광선을 생성
            ray = ARCam.ScreenPointToRay(Input.GetTouch(0).position);

            if(Physics.Raycast(ray, out hit, 100.0f, 1<<8))
            {
                hit.transform.Find("Canvas").gameObject.SetActive(true);
            }
        }
#endif
    }
}
