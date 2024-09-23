using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalseTextUseScript : MonoBehaviour
{
    // 싱글톤으로 다른 스크립트 불러오기
    public static FalseTextUseScript instance;

    private void Awake()
    {
        if (FalseTextUseScript.instance == null)
        {
            FalseTextUseScript.instance = this;

        }
    }

    // 오답 텍스트 사용시 알림 오브젝트
    public GameObject falTxtObj;

    void Start()
    {
        // 오답 텍스트 알림 오브젝트 비활성화
        falTxtObj.SetActive(false);
    }
}
