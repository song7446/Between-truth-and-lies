using Unity.Burst.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class TalkLogObjectScript : MonoBehaviour, IPointerDownHandler
{
    // 싱글톤으로 다른 스크립트 불러오기
    public static TalkLogObjectScript instance;

    private void Awake()
    {
        if (TalkLogObjectScript.instance == null)
        {
            TalkLogObjectScript.instance = this;

        }
    }

    // 대화 기록 오브젝트 
    public GameObject talkLogObj;

    // 화자 이름 
    public Text Name;

    // 대화 내용 
    public Text Text;

    private void Start()
    {

    }

    // 대화 기록 오브젝트 클릭 함수 
    public void OnPointerDown(PointerEventData eventData)
    {
        // 우클릭일 때 
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            // 마우스 위치 저장 
            Vector2 mousePosition = Input.mousePosition;
            
            // 팝업 UI 위치 마우스 위치로 조정  
            TextUseButtonScript.instance.textUseBtnObj.transform.position = mousePosition;
            
            // 선택된 오브젝트의 부모 오브젝트 찾기 = 선택된 대화 기록 오브젝트 찾기  
            talkLogObj = Name.transform.parent.gameObject;

            // 선택된 대화 기록 오브젝트 보내기
            TextUseButtonScript.instance.GetTalkObj(talkLogObj);

            // 이름 색이 하얀색이면 - 주요 텍스트로 선택되어있지 않았다면
            if (Name.color==Color.white)
            {
                // 주요 텍스트 사용 버튼 활성화 
                TextUseButtonScript.instance.textUseBtn.gameObject.SetActive(true);

                // 사용된 텍스트 취소 버튼 비활성화 
                TextUseButtonScript.instance.textUnUseBtn.gameObject.SetActive(false);
            }
            // 이름이 빨간색이면 - 주요 텍스트로 선택 되어있다면 
            else if(Name.color==Color.red) 
            {
                // 사용된 텍스트 취소 버튼 활성화 
                TextUseButtonScript.instance.textUnUseBtn.gameObject.SetActive(true);

                // 주요 텍스트 사용버튼 비활성화 
                TextUseButtonScript.instance.textUseBtn.gameObject.SetActive(false);
            }
        }
        // 우클릭이 아니면
        else
        {
            // 주요 텍스트 사용 버튼 비활성화 
            TextUseButtonScript.instance.textUseBtn.gameObject.SetActive(false);

            // 사용된 텍스트 취소 버튼 비활성화 
            TextUseButtonScript.instance.textUnUseBtn.gameObject.SetActive(false);
        }
    }
}