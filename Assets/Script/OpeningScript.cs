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
        // ����Ʈ �׶��� ������Ʈ
        GameObject openingBackGround = GameObject.Find("FrontGround");
        Image obgsp = openingBackGround.GetComponent<Image>();

        // ����Ʈ �׶��� �̹��� �ؽ�Ʈ ���̵� �ƿ�
        StartCoroutine(FadeInOut.instance.imageFadeOut(obgsp));
        StartCoroutine(FadeInOut.instance.textFadeOut(openingTxt));
    }
}
