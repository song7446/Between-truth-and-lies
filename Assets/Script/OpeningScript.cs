using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class OpeningScript : MonoBehaviour
{
    public Text openingTxt;

    GameObject textPrintObj;
    GameObject fadeInOutObj;

    void Start()
    {
        openingTxt.text = "";

        // 한글자씩 출력 함수 오브젝트
        textPrintObj = GameObject.Find("TextPrintObj");
        string txt = "Scene #1";
        float delay = 0.25f;

        StartCoroutine(textPrintObj.GetComponent<TextPrintScript>().TextPrint(delay, txt, openingTxt));       
    }


    void Update()
    {
        if(Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.Space))
        {
            // 페이드 인아웃 함수 오브젝트
            fadeInOutObj = GameObject.Find("FadeInOutObj");

            // 프론트 그라운드 오브젝트
            GameObject openingBackGround = GameObject.Find("FrontGround");
            Image obgsp = openingBackGround.GetComponent<Image>();

            Debug.Log(obgsp.color);

            StartCoroutine(fadeInOutObj.GetComponent<FadeInOut>().imageFadeOut(obgsp));
        }
    }
}
