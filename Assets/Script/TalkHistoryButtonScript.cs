using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TalkHistoryButtonScript : MonoBehaviour
{
    // �̱������� �ٸ� ��ũ��Ʈ �ҷ�����
    public static TalkHistoryButtonScript Instance;

    private void Awake()
    {
        if (TalkHistoryButtonScript.Instance == null)
        {
            TalkHistoryButtonScript.Instance = this;
        }
    }

    // ��ȭ ��� ��ư 
    public Button talkHisBtn;

    void Start()
    {
        // ��ȭ ��� ��ư ������ �߰�
        talkHisBtn.onClick.AddListener(TalkHisBtn_onClick);

        // ��ȭ ��� ��ư ��Ȱ��ȭ 
        talkHisBtn.gameObject.SetActive(false);
    }

    // ��ȭ ��� ��ư Ŭ�� �Լ� 
    void TalkHisBtn_onClick()
    {
        // ��ȭ ��� é�� UI�� �����ְų� ��ȭ ��� UI�� Ȱ��ȭ�� ��
        if (TalkHistoryChapterScript.instance.talkHisChaBool || TalkHistoryScript.instance.talkHisBool)
        {
            // ��ȭ ��� é�� UI ��Ȱ��ȭ 
            TalkHistoryChapterScript.instance.talkHisCha.SetActive(false);

            // ��ȭ ��� é�� ���� ��Ȱ��ȭ�� ����
            TalkHistoryChapterScript.instance.talkHisChaBool = false;

            // ��ȭ ��� UI ��Ȱ��ȭ 
            TalkHistoryScript.instance.talkHis.SetActive(false);

            // ��ȭ ��� UI ���� ��Ȱ��ȭ�� ���� 
            TalkHistoryScript.instance.talkHisBool = false;

            // ��ȭ ��� UI���� é�� ���� UI�� ���� ��ư Ȱ��ȭ 
            TalkHistoryScript.instance.backBtn.gameObject.SetActive(false);
        }
        else
        {
            // ��ȭ ��� é�� UI Ȱ��ȭ 
            TalkHistoryChapterScript.instance.talkHisCha.SetActive(true);

            // ��ȭ ��� é�� UI ���� Ȱ��ȭ�� ���� 
            TalkHistoryChapterScript.instance.talkHisChaBool = true;
        }
    }
}
