using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombinationButtonScript : MonoBehaviour
{
    public static CombinationButtonScript Instance;

    private void Awake()
    {
        if (CombinationButtonScript.Instance == null)
        {
            CombinationButtonScript.Instance = this;
        }
    }

    public Button comBtn;
    public GameObject noteLeftTextObj;
    public bool ansCheckbool;

    public GameObject loadTextObj;
    public GameObject noteTextObj;

    void Start()
    {
        comBtn.onClick.AddListener(comBtn_onClick);
        comBtn.gameObject.SetActive(false);
    }


    void Update()
    {

    }

    void comBtn_onClick()
    {
        Debug.Log("조합 버튼 클릭");
        if (ansCheck())
        {
            // 정답     
            Transform[] allChildren = noteLeftTextObj.GetComponentsInChildren<Transform>();
            foreach (Transform child in allChildren)
            {
                if (child.name == "LeftTextObj")
                {
                    // 부모 요소 넘기기
                }
                else
                {
                    Destroy(child.gameObject);
                }
            }
            AnswerResultScript.instance.corObj.SetActive(true);
            StartCoroutine(FadeInOut.instance.textFadeOut(AnswerResultScript.instance.corObj.GetComponent<Text>()));

            loadTextObj = Resources.Load<GameObject>("PreFab/NoteText");
            noteTextObj = GameObject.Instantiate<GameObject>(loadTextObj);

            noteTextObj.transform.SetParent(noteLeftTextObj.transform, false);

            noteTextObj.name = "정답";

            noteTextObj.GetComponent<Text>().text = "";
            string answer = "후배 형사에 의하면 이 사건은 성폭행으로 인해 딸이 아버지를 살해했고 " +
                                                    "자신이 직접 자신의 범행을 신고했다. " +
                                                    "현장에서 발견된 증거도 용의자를 가르키는 중이지만 " +
                                                    "용의자는 자신의 범행을 인정하면서도 묵비권을 행사중이다. ";

            StartCoroutine(TextPrintScript.instance.TextPrint(0.05f, answer, noteTextObj.GetComponent<Text>()));
            StartCoroutine(FadeInOut.instance.textFadeOut(comBtn.transform.GetChild(0).GetComponent<Text>()));
        }

        else
        {
            AnswerResultScript.instance.worObj.SetActive(true);
            StartCoroutine(FadeInOut.instance.textFadeOut(AnswerResultScript.instance.worObj.GetComponent<Text>()));
            // 오답
        }
    }

    public bool ansCheck()
    {
        Transform[] allChildren = noteLeftTextObj.GetComponentsInChildren<Transform>();
        // 0 : 딸이 아빠를 살해/ 1 : 범인은 딸이 유력/ 2 : 딸은 자신의 범행을 인정/ 3: 살해 동기
        int[] ansInt = { 0, 0, 0, 0 };
        foreach (Transform child in allChildren)
        {
            if (child.name == "LeftTextObj")
            {
                // 부모 요소 넘기기
            }
            else
            {
                if (NoteTextObjScript.instance.noteWrites[child.name] == "딸이 아버지를 살해함")
                {
                    ansInt[0]++;
                }
                else if (NoteTextObjScript.instance.noteWrites[child.name] == "딸 본인이 직접 신고함")
                {
                    ansInt[2]++;
                }
                else if (NoteTextObjScript.instance.noteWrites[child.name] == "현장에 있던 사람은 피해자와 용의자 둘뿐임")
                {
                    ansInt[1]++;
                }
                else if (NoteTextObjScript.instance.noteWrites[child.name] == "침입의 흔적도 없음")
                {
                    ansInt[1]++;
                }
                else if (NoteTextObjScript.instance.noteWrites[child.name] == "흉기에서 용의자의 지문까지 검출됨")
                {
                    ansInt[1]++;
                }
                else if (NoteTextObjScript.instance.noteWrites[child.name] == "용의자는 자신의 범행을 인정함")
                {
                    ansInt[2]++;
                }
                else if (NoteTextObjScript.instance.noteWrites[child.name] == "용의자는 자신의 범행을 인정하지만 묵비권을 행사중")
                {
                    ansInt[2]++;
                }
                else if (NoteTextObjScript.instance.noteWrites[child.name] == "살해 동기는 성폭행으로 보임")
                {
                    ansInt[3]++;
                }
            }
        }
        foreach (int i in ansInt)
        {
            if (i == 0)
            {
                // 오답
                return false;
            }
        }
        // 정답
        return true;
    }
}
