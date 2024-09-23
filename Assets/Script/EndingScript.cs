using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingScript : MonoBehaviour
{
    // 싱글톤으로 다른 스크립트 불러오기
    public static EndingScript instance;

    private void Awake()
    {
        if (EndingScript.instance == null)
        {
            EndingScript.instance = this;
        }
    }

    // 엔딩이미지 오브젝트
    public GameObject endFrontGround;
    // 정답을 아직 못맞췄을 때 엔딩 텍스트
    public Text endingText;
    // 엔딩 상태
    public bool endingImgBool;

    void Start()
    {
        // 엔딩이미지 비활성화
        endFrontGround.SetActive(false);
    }

    void Update()
    {
        
    }
}
