using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TalkHistoryButtonScript : MonoBehaviour
{
    // 싱글톤으로 다른 스크립트 불러오기
    public static TalkHistoryButtonScript Instance;

    private void Awake()
    {
        if (TalkHistoryButtonScript.Instance == null)
        {
            TalkHistoryButtonScript.Instance = this;
        }
    }

    // 대화 기록 버튼 
    public Button talkHisBtn;

    void Start()
    {
        // 대화 기록 버튼 리스너 추가
        talkHisBtn.onClick.AddListener(TalkHisBtn_onClick);

        // 대화 기록 버튼 비활성화 
        talkHisBtn.gameObject.SetActive(false);
    }

    // 대화 기록 버튼 클릭 함수 
    void TalkHisBtn_onClick()
    {
        // 대화 기록 챕터 UI가 켜져있거나 대화 기록 UI가 활성화일 때
        if (TalkHistoryChapterScript.instance.talkHisChaBool || TalkHistoryScript.instance.talkHisBool)
        {
            // 대화 기록 챕터 UI 비활성화 
            TalkHistoryChapterScript.instance.talkHisCha.SetActive(false);

            // 대화 기록 챕터 상태 비활성화로 변경
            TalkHistoryChapterScript.instance.talkHisChaBool = false;

            // 대화 기록 UI 비활성화 
            TalkHistoryScript.instance.talkHis.SetActive(false);

            // 대화 기록 UI 상태 비활성화로 변경 
            TalkHistoryScript.instance.talkHisBool = false;

            // 대화 기록 UI에서 챕터 선택 UI로 가는 버튼 활성화 
            TalkHistoryScript.instance.backBtn.gameObject.SetActive(false);
        }
        else
        {
            // 대화 기록 챕터 UI 활성화 
            TalkHistoryChapterScript.instance.talkHisCha.SetActive(true);

            // 대화 기록 챕터 UI 상태 활성화로 변경 
            TalkHistoryChapterScript.instance.talkHisChaBool = true;
        }
    }
}
