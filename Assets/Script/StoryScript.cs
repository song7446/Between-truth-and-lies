using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using TMPro;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UI;

public class StoryScript : MonoBehaviour
{
    public static StoryScript instance;

    private void Awake()
    {
        if(StoryScript.instance == null)
        {
            StoryScript.instance = this;
        }
    }

    public Text scriptTxt;
    public Text talkName;

    private string text;
    private string speakerName;
    private float delay = 0.05f;

    void Start()
    {
        // ���丮 ��ũ��Ʈ �ʱ�ȭ
        scriptTxt.text = "";
        talkName.text = "";
    }

    public void UpdateScript(int num)
    {
        // ���丮 �ؽ�Ʈ
        text = Scene1Script.instance.ScriptCollection(num);
        // ȭ�� �̸�
        speakerName = Scene1Script.instance.NameCollection(num);

        this.talkName.text = speakerName;
        scriptTxt.text = "";

        // �ؽ�Ʈ �ѱ��ھ� ���
        StartCoroutine(TextPrintScript.instance.TextPrint(delay, text, scriptTxt));
    }

    public void coroutineSkip()
    {
        StopAllCoroutines();
        this.talkName.text = speakerName;
        scriptTxt.text = text;
    }
}
