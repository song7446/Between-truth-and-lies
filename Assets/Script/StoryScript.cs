using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using TMPro;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UI;

public class StoryScript : MonoBehaviour
{
    // 싱글톤으로 다른 스크립트 불러오기
    public static StoryScript instance;

    private void Awake()
    {
        if(StoryScript.instance == null)
        {
            StoryScript.instance = this;
        }
    }

    // 게임에 출력되는 스토리 텍스트 
    public Text scriptTxt;
    
    // 게임에 출력되는 화자 이름 
    public Text talkName;

    // 스토리 스크립트에서 불러올 텍스트 
    public string text;

    // 스토리 스크립트에서 불러올 화자 이름 
    public string speakerName;

    // 출력 속도 
    private float delay = 0.05f;

    void Start()
    {
        // 게임에 출력되는 텍스트 초기화
        scriptTxt.text = "";
        talkName.text = "";
    }

    // 스토리 업데이트 함수 
    public void UpdateScript(int num)
    {
        // 스토리가 끝나지 않았다면 - 스토리가 끝나면 아무것도 반환하지 않기 때문 
        if (Scene1Script.instance.ScriptCollection(num)!="")
        {
            // 스토리 텍스트 함수 호출 
            text = Scene1Script.instance.ScriptCollection(num);

            // 화자 이름 함수 호출
            speakerName = Scene1Script.instance.NameCollection(num);

            // 게임에 출력되는 화자 이름 저장 
            this.talkName.text = speakerName;

            // 게임에 출력되는 스토리 텍스트 초기화 - 시작을 제외하고는 항상 텍스트가 있기 때문에 한글자씩 출력하기 위해 초기화  
            scriptTxt.text = "";

            // 텍스트 한글자씩 출력 함수 호출
            StartCoroutine(TextPrintScript.instance.TextPrint(delay, text, scriptTxt));
        }
    }

    // 스토리 텍스트 출력 코루틴 스킵 
    public void ScriptCoroutineSkip()
    {
        // 모든 코루틴 중지 
        StopAllCoroutines();

        // 게임에 출력되는 스토리 텍스트 저장 
        scriptTxt.text = text;
    }
}
