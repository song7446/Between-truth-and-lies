using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StoryManager : MonoBehaviour, IPointerClickHandler
{
    // �̱������� �ٸ� ��ũ��Ʈ �ҷ�����
    public static StoryManager instance;

    private void Awake()
    {
        if (StoryManager.instance == null)
        {
            StoryManager.instance = this;
        }
    }

    // �⺻ ī��Ʈ 
    private int count = 0;
    
    // ���丮 ī��Ʈ 
    private int storyCount = 0;

    // �⺻�� ���丮 ī��Ʈ�� ���� ������ �ڷ�ƾ �߰��� Ŭ���� �����ϱ� ����

    // �ڷ�ƾ ���� 
    public bool coroutineBool = false;

    void Start()
    {
        // ������ ��ũ��Ʈ �Լ� 
        OpeningScript.instance.ProceedOpeningScript();

        // ��Ʈ ��Ȱ��ȭ 
        NoteScript.instance.NotePanel.gameObject.SetActive(false);
    }

    void Update()
    {
        // UI�� Ȱ��ȭ �Ǿ����� ���� Ŭ�� �Ұ�  
        if (TalkHistoryScript.instance.talkHisBool || NoteScript.instance.noteBool || TalkHistoryChapterScript.instance.talkHisChaBool)
        {
            
        }
        // UI�� Ȱ��ȭ �Ǿ����� ���� �� Ŭ�� ���� 
        else
        {
            // ������Ű�� �Է����� �� 
            if (Input.GetKeyUp(KeyCode.Space))
            {
                // �ڷ�ƾ�� ����� ��
                if (coroutineBool)
                {
                    // �ڷ�ƾ ��ŵ �Լ�
                    CoroutineSkip();

                    // �ڷ�ƾ ��Ȱ��ȭ�� ���� ���� 
                    coroutineBool = false;
                }

                // �ڷ�ƾ�� ������� ���� �� ���丮 ���� 
                else
                {
                    // ���丮�� ������ ������ ���丮 ���� 
                    if (Scene1Script.instance.storyEnd == false)
                    {
                        // ���丮 ���� �Լ� 
                        StoryProceeding();

                        // �⺻ ī��Ʈ ���� 
                        count++;
                    }
                }
            }
        }
    }

    // UI�� ��ư�� �ƴ� ��� Ŭ�� �Լ�  
    public void OnPointerClick(PointerEventData data)
    {
        // �ڷ�ƾ�� ����� �� 
        if (coroutineBool)
        {
            // �ڷ�ƾ ��ŵ �Լ�
            CoroutineSkip();

            // �ڷ�ƾ ��Ȱ��ȭ�� ���� ���� 
            coroutineBool = false;
        }

        // �ڷ�ƾ�� ������� ���� �� ���丮 ���� 
        else
        {
            // ���丮�� ������ ������ ���丮 ���� 
            if (Scene1Script.instance.storyEnd == false)
            {
                // ���丮 ���� �Լ� 
                StoryProceeding();

                // �⺻ ī��Ʈ ���� 
                count++;
            }
        }
    }

    // ���丮 ���� �Լ� 
    void StoryProceeding()
    {
        // �⺻ ī��Ʈ ���ڿ� ���� ���� 
        switch (count)
        {
            // 0�� ������ 
            case 0:
                // ������ �̹��� ���̵� �ƿ� �Լ� ȣ��
                OpeningScript.instance.OpeningImageFadeOut();

                // ��Ʈ ��ư Ȱ��ȭ 
                NoteButtonScript.instance.noteBtn.gameObject.SetActive(true);

                // ��ȭ ��� ��ư Ȱ��ȭ 
                TalkHistoryButtonScript.Instance.talkHisBtn.gameObject.SetActive(true);
                break;

            // 2�� ���� �̹��� ���̵��� 
            case 2:
                // ���� �̹��� ���̵��� �Լ� ȣ��
                PoliceImgScript.instance.PoliceImageFadeIn();

                break;

            // �⺻�� ���丮 ���� 
            default:             
                // ���丮 �ؽ�Ʈ ������Ʈ �Լ� ȣ�� 
                StoryScript.instance.UpdateScript(storyCount);

                // ���丮 �ؽ�Ʈ ���࿡ ���� ��ȭ��� �Լ��� ȣ�� 
                TalkHistoryScript.instance.UpdateTalkHistory(storyCount);

                // ���丮�� ����Ǹ� ���丮 ī��Ʈ ���� 
                storyCount++;

                break;
        }
    }

    // �ڷ�ƾ ��ŵ �Լ� 
    void CoroutineSkip()
    {
        // �⺻ ī��Ʈ ���ڿ� ���� ���� 
        switch (count)
        {
            // 0�� ������ �ؽ�Ʈ ��� ��ŵ 
            case 0:
                // ������ �ؽ�Ʈ �ڷ�ƾ ��ŵ �Լ� ȣ�� 
                OpeningScript.instance.openingScriptCoroutineSkip();

                break;

            // 1�� ������ �̹��� ���̵�ƿ� ��ŵ
            case 1:
                // ������ �̹��� �ڷ�ƾ ��ŵ �Լ� ȣ�� 
                OpeningScript.instance.openingImageFadeOutCoroutineSkip();

                break;

            // 3�� ���� �̹��� ���̵��� ��ŵ 
            case 3:
                // ���� �̹��� ���̵��� �ڷ�ƾ ��ŵ �Լ� ȣ��
                PoliceImgScript.instance.PoliceImageFadeInSkip();

                break;

            // �⺻�� ���丮 �ؽ�Ʈ ��� ��ŵ 
            default:
                // ���丮 �ؽ�Ʈ ��� �ڷ�ƾ ��ŵ �Լ� ȣ�� 
                StoryScript.instance.ScriptCoroutineSkip();

                break;
        }
    }
}
