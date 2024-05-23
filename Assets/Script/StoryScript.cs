using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using TMPro;
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
    private float delay = 0.05f;

    public bool printBool = false;

    void Start()
    {
        // 스토리 스크립트 초기화
        scriptTxt.text = "";
        talkName.text = "";
    }

    public void UpdateScript(int num)
    {
        // 스토리 텍스트
        text = Scene1Script.instance.ScriptCollection(num);
        // 화자 이름
        string name = Scene1Script.instance.NameCollection(num);

        this.talkName.text = name;
        scriptTxt.text = "";

        // 텍스트 한글자씩 출력
        StartCoroutine(TextPrintScript.instance.TextPrint(delay, text, scriptTxt));
    }
}
