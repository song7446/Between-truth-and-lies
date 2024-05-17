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
        // 스토리 스크립트 가져오기
        textObj = GameObject.Find("Scene1ScriptObj");

        // 스토리 스크립트 초기화
        scriptTxt.text = "";
        talkName.text = "";

        textPrintObj = GameObject.Find("TextPrintObj");
    }

    void Update()
    {
        // 마우스 및 스페이스바 클릭시 스토리 스크립트 시작
        if (Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.Space))
        {
            scriptCount++;
            // 중간 클릭시 텍스트가 겹치기 때문에 2개씩 띄움 
            if (scriptCount % 2 == 0)
            {
                UpdateScript(scriptCount);
            }
        }
    }

    public void UpdateScript(int num)
    {
        // 스토리 텍스트
        text = textObj.GetComponent<Scene1Script>().ScriptCollection(num);
        // 화자 이름
        string name = textObj.GetComponent<Scene1Script>().NameCollection(num);

        this.talkName.text = name;
        scriptTxt.text = "";

        // 텍스트 한글자씩 출력
        StartCoroutine(textPrintObj.GetComponent<TextPrintScript>().TextPrint(delay, text, scriptTxt));
    }
}
