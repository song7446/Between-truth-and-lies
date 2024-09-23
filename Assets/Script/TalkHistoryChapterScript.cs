using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkHistoryChapterScript : MonoBehaviour
{
    // 싱글톤으로 다른 스크립트 불러오기
    public static TalkHistoryChapterScript instance;
    private void Awake()
    {
        if (TalkHistoryChapterScript.instance == null)
        {
            TalkHistoryChapterScript.instance = this;

        }
    }

    // 대화 기록 챕터 버튼 
    public Button talkHisChaBtn1;
    public Button talkHisChaBtn2;
    public Button talkHisChaBtn3;
    public Button talkHisChaBtn4;

    // 대화 기록 챕터 UI 오브젝트 
    public GameObject talkHisCha;

    // 대화 기록 챕터 UI 상태 
    public bool talkHisChaBool = false;

    void Start()
    {
        // 대화 기록 챕터 버튼 리스너 추가
        talkHisChaBtn1.onClick.AddListener(TalkHisChaBtn1_onClick);
        talkHisChaBtn2.onClick.AddListener(TalkHisChaBtn2_onClick);

        // 대화 기록 챕터 UI 오브젝트 찾기 
        talkHisCha = GameObject.Find("TalkHistoryChapter");

        // 대화 기록 챕터 UI 비활성화 
        talkHisCha.SetActive(false);
    }

    // 1번째 챕터 버튼 클릭 함수 
    void TalkHisChaBtn1_onClick()
    {
        // 대화 기록 UI 상태 활성화로 변경 
        TalkHistoryScript.instance.talkHisBool = true;

        // 대화 기록 UI 활성화 
        TalkHistoryScript.instance.talkHis.SetActive(true);

        // 대화 기록 UI에서 챕터 선택 UI로 가는 버튼 활성화 
        TalkHistoryScript.instance.backBtn.gameObject.SetActive(true);

        // 대화 기록 챕터 UI 비활성화 
        talkHisCha.SetActive(false);
    }

    // 2번째 챕터 버튼 클릭 함수 
    void TalkHisChaBtn2_onClick()
    {
        Debug.Log("2번 버튼 클릭");
    }
}
