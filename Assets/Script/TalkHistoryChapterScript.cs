using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkHistoryChapterScript : MonoBehaviour
{
    // �̱������� �ٸ� ��ũ��Ʈ �ҷ�����
    public static TalkHistoryChapterScript instance;
    private void Awake()
    {
        if (TalkHistoryChapterScript.instance == null)
        {
            TalkHistoryChapterScript.instance = this;

        }
    }

    // ��ȭ ��� é�� ��ư 
    public Button talkHisChaBtn1;
    public Button talkHisChaBtn2;
    public Button talkHisChaBtn3;
    public Button talkHisChaBtn4;

    // ��ȭ ��� é�� UI ������Ʈ 
    public GameObject talkHisCha;

    // ��ȭ ��� é�� UI ���� 
    public bool talkHisChaBool = false;

    void Start()
    {
        // ��ȭ ��� é�� ��ư ������ �߰�
        talkHisChaBtn1.onClick.AddListener(TalkHisChaBtn1_onClick);
        talkHisChaBtn2.onClick.AddListener(TalkHisChaBtn2_onClick);

        // ��ȭ ��� é�� UI ������Ʈ ã�� 
        talkHisCha = GameObject.Find("TalkHistoryChapter");

        // ��ȭ ��� é�� UI ��Ȱ��ȭ 
        talkHisCha.SetActive(false);
    }

    // 1��° é�� ��ư Ŭ�� �Լ� 
    void TalkHisChaBtn1_onClick()
    {
        // ��ȭ ��� UI ���� Ȱ��ȭ�� ���� 
        TalkHistoryScript.instance.talkHisBool = true;

        // ��ȭ ��� UI Ȱ��ȭ 
        TalkHistoryScript.instance.talkHis.SetActive(true);

        // ��ȭ ��� UI���� é�� ���� UI�� ���� ��ư Ȱ��ȭ 
        TalkHistoryScript.instance.backBtn.gameObject.SetActive(true);

        // ��ȭ ��� é�� UI ��Ȱ��ȭ 
        talkHisCha.SetActive(false);
    }

    // 2��° é�� ��ư Ŭ�� �Լ� 
    void TalkHisChaBtn2_onClick()
    {
        Debug.Log("2�� ��ư Ŭ��");
    }
}
