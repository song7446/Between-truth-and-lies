using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteButtonScript : MonoBehaviour
{
    // 싱글톤으로 다른 스크립트 불러오기
    public static NoteButtonScript instance;

    private void Awake()
    {
        if (NoteButtonScript.instance == null)
        {
            NoteButtonScript.instance = this;
        }
    }

    // 노트 버튼 
    public Button noteBtn;

    // 노트 버튼 클릭시 뒤 UI 클릭 불가 패널
    public GameObject btnOnPanel;

    void Start()
    {
        // 버튼 리스너 추가 
        noteBtn.onClick.AddListener(noteBtn_onClick);

        // 클릭 불가 패널 찾기 
        btnOnPanel = GameObject.Find("ButtonOnPanel");

        // 클릭 불가 패널 비활성화
        btnOnPanel.SetActive(false);

        // 노트 버튼 비활성화 - 오프닝에서는 클릭 할 수 없기 때문에 
        noteBtn.gameObject.SetActive(false);
    }

    // 노트 버튼 클릭 함수 
    public void noteBtn_onClick()
    {
        // 노트 코루틴 활성화중 클릭 막기 
        if (AutoFlipScript.instance.isFlipping)
        {

        }
        // 노트가 활성화시 
        else if (NoteScript.instance.noteBool)
        {
            // 클릭 불가 패널 비활성화
            btnOnPanel.SetActive(false);

            // 노트 속 텍스트 비활성화 
            NoteTextObjScript.instance.noteTxtObj.SetActive(false);

            // 노트 닫기 함수
            AutoFlipScript.instance.CloseNote();

            // 노트 비활성화 상태로 변경
            NoteScript.instance.noteBool = false;

            // 조합 버튼 비활성화
            CombinationButtonScript.Instance.comBtn.gameObject.SetActive(false);
        }
        // 노트가 비활성화시 
        else
        {
            // 클릭 불가 패널 활성화 
            btnOnPanel.SetActive(true);     

            // 노트 활성화 
            NoteScript.instance.NotePanel.gameObject.SetActive(true);

            // 노트 활성화 상태로 변경
            NoteScript.instance.noteBool = true;

            // 노트 열기 함수 
            AutoFlipScript.instance.OpenNote();

            // 조합 버튼 활성화 
            CombinationButtonScript.Instance.comBtn.gameObject.SetActive(true);           
        }
    }

    void Update()
    {

    }
}
