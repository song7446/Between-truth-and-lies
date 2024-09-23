using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using TMPro;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UI;

public class StoryScript : MonoBehaviour
{
    // �̱������� �ٸ� ��ũ��Ʈ �ҷ�����
    public static StoryScript instance;

    private void Awake()
    {
        if(StoryScript.instance == null)
        {
            StoryScript.instance = this;
        }
    }

    // ���ӿ� ��µǴ� ���丮 �ؽ�Ʈ 
    public Text scriptTxt;
    
    // ���ӿ� ��µǴ� ȭ�� �̸� 
    public Text talkName;

    // ���丮 ��ũ��Ʈ���� �ҷ��� �ؽ�Ʈ 
    public string text;

    // ���丮 ��ũ��Ʈ���� �ҷ��� ȭ�� �̸� 
    public string speakerName;

    // ��� �ӵ� 
    private float delay = 0.05f;

    void Start()
    {
        // ���ӿ� ��µǴ� �ؽ�Ʈ �ʱ�ȭ
        scriptTxt.text = "";
        talkName.text = "";
    }

    // ���丮 ������Ʈ �Լ� 
    public void UpdateScript(int num)
    {
        // ���丮�� ������ �ʾҴٸ� - ���丮�� ������ �ƹ��͵� ��ȯ���� �ʱ� ���� 
        if (Scene1Script.instance.ScriptCollection(num)!="")
        {
            // ���丮 �ؽ�Ʈ �Լ� ȣ�� 
            text = Scene1Script.instance.ScriptCollection(num);

            // ȭ�� �̸� �Լ� ȣ��
            speakerName = Scene1Script.instance.NameCollection(num);

            // ���ӿ� ��µǴ� ȭ�� �̸� ���� 
            this.talkName.text = speakerName;

            // ���ӿ� ��µǴ� ���丮 �ؽ�Ʈ �ʱ�ȭ - ������ �����ϰ�� �׻� �ؽ�Ʈ�� �ֱ� ������ �ѱ��ھ� ����ϱ� ���� �ʱ�ȭ  
            scriptTxt.text = "";

            // �ؽ�Ʈ �ѱ��ھ� ��� �Լ� ȣ��
            StartCoroutine(TextPrintScript.instance.TextPrint(delay, text, scriptTxt));
        }
    }

    // ���丮 �ؽ�Ʈ ��� �ڷ�ƾ ��ŵ 
    public void ScriptCoroutineSkip()
    {
        // ��� �ڷ�ƾ ���� 
        StopAllCoroutines();

        // ���ӿ� ��µǴ� ���丮 �ؽ�Ʈ ���� 
        scriptTxt.text = text;
    }
}
