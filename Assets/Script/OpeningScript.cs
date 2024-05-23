using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class OpeningScript : MonoBehaviour
{
    public static OpeningScript instance;

    public Text openingTxt;

    private void Awake()
    {
        if(OpeningScript.instance == null)
        {
            OpeningScript.instance = this;
        }
    }

    public void openingScript()
    {
        openingTxt.text = "";

        string txt = "Scene #1";
        float delay = 0.25f;

        StartCoroutine(TextPrintScript.instance.TextPrint(delay, txt, openingTxt));

    }

    public void openingImage()
    {
        // 프론트 그라운드 오브젝트
        GameObject openingBackGround = GameObject.Find("FrontGround");
        Image obgsp = openingBackGround.GetComponent<Image>();

        // 프론트 그라운드 이미지 텍스트 페이드 아웃
        StartCoroutine(FadeInOut.instance.imageFadeOut(obgsp));
        StartCoroutine(FadeInOut.instance.textFadeOut(openingTxt));
    }
}
