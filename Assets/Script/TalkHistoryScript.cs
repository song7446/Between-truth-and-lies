using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class TalkHistoryScript : MonoBehaviour
{
    // 싱글톤으로 다른 스크립트 불러오기
    public static TalkHistoryScript instance;

    private void Awake()
    {
        if (TalkHistoryScript.instance == null)
        {
            TalkHistoryScript.instance = this;

        }
    }

    // 대화 기록 UI 상태 
    public bool talkHisBool = false;

    // 대화 기록 오브젝트
    public GameObject talkHis;

    // 대화 내용
    public string talkText;

    // 화자 이름 
    public string talkName;

    // 대화 기록 텍스트 위치 프리펩 불러오기 오브젝트  
    public GameObject leftRight;

    // 대화 기록 오브젝트 
    public GameObject talkLog;

    // 대화 기록의 부모 오브젝트 
    public GameObject parentObject;

    // 대화 기록 UI에서 대화 기록 챕터로 가는 버튼 
    public Button backBtn;

    // 대화 기록 오브젝트 이름용 인덱스 
    int index = 1;

    void Start()
    {
        // 대화 기록 오브젝트 찾기 
        talkHis = GameObject.Find("TalkHistory");

        // 대화 기록 오브젝트 비활성화 
        talkHis.SetActive(false);

        // 대화 기록 부모 오브젝트 설정 
        parentObject = talkHis.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;

        // 대화 기록 UI에서 대화 기록 챕터로 가는 버튼 리스너 추가
        backBtn.onClick.AddListener(BackBtn_onClick);

        // 대화 기록 UI에서 대화 기록 챕터로 가는 버튼 비활성화 
        backBtn.gameObject.SetActive(false);
    }

    // 대화 기록 업데이트 함수 
    public void UpdateTalkHistory(int num)
    {
        // 스토리가 끝나지 않았을 때 
        if (Scene1Script.instance.ScriptCollection(num) != "")
        {
            // 대화 내용 불러오기 
            talkText = Scene1Script.instance.ScriptCollection(num);
            // 화자 이름 불러오기 
            talkName = Scene1Script.instance.NameCollection(num);

            // 화자가 주인공이면
            if (talkName == "주인공")
            {
                // 텍스트가 오른쪽 정렬된 프리펩 불러오기 
                leftRight = Resources.Load<GameObject>("PreFab/TalkLogRight");
            }

            // 화자가 주인공이 아니면
            else
            {
                // 텍스트가 왼쪽 정렬된 프리펩 불러오기 
                leftRight = Resources.Load<GameObject>("PreFab/TalkLogLeft");
            }

            // 불러온 프리펩 대화 기록 오브젝트에 복사 
            talkLog = GameObject.Instantiate<GameObject>(leftRight);

            // 대화 기록 오브젝트 부모 설정
            talkLog.transform.SetParent(parentObject.transform, false);

            // 화자 이름 오브젝트 설정
            GameObject name = talkLog.transform.GetChild(0).gameObject;

            // 화자 이름 저장 
            name.GetComponent<Text>().text = talkName;

            // 대화 내용 오브젝트 설정 
            GameObject text = talkLog.transform.GetChild(1).gameObject;

            // 대화 내용 저장 
            text.GetComponent<Text>().text = talkText;

            // 대화 기록 오브젝트 이름 설정 
            talkLog.name = "TalkLog " + index;

            // 대화 기록 오브젝트 이름용 인덱스 증가 
            index++;
        }       
    }

    // 대화 기록 UI에서 대화 기록 챕터로 가는 버튼 클릭 함수 
    void BackBtn_onClick()
    {
        // 대화 기록 UI 상태 비활성화로 변경
        TalkHistoryScript.instance.talkHisBool = false;

        // 대화기록 UI 비활성화 
        TalkHistoryScript.instance.talkHis.SetActive(false);

        // 대화 기록 챕터 UI 활성화 
        TalkHistoryChapterScript.instance.talkHisCha.SetActive(true);

        // 대화 기록 UI에서 대화 기록 챕터로 가는 버튼 비활성화 
        backBtn.gameObject.SetActive(false);
    }
}
