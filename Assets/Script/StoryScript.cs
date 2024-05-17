using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoryScript : MonoBehaviour
{
    public Text scriptTxt;
    public Text talkName;

    GameObject textObj;

    private string text;
    private float delay = 0.05f;

    int scriptCount = 0;
    public bool printBool = false;

    GameObject textPrintObj;

    void Start()
    {
        // ���丮 ��ũ��Ʈ ��������
        textObj = GameObject.Find("Scene1ScriptObj");

        // ���丮 ��ũ��Ʈ �ʱ�ȭ
        scriptTxt.text = "";
        talkName.text = "";

        textPrintObj = GameObject.Find("TextPrintObj");
    }

    void Update()
    {
        // ���콺 �� �����̽��� Ŭ���� ���丮 ��ũ��Ʈ ����
        if (Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.Space))
        {
            scriptCount++;
            // �߰� Ŭ���� �ؽ�Ʈ�� ��ġ�� ������ 2���� ��� 
            if (scriptCount % 2 == 0)
            {
                UpdateScript(scriptCount);
            }
        }
    }

    public void UpdateScript(int num)
    {
        // ���丮 �ؽ�Ʈ
        text = textObj.GetComponent<Scene1Script>().ScriptCollection(num);
        // ȭ�� �̸�
        string name = textObj.GetComponent<Scene1Script>().NameCollection(num);

        this.talkName.text = name;
        scriptTxt.text = "";

        // �ؽ�Ʈ �ѱ��ھ� ���
        StartCoroutine(textPrintObj.GetComponent<TextPrintScript>().TextPrint(delay, text, scriptTxt));
    }
}
