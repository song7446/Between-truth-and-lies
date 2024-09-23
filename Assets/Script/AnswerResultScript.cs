using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerResultScript : MonoBehaviour
{
    // 싱글톤으로 다른 스크립트 불러오기
    public static AnswerResultScript instance;

    private void Awake()
    {
        if (AnswerResultScript.instance == null)
        {
            AnswerResultScript.instance = this;

        }
    }

    // 정답 오브젝트 
    public GameObject corObj;

    // 오답 오브젝트 
    public GameObject worObj;

    void Start()
    {
        // 정답 오답 오브젝트는 노트가 열리고 조합 버튼을 눌러야 사용하기 때문에 시작할 때는 비활성화
        corObj.SetActive(false);
        worObj.SetActive(false);
    }
}
