using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUseButtonScript : MonoBehaviour
{
    // �̱������� �ٸ� ��ũ��Ʈ �ҷ�����
    public static TextUseButtonScript instance;

    private void Awake()
    {
        if (TextUseButtonScript.instance == null)
        {
            TextUseButtonScript.instance = this;

        }
    }

    // �ֿ� �ؽ�Ʈ ����ư ������Ʈ 
    public GameObject textUseBtnObj;

    // �ֿ� �ؽ�Ʈ ��� ��ư
    public Button textUseBtn;

    // �ֿ� �ؽ�Ʈ ��� ��� ��ư 
    public Button textUnUseBtn;

    // ȭ�� �̸�
    public Text talkName;

    // ��ȭ ����
    public Text talkText;

    // ��ȭ ��� ������Ʈ 
    public GameObject talkObj;

    // �ֿ� �ؽ�Ʈ ��� ������ ���� ī��Ʈ 
    int count = 0;

    // �ֿ� �ؽ�Ʈ �ƴ� �ؽ�Ʈ ��� ����  
    public bool falseTextUseBool;

    // �ʹ� ���� �ؽ�Ʈ ��� ���� 
    public bool tooManyTextUseBool;

    void Start()
    {
        // �ֿ� �ؽ�Ʈ ��� ��ư ������ �߰� 
        textUseBtn.onClick.AddListener(TextUseBtn_onClick);
        
        // �ֿ� �ؽ�Ʈ ��� ��� ��ư ������ �߰� 
        textUnUseBtn.onClick.AddListener(TextUnUseBtn_onClick);

        // �ֿ� �ؽ�Ʈ ��� ��ư ��Ȱ��ȭ 
        textUseBtn.gameObject.SetActive(false);

        // �ֿ� �ؽ�Ʈ ��� ��� ��ư ��Ȱ��ȭ 
        textUnUseBtn.gameObject.SetActive(false);
    }

    private void Update()
    {
        // �ؽ�Ʈ ��� �ڷ�ƾ�� ������� ���� �� 
        if (StoryManager.instance.coroutineBool==false)
        {
            // �ֿ� �ؽ�Ʈ �ƴ� �ؽ�Ʈ ���� ��Ȱ��ȭ 
            FalseTextUseScript.instance.falTxtObj.SetActive(false);

            // �ֿ� �ؽ�Ʈ �ƴ� �ؽ�Ʈ ���� ���·� ����
            FalseTextUseScript.instance.falTxtObj.GetComponent<Text>().color = new Color(255,0,0,255);

            // �ʹ� ���� �ؽ�Ʈ ��� ������Ʈ ��Ȱ��ȭ 
            TooManyTextUseScript.instance.tooManyTextUseObj.SetActive(false);

            // �ʹ� ���� �ؽ�Ʈ ��� ������Ʈ ���� ���·� ���� 
            TooManyTextUseScript.instance.tooManyTextUseObj.GetComponent<Text>().color = new Color(255, 0, 0, 255);

            // ���� ������Ʈ ��Ȱ��ȭ 
            AnswerResultScript.instance.worObj.SetActive(false);

            // ���� ������Ʈ ���û��·� ���� 
            AnswerResultScript.instance.worObj.GetComponent<Text>().color = new Color(255, 0, 0, 255);
        }
    }

    // �ֿ� �ؽ�Ʈ ��� ��ư �Լ� 
    void TextUseBtn_onClick()
    {
        // ȭ�� �̸� �ҷ����� 
        talkName = talkObj.transform.GetChild(0).gameObject.GetComponent<Text>();
        
        // ��ȭ ���� �ҷ����� 
        talkText = talkObj.transform.GetChild(1).gameObject.GetComponent<Text>();

        // �ֿ� �ؽ�Ʈ ��� ������ 4�� �̸��϶� 
        if (count < 4)
        {
            // ������ �ؽ�Ʈ�� �ֿ� �ؽ�Ʈ�� �´ٸ�  
            if (NoteTextObjScript.instance.UpdateNoteText(talkObj))
            {
                // ȭ�� �̸� �� ���������� ����
                talkName.color = Color.red;

                // ��ȭ ���� �� ���������� ���� 
                talkText.color = Color.red;

                // �ֿ� �ؽ�Ʈ ���� ���� 
                count++;
            }
            // ������ �ؽ�Ʈ�� �ֿ� �ؽ�Ʈ�� �ƴ϶��
            else
            {
                // ���콺 ��ġ ���� 
                Vector2 mousePosition = Input.mousePosition;
                
                // �ֿ� �ؽ�Ʈ �ƴ� �ؽ�Ʈ ������Ʈ ��ġ ���� ���콺 ��ġ�� ���� 
                FalseTextUseScript.instance.falTxtObj.transform.position = mousePosition;

                // �ֿ� �ؽ�Ʈ �ƴ� �ؽ�Ʈ ��� ������Ʈ Ȱ��ȭ 
                FalseTextUseScript.instance.falTxtObj.SetActive(true);

                // ���� �ֿ� �ؽ�Ʈ �ƴ� �ؽ�Ʈ ��� ������Ʈ ���̵� �ƿ� 
                StartCoroutine(FadeInOut.instance.FadeOut(FalseTextUseScript.instance.falTxtObj.GetComponent<Text>(), 0.25f));
            }
        }
        // �ֿ� �ؽ�Ʈ�� 4�� �̻��� �� 
        else
        {
            // ���콺 ��ġ ���� 
            Vector2 mousePosition = Input.mousePosition;

            // �ʹ� ���� �ؽ�Ʈ ��� ������Ʈ ��ġ ���� ���콺 ��ġ�� ����  
            TooManyTextUseScript.instance.tooManyTextUseObj.transform.position = mousePosition;

            // �ʹ� ���� �ؽ�Ʈ ��� ������Ʈ Ȱ��ȭ 
            TooManyTextUseScript.instance.tooManyTextUseObj.SetActive(true);

            // �ʹ� ���� �ؽ�Ʈ ��� ������Ʈ ���̵� �ƿ� 
            StartCoroutine(FadeInOut.instance.FadeOut(TooManyTextUseScript.instance.tooManyTextUseObj.GetComponent<Text>(), 0.25f));
        }

        // �ֿ� �ؽ�Ʈ ��� ��ư ��Ȱ��ȭ 
        textUseBtn.gameObject.SetActive(false);

        // �ֿ� �ؽ�Ʈ ��� ��� ��ư ��Ȱ��ȭ 
        textUnUseBtn.gameObject.SetActive(false);        
    }

    // ���õ� ��ȭ ��� ������Ʈ �ҷ����� 
    public void GetTalkObj(GameObject Obj)
    {
        talkObj = Obj;
    }

    // �ֿ� �ؽ�Ʈ ��� ��� ��ư Ŭ�� �Լ� 
    void TextUnUseBtn_onClick()
    {
        // ȭ�� �̸� �ҷ����� 
        talkName = talkObj.transform.GetChild(0).gameObject.GetComponent<Text>();
        
        // ��ȭ ���� �ҷ����� 
        talkText = talkObj.transform.GetChild(1).gameObject.GetComponent<Text>();

        // ȭ�� �̸� �� �Ͼ������ ����
        talkName.color = Color.white;

        // ��ȭ ���� �� �Ͼ������ ���� 
        talkText.color = Color.white;

        // �ֿ� �ؽ�Ʈ ��� ��ư ��Ȱ��ȭ 
        textUseBtn.gameObject.SetActive(false);

        // �ֿ� �ؽ�Ʈ ��� ��� ��ư ��Ȱ��ȭ 
        textUnUseBtn.gameObject.SetActive(false);

        // ��Ʈ �ؽ�Ʈ���� ���õ� ��ȭ ��� ���� 
        NoteTextObjScript.instance.DeleteNoteText(talkObj);

        // �ֿ� �ؽ�Ʈ ���� ���� 
        count--;
    }
}
