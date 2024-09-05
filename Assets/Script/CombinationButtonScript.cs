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
        Debug.Log("���� ��ư Ŭ��");
        if (ansCheck())
        {
            // ����     
            Transform[] allChildren = noteLeftTextObj.GetComponentsInChildren<Transform>();
            foreach (Transform child in allChildren)
            {
                if (child.name == "LeftTextObj")
                {
                    // �θ� ��� �ѱ��
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

            noteTextObj.name = "����";

            noteTextObj.GetComponent<Text>().text = "";
            string answer = "�Ĺ� ���翡 ���ϸ� �� ����� ���������� ���� ���� �ƹ����� �����߰� " +
                                                    "�ڽ��� ���� �ڽ��� ������ �Ű��ߴ�. " +
                                                    "���忡�� �߰ߵ� ���ŵ� �����ڸ� ����Ű�� �������� " +
                                                    "�����ڴ� �ڽ��� ������ �����ϸ鼭�� ������� ������̴�. ";

            StartCoroutine(TextPrintScript.instance.TextPrint(0.05f, answer, noteTextObj.GetComponent<Text>()));
            StartCoroutine(FadeInOut.instance.textFadeOut(comBtn.transform.GetChild(0).GetComponent<Text>()));
        }

        else
        {
            AnswerResultScript.instance.worObj.SetActive(true);
            StartCoroutine(FadeInOut.instance.textFadeOut(AnswerResultScript.instance.worObj.GetComponent<Text>()));
            // ����
        }
    }

    public bool ansCheck()
    {
        Transform[] allChildren = noteLeftTextObj.GetComponentsInChildren<Transform>();
        // 0 : ���� �ƺ��� ����/ 1 : ������ ���� ����/ 2 : ���� �ڽ��� ������ ����/ 3: ���� ����
        int[] ansInt = { 0, 0, 0, 0 };
        foreach (Transform child in allChildren)
        {
            if (child.name == "LeftTextObj")
            {
                // �θ� ��� �ѱ��
            }
            else
            {
                if (NoteTextObjScript.instance.noteWrites[child.name] == "���� �ƹ����� ������")
                {
                    ansInt[0]++;
                }
                else if (NoteTextObjScript.instance.noteWrites[child.name] == "�� ������ ���� �Ű���")
                {
                    ansInt[2]++;
                }
                else if (NoteTextObjScript.instance.noteWrites[child.name] == "���忡 �ִ� ����� �����ڿ� ������ �ѻ���")
                {
                    ansInt[1]++;
                }
                else if (NoteTextObjScript.instance.noteWrites[child.name] == "ħ���� ������ ����")
                {
                    ansInt[1]++;
                }
                else if (NoteTextObjScript.instance.noteWrites[child.name] == "��⿡�� �������� �������� �����")
                {
                    ansInt[1]++;
                }
                else if (NoteTextObjScript.instance.noteWrites[child.name] == "�����ڴ� �ڽ��� ������ ������")
                {
                    ansInt[2]++;
                }
                else if (NoteTextObjScript.instance.noteWrites[child.name] == "�����ڴ� �ڽ��� ������ ���������� ������� �����")
                {
                    ansInt[2]++;
                }
                else if (NoteTextObjScript.instance.noteWrites[child.name] == "���� ����� ���������� ����")
                {
                    ansInt[3]++;
                }
            }
        }
        foreach (int i in ansInt)
        {
            if (i == 0)
            {
                // ����
                return false;
            }
        }
        // ����
        return true;
    }
}
