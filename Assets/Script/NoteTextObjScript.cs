using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteTextObjScript : MonoBehaviour
{
    // 싱글톤으로 다른 스크립트 불러오기
    public static NoteTextObjScript instance;

    private void Awake()
    {
        if (NoteTextObjScript.instance == null)
        {
            NoteTextObjScript.instance = this;
        }
    }

    // 대화 기록을 노트용 텍스트로 변환하기 위한 딕셔너리
    public Dictionary<string, string> noteWrites = new Dictionary<string, string>()
    {
        { "이 집에 살던 딸이 아버지를 살해했습니다.","딸이 아버지를 살해함" },
        { "그게 딸 본인이 했습니다.","딸 본인이 직접 신고함" },
        { "사망 추정시각 전부터 지금까지 현장에 있던 사람이 피해자와 용의자 둘뿐이고","현장에 있던 사람은 피해자와 용의자 둘뿐임" },
        { "침입의 흔적도 없는데다가","침입의 흔적도 없음" },
        { "흉기에서 딸의 지문까지 나온 상태입니다.","흉기에서 용의자의 지문까지 검출됨" },
        { "자신이 살해한 것도 맞고 자수하는 것도 맞다고 하는데","용의자는 자신의 범행을 인정함" },
        { "구체적으로 얘기 해주지를 않습니다.","용의자는 자신의 범행을 인정하지만 묵비권을 행사중" },
        { "그냥 자신이 한 것이라는 것 외에는 아무 얘기도 안합니다.","용의자는 자신의 범행을 인정하지만 묵비권을 행사중" },
        { "신고 시간과 사망 추청 시간이 좀 차이가 납니다.","신고 시간과 사망추정시간에 차이가 있음" },
        { "그렇긴 한데 정황상 성폭행으로 보입니다.","살해 동기는 성폭행으로 보임" },
    };

    // 노트 텍스트 부모 오브젝트
    public GameObject noteTxtObj;

    // 왼쪽 텍스트 오브젝트 
    public GameObject leftTextObj;

    // 텍스트 오브젝트
    public GameObject textObj;

    // 노트 텍스트 프리펩 불러오기용 오브젝트   
    public GameObject loadTextObj;

    // 노트 텍스트 오브젝트 
    public GameObject noteTextObj;

    // 화자 이름
    public Text talkName;

    // 내용
    public Text talkText;

    // 노트 텍스트 업데이트 함수 
    public bool updateNoteText(GameObject obj)
    {
        // 받아온 오브젝트의 자식 요소로 이름과 내용 받아오기 / 0 = 이름 1 = 내용
        talkName = obj.transform.GetChild(0).gameObject.GetComponent<Text>();
        talkText = obj.transform.GetChild(1).gameObject.GetComponent<Text>();

        // 받아온 내용이 딕셔너리에 있다면  
        if (noteWrites.ContainsKey(talkText.text)) 
        {
            // 노트 텍스트 프리펩 불러오기 
            loadTextObj = Resources.Load<GameObject>("PreFab/NoteText");

            // 불러온 프리펩 복사 
            noteTextObj = GameObject.Instantiate<GameObject>(loadTextObj);

            // 부모요소 설정
            noteTextObj.transform.SetParent(leftTextObj.transform, false);

            // 오브젝트 이름 설정 
            noteTextObj.name = talkText.text;

            // 대화 내용을 노트 텍스트에 맞게 수정 
            noteTextObj.GetComponent<Text>().text = talkName.text + "에 의하면 " + noteWrites[talkText.text];

            // 대화 내용이 딕셔너리에 있다면 true 반환 
            return true;
        }
        else
        {// 대화 내용이 딕셔너리에 없다면 false 반환 
            return false;
        }       
    }

    // 노트 텍스트 삭제 함수 
    public void deleteNoteText(GameObject obj)
    {
        // 노트 텍스트 요소중 삭제할 목록 이름으로 찾기 
        textObj = GameObject.Find(obj.transform.GetChild(1).gameObject.GetComponent<Text>().text);
        // 오브젝트 삭제 
        Destroy(textObj);
    }

    void Start()
    {
        // 노트 텍스트 부모 오브젝트 비활성화 
        noteTxtObj.SetActive(false);
    }


    void Update()
    {
        
    }
}
