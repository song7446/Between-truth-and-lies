using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteTextObjScript : MonoBehaviour
{
    public static NoteTextObjScript instance;

    private void Awake()
    {
        if (NoteTextObjScript.instance == null)
        {
            NoteTextObjScript.instance = this;
        }
    }

    Dictionary<string, string> noteWrites = new Dictionary<string, string>()
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


    public GameObject noteTxtObj;

    public GameObject leftTextObj;

    public GameObject textObj;

    public GameObject loadTextObj;
    public GameObject noteTextObj;

    public Text talkName;
    public Text talkText;

    public bool updateNoteText(GameObject obj)
    {
        talkName = obj.transform.GetChild(0).gameObject.GetComponent<Text>();
        talkText = obj.transform.GetChild(1).gameObject.GetComponent<Text>();

        if (noteWrites.ContainsKey(talkText.text)) 
        {
            loadTextObj = Resources.Load<GameObject>("PreFab/NoteText");
            noteTextObj = GameObject.Instantiate<GameObject>(loadTextObj);

            noteTextObj.transform.SetParent(leftTextObj.transform, false);

            noteTextObj.name = talkText.text;
            noteTextObj.GetComponent<Text>().text = talkName.text + "에 의하면 " + noteWrites[talkText.text];

            return true;
        }
        else
        {
            return false;
        }       
    }

    public void deleteNoteText(GameObject obj)
    {
        textObj = GameObject.Find(obj.transform.GetChild(1).gameObject.GetComponent<Text>().text);
        Destroy(textObj);
    }

    void Start()
    {
        noteTxtObj.SetActive(false);
    }


    void Update()
    {
        
    }
}
