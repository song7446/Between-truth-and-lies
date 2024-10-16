using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUseButtonScript : MonoBehaviour
{
    // 싱글톤으로 다른 스크립트 불러오기
    public static TextUseButtonScript instance;

    private void Awake()
    {
        if (TextUseButtonScript.instance == null)
        {
            TextUseButtonScript.instance = this;

        }
    }

    // 주요 텍스트 사용버튼 오브젝트 
    public GameObject textUseBtnObj;

    // 주요 텍스트 사용 버튼
    public Button textUseBtn;

    // 주요 텍스트 사용 취소 버튼 
    public Button textUnUseBtn;

    // 화자 이름
    public Text talkName;

    // 대화 내용
    public Text talkText;

    // 대화 기록 오브젝트 
    public GameObject talkObj;

    // 주요 텍스트 사용 제한을 위한 카운트 
    int count = 0;

    // 주요 텍스트 아닌 텍스트 사용 상태  
    public bool falseTextUseBool;

    // 너무 많은 텍스트 사용 상태 
    public bool tooManyTextUseBool;

    void Start()
    {
        // 주요 텍스트 사용 버튼 리스너 추가 
        textUseBtn.onClick.AddListener(TextUseBtn_onClick);
        
        // 주요 텍스트 사용 취소 버튼 리스너 추가 
        textUnUseBtn.onClick.AddListener(TextUnUseBtn_onClick);

        // 주요 텍스트 사용 버튼 비활성화 
        textUseBtn.gameObject.SetActive(false);

        // 주요 텍스트 사용 취소 버튼 비활성화 
        textUnUseBtn.gameObject.SetActive(false);
    }

    private void Update()
    {
        // 텍스트 출력 코루틴이 진행되지 않을 때 
        if (StoryManager.instance.coroutineBool==false)
        {
            // 주요 텍스트 아닌 텍스트 상태 비활성화 
            FalseTextUseScript.instance.falTxtObj.SetActive(false);

            // 주요 텍스트 아닌 텍스트 가시 상태로 변경
            FalseTextUseScript.instance.falTxtObj.GetComponent<Text>().color = new Color(255,0,0,255);

            // 너무 많은 텍스트 사용 오브젝트 비활성화 
            TooManyTextUseScript.instance.tooManyTextUseObj.SetActive(false);

            // 너무 많은 텍스트 사용 오브젝트 가시 상태로 변경 
            TooManyTextUseScript.instance.tooManyTextUseObj.GetComponent<Text>().color = new Color(255, 0, 0, 255);

            // 오답 오브젝트 비활성화 
            AnswerResultScript.instance.worObj.SetActive(false);

            // 오답 오브젝트 가시상태로 변경 
            AnswerResultScript.instance.worObj.GetComponent<Text>().color = new Color(255, 0, 0, 255);
        }
    }

    // 주요 텍스트 사용 버튼 함수 
    void TextUseBtn_onClick()
    {
        // 화자 이름 불러오기 
        talkName = talkObj.transform.GetChild(0).gameObject.GetComponent<Text>();
        
        // 대화 내용 불러오기 
        talkText = talkObj.transform.GetChild(1).gameObject.GetComponent<Text>();

        // 주요 텍스트 사용 개수가 4개 미만일때 
        if (count < 4)
        {
            // 선택한 텍스트가 주요 텍스트가 맞다면  
            if (NoteTextObjScript.instance.UpdateNoteText(talkObj))
            {
                // 화자 이름 색 빨간색으로 변경
                talkName.color = Color.red;

                // 대화 내용 색 빨간색으로 변경 
                talkText.color = Color.red;

                // 주요 텍스트 개수 증가 
                count++;
            }
            // 선택한 텍스트가 주요 텍스트가 아니라면
            else
            {
                // 마우스 위치 저장 
                Vector2 mousePosition = Input.mousePosition;
                
                // 주요 텍스트 아닌 텍스트 오브젝트 위치 현재 마우스 위치로 변경 
                FalseTextUseScript.instance.falTxtObj.transform.position = mousePosition;

                // 주요 텍스트 아닌 텍스트 사용 오브젝트 활성화 
                FalseTextUseScript.instance.falTxtObj.SetActive(true);

                // 이후 주요 텍스트 아닌 텍스트 사용 오브젝트 페이드 아웃 
                StartCoroutine(FadeInOut.instance.FadeOut(FalseTextUseScript.instance.falTxtObj.GetComponent<Text>(), 0.25f));
            }
        }
        // 주요 텍스트가 4개 이상일 때 
        else
        {
            // 마우스 위치 저장 
            Vector2 mousePosition = Input.mousePosition;

            // 너무 많은 텍스트 사용 오브젝트 위치 현재 마우스 위치로 변경  
            TooManyTextUseScript.instance.tooManyTextUseObj.transform.position = mousePosition;

            // 너무 많은 텍스트 사용 오브젝트 활성화 
            TooManyTextUseScript.instance.tooManyTextUseObj.SetActive(true);

            // 너무 많은 텍스트 사용 오브젝트 페이드 아웃 
            StartCoroutine(FadeInOut.instance.FadeOut(TooManyTextUseScript.instance.tooManyTextUseObj.GetComponent<Text>(), 0.25f));
        }

        // 주요 텍스트 사용 버튼 비활성화 
        textUseBtn.gameObject.SetActive(false);

        // 주요 텍스트 사용 취소 버튼 비활성화 
        textUnUseBtn.gameObject.SetActive(false);        
    }

    // 선택된 대화 기록 오브젝트 불러오기 
    public void GetTalkObj(GameObject Obj)
    {
        talkObj = Obj;
    }

    // 주요 텍스트 사용 취소 버튼 클릭 함수 
    void TextUnUseBtn_onClick()
    {
        // 화자 이름 불러오기 
        talkName = talkObj.transform.GetChild(0).gameObject.GetComponent<Text>();
        
        // 대화 내용 불러오기 
        talkText = talkObj.transform.GetChild(1).gameObject.GetComponent<Text>();

        // 화자 이름 색 하얀색으로 변경
        talkName.color = Color.white;

        // 대화 내용 색 하얀색으로 변경 
        talkText.color = Color.white;

        // 주요 텍스트 사용 버튼 비활성화 
        textUseBtn.gameObject.SetActive(false);

        // 주요 텍스트 사용 취소 버튼 비활성화 
        textUnUseBtn.gameObject.SetActive(false);

        // 노트 텍스트에서 선택된 대화 기록 삭제 
        NoteTextObjScript.instance.DeleteNoteText(talkObj);

        // 주요 텍스트 개수 감소 
        count--;
    }
}
