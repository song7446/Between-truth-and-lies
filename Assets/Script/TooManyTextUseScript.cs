using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooManyTextUseScript : MonoBehaviour
{
    // 싱글톤으로 다른 스크립트 불러오기
    public static TooManyTextUseScript instance;

    private void Awake()
    {
        if (TooManyTextUseScript.instance == null)
        {
            TooManyTextUseScript.instance = this;

        }
    }

    // 너무 많은 텍스트 사용 오브젝트 
    public GameObject tooManyTextUseObj;

    void Start()
    {
        // 너무 많은 텍스트 사용 오브젝트 비활성화 
        tooManyTextUseObj.SetActive(false);
    }

    void Update()
    {
        
    }
}
