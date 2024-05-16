using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoryScript : MonoBehaviour
{
    public Text ScriptTxt;
    public Text Name;

    GameObject textObj;

    private string text;
    private float delay = 0.05f;

    int scriptCount = 0;
    public bool printBool = false;

    void Start()
    {
        // 스토리 스크립트 가져오기
        textObj = GameObject.Find("Scene1ScriptObj");

        // 스토리 스크립트 초기화
        ScriptTxt.text = "";
        Name.text = "";
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

        Name.text = name;
        ScriptTxt.text = "";

        // 텍스트 한글자씩 출력
        StartCoroutine(TextPrint(delay));

    }

    // 텍스트 한글자씩 출력 함수 
    public IEnumerator TextPrint(float d)
    {
        int count = 0;
        while (count != text.Length)
        {
            // 텍스트 한글자씩 출력 도중 마우스 및 스페이스바 클릭시 모든 텍스트를 띄우고 코루틴 종료
            if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space))
            {
                ScriptTxt.text = text;
                yield break;
            }
            if (count < text.Length)
            {
                ScriptTxt.text += text[count].ToString();
                count++;
            }
            yield return new WaitForSeconds(d);
        }

        scriptCount++;
    }
}
