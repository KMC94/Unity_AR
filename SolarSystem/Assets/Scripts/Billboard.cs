using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Transform camTr;
    private Transform tr;

    void Start()
    {
        //ARCamera의 Transform 컴포넌트를 추출
        camTr = GameObject.Find("ARCamera").GetComponent<Transform>();
        tr = GetComponent<Transform>();
    }

    void LateUpdate()
    {
        //카메라를 향해 Z축을 회전
        tr.LookAt(camTr.position);
    }
}
