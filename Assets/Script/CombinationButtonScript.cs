using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CombinationButtonScript : MonoBehaviour
{
    // �̱������� �ٸ� ��ũ��Ʈ �ҷ�����
    public static CombinationButtonScript Instance;

    private void Awake()
    {
        if (CombinationButtonScript.Instance == null)
        {
            CombinationButtonScript.Instance = this;
        }
    }

    // ���� ��ư
    public Button comBtn;

    // ���� ��ư ����
    public bool comBtnBool;

    // ��Ʈ ���� ������ ������Ʈ
    public GameObject noteLeftTextObj;

    // ���� ����
    public bool ansCheckBool;

    // ��Ʈ ���� ������ �ؽ�Ʈ ������ �ҷ������ ������Ʈ
    public GameObject loadTextObj;

    // ���� Ȱ��ȭ�Ǵ� ��Ʈ �ؽ�Ʈ ������Ʈ 
    public GameObject noteTextObj;

    // �����̶�� �˷��ִ� �ؽ�Ʈ ����
    public bool correctAnswerBool;

    // �����̶�� �˷��ִ� �ؽ�Ʈ ����
    public bool worngAnswerBool;

    void Start()
    {
        // ���� ��ư ������
        comBtn.onClick.AddListener(ComBtn_onClick);

        // ���� ��ư�� ��Ʈ�� ������ �� ����ϱ� ������ �����Ҷ��� ��Ȱ��ȭ
        comBtn.gameObject.SetActive(false);
    }


    void Update()
    {

    }

    // ���� ��ư ������ �Լ�
    void ComBtn_onClick()
    {
        // ���� üũ �Լ� �ҷ�����
        if (AnsCheck())
        {
            // ���� �϶�  

            // ������ ���� ��ȭ �α� �ڽĵ� ��� ��������
            Transform[] allChildren = noteLeftTextObj.GetComponentsInChildren<Transform>();

            // ��� �ڽ��� ����ϱ� ���� �ݺ���
            foreach (Transform child in allChildren)
            {
                // GetComponentsInChildren �Լ��� �ڽĻӸ� �ƴ϶� ���ε� �������� ������ ���� ����
                if (child.name == "LeftTextObj")
                {
                    // �θ� ��Ҵ� �ѱ��
                }
                else
                {
                    // �ڽĿ�Ҵ� ��� ���� 
                    Destroy(child.gameObject);
                }
            }

            // ������ �� �����̶�� �˷��ִ� ������Ʈ Ȱ��ȭ 
            AnswerResultScript.instance.corObj.SetActive(true);

            // �����̶�� �˷��ִ� ������Ʈ Ȱ��ȭ �� ���̵� �ƿ�
            StartCoroutine(FadeInOut.instance.TextFadeOut(AnswerResultScript.instance.corObj.GetComponent<Text>()));

            // ���� �ؽ�Ʈ �߰��ϱ� ���� ������ �ҷ����� 
            loadTextObj = Resources.Load<GameObject>("PreFab/NoteText");

            // ���� �ؽ�Ʈ ������ ���� 
            noteTextObj = GameObject.Instantiate<GameObject>(loadTextObj);

            // ���� �ؽ�Ʈ �θ� ������Ʈ ����
            noteTextObj.transform.SetParent(noteLeftTextObj.transform, false);

            // ���� �ؽ�Ʈ �̸� ����
            noteTextObj.name = "CorrectAnswer";

            // ���� �ؽ�Ʈ ���� 
            noteTextObj.GetComponent<Text>().text = "";
            string answer = "�Ĺ� ���翡 ���ϸ� �� ����� ���������� ���� ���� �ƹ����� �����߰� " +
                                                    "�ڽ��� ���� �ڽ��� ������ �Ű��ߴ�. " +
                                                    "���忡�� �߰ߵ� ���ŵ� �����ڸ� ����Ű�� �������� " +
                                                    "�����ڴ� �ڽ��� ������ �����ϸ鼭�� ������� ������̴�. ";
            // ���� �ؽ�Ʈ �ѱ��ھ� ��� 
            StartCoroutine(TextPrintScript.instance.TextPrint(0.05f, answer, noteTextObj.GetComponent<Text>()));

            // ���� ���� ��ư ���̵� �ƿ�
            StartCoroutine(FadeInOut.instance.TextFadeOut(comBtn.transform.GetChild(0).GetComponent<Text>()));        

            if (Scene1Script.instance.storyEnd)
            {
                Invoke("endingImgFadeIn", 10);
                Invoke("nextSceneLoad", 15);               
            }
        }

        else
        {
            // �����϶� 

            // �����̶�� �˷��ִ� ������Ʈ Ȱ��ȭ
            AnswerResultScript.instance.worObj.SetActive(true);

            // �����̶�� �˷��ִ� ������Ʈ Ȱ��ȭ �� ���̵� �ƿ�
            StartCoroutine(FadeInOut.instance.TextFadeOut(AnswerResultScript.instance.worObj.GetComponent<Text>()));
        }
    }

    // ���� üũ �Լ�
    public bool AnsCheck()
    {
        // �� ������Ʈ ��� �ҷ����� 
        Transform[] allChildren = noteLeftTextObj.GetComponentsInChildren<Transform>();

        // ���� üũ�ϱ� ���� �迭
        // 0 : ���� �ƺ��� ����/ 1 : ������ ���� ����/ 2 : ���� �ڽ��� ������ ����/ 3: ���� ����
        // ��� ��Ұ� �ϳ��� ���� �������� ����
        int[] ansInt = { 0, 0, 0, 0 };

        // ��� �ڽ��� ����ϱ� ���� �ݺ���
        foreach (Transform child in allChildren)
        {
            // GetComponentsInChildren �Լ��� �ڽĻӸ� �ƴ϶� ���ε� �������� ������ ���� ����
            if (child.name == "LeftTextObj")
            {
                // �θ� ��Ҵ� �ѱ��
            }
            else
            {
                // 0 : ���� �ƺ��� ���� 
                if (NoteTextObjScript.instance.noteWrites[child.name] == "���� �ƹ����� ������")
                {
                    ansInt[0]++;
                }

                // 2 : ���� �ڽ��� ������ ����
                else if (NoteTextObjScript.instance.noteWrites[child.name] == "�� ������ ���� �Ű���")
                {
                    ansInt[2]++;
                }

                // 1 : ������ ���� ����
                else if (NoteTextObjScript.instance.noteWrites[child.name] == "���忡 �ִ� ����� �����ڿ� ������ �ѻ���")
                {
                    ansInt[1]++;
                }

                // 1 : ������ ���� ����
                else if (NoteTextObjScript.instance.noteWrites[child.name] == "ħ���� ������ ����")
                {
                    ansInt[1]++;
                }

                // 1 : ������ ���� ����
                else if (NoteTextObjScript.instance.noteWrites[child.name] == "��⿡�� �������� �������� �����")
                {
                    ansInt[1]++;
                }

                // 2 : ���� �ڽ��� ������ ����
                else if (NoteTextObjScript.instance.noteWrites[child.name] == "�����ڴ� �ڽ��� ������ ������")
                {
                    ansInt[2]++;
                }

                //2 : ���� �ڽ��� ������ ����
                else if (NoteTextObjScript.instance.noteWrites[child.name] == "�����ڴ� �ڽ��� ������ ���������� ������� �����")
                {
                    ansInt[2]++;
                }

                // 3: ���� ����
                else if (NoteTextObjScript.instance.noteWrites[child.name] == "���� ����� ���������� ����")
                {
                    ansInt[3]++;
                }
            }
        }

        // ��� ��Ұ� ����ִ��� Ȯ�� 
        foreach (int i in ansInt)
        {
            // ��� �ϳ��� ���������� 
            if (i == 0)
            {
                // ����
                ansCheckBool = false;
                return false;
            }
        }

        // �װ� �ƴϸ� ����
        ansCheckBool = true;
        return true;
    }

    public void EndingImgFadeIn()
    {
        OpeningScript.instance.openingTxt.text = "";
        OpeningScript.instance.obgsp.color = new Color(0, 0, 0, 0);
        OpeningScript.instance.openingBackGround.SetActive(true);
        StartCoroutine(FadeInOut.instance.ImageFadeIn(OpeningScript.instance.obgsp));
    }

    public void NextSceneLoad()
    {
        SceneManager.LoadScene("Scene#2");
    }
}
