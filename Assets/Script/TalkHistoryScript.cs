using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class TalkHistoryScript : MonoBehaviour
{
    // �̱������� �ٸ� ��ũ��Ʈ �ҷ�����
    public static TalkHistoryScript instance;

    private void Awake()
    {
        if (TalkHistoryScript.instance == null)
        {
            TalkHistoryScript.instance = this;

        }
    }

    // ��ȭ ��� UI ���� 
    public bool talkHisBool = false;

    // ��ȭ ��� ������Ʈ
    public GameObject talkHis;

    // ��ȭ ����
    public string talkText;

    // ȭ�� �̸� 
    public string talkName;

    // ��ȭ ��� �ؽ�Ʈ ��ġ ������ �ҷ����� ������Ʈ  
    public GameObject leftRight;

    // ��ȭ ��� ������Ʈ 
    public GameObject talkLog;

    // ��ȭ ����� �θ� ������Ʈ 
    public GameObject parentObject;

    // ��ȭ ��� UI���� ��ȭ ��� é�ͷ� ���� ��ư 
    public Button backBtn;

    // ��ȭ ��� ������Ʈ �̸��� �ε��� 
    int index = 1;

    void Start()
    {
        // ��ȭ ��� ������Ʈ ã�� 
        talkHis = GameObject.Find("TalkHistory");

        // ��ȭ ��� ������Ʈ ��Ȱ��ȭ 
        talkHis.SetActive(false);

        // ��ȭ ��� �θ� ������Ʈ ���� 
        parentObject = talkHis.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;

        // ��ȭ ��� UI���� ��ȭ ��� é�ͷ� ���� ��ư ������ �߰�
        backBtn.onClick.AddListener(BackBtn_onClick);

        // ��ȭ ��� UI���� ��ȭ ��� é�ͷ� ���� ��ư ��Ȱ��ȭ 
        backBtn.gameObject.SetActive(false);
    }

    // ��ȭ ��� ������Ʈ �Լ� 
    public void UpdateTalkHistory(int num)
    {
        // ���丮�� ������ �ʾ��� �� 
        if (Scene1Script.instance.ScriptCollection(num) != "")
        {
            // ��ȭ ���� �ҷ����� 
            talkText = Scene1Script.instance.ScriptCollection(num);
            // ȭ�� �̸� �ҷ����� 
            talkName = Scene1Script.instance.NameCollection(num);

            // ȭ�ڰ� ���ΰ��̸�
            if (talkName == "���ΰ�")
            {
                // �ؽ�Ʈ�� ������ ���ĵ� ������ �ҷ����� 
                leftRight = Resources.Load<GameObject>("PreFab/TalkLogRight");
            }

            // ȭ�ڰ� ���ΰ��� �ƴϸ�
            else
            {
                // �ؽ�Ʈ�� ���� ���ĵ� ������ �ҷ����� 
                leftRight = Resources.Load<GameObject>("PreFab/TalkLogLeft");
            }

            // �ҷ��� ������ ��ȭ ��� ������Ʈ�� ���� 
            talkLog = GameObject.Instantiate<GameObject>(leftRight);

            // ��ȭ ��� ������Ʈ �θ� ����
            talkLog.transform.SetParent(parentObject.transform, false);

            // ȭ�� �̸� ������Ʈ ����
            GameObject name = talkLog.transform.GetChild(0).gameObject;

            // ȭ�� �̸� ���� 
            name.GetComponent<Text>().text = talkName;

            // ��ȭ ���� ������Ʈ ���� 
            GameObject text = talkLog.transform.GetChild(1).gameObject;

            // ��ȭ ���� ���� 
            text.GetComponent<Text>().text = talkText;

            // ��ȭ ��� ������Ʈ �̸� ���� 
            talkLog.name = "TalkLog " + index;

            // ��ȭ ��� ������Ʈ �̸��� �ε��� ���� 
            index++;
        }       
    }

    // ��ȭ ��� UI���� ��ȭ ��� é�ͷ� ���� ��ư Ŭ�� �Լ� 
    void BackBtn_onClick()
    {
        // ��ȭ ��� UI ���� ��Ȱ��ȭ�� ����
        TalkHistoryScript.instance.talkHisBool = false;

        // ��ȭ��� UI ��Ȱ��ȭ 
        TalkHistoryScript.instance.talkHis.SetActive(false);

        // ��ȭ ��� é�� UI Ȱ��ȭ 
        TalkHistoryChapterScript.instance.talkHisCha.SetActive(true);

        // ��ȭ ��� UI���� ��ȭ ��� é�ͷ� ���� ��ư ��Ȱ��ȭ 
        backBtn.gameObject.SetActive(false);
    }
}
