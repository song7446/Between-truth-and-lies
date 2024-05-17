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

        // �ѱ��ھ� ��� �Լ� ������Ʈ
        textPrintObj = GameObject.Find("TextPrintObj");
        string txt = "Scene #1";
        float delay = 0.25f;

        StartCoroutine(textPrintObj.GetComponent<TextPrintScript>().TextPrint(delay, txt, openingTxt));       
    }


    void Update()
    {
        if(Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.Space))
        {
            // ���̵� �ξƿ� �Լ� ������Ʈ
            fadeInOutObj = GameObject.Find("FadeInOutObj");

            // ����Ʈ �׶��� ������Ʈ
            GameObject openingBackGround = GameObject.Find("FrontGround");
            Image obgsp = openingBackGround.GetComponent<Image>();

            Debug.Log(obgsp.color);

            StartCoroutine(fadeInOutObj.GetComponent<FadeInOut>().imageFadeOut(obgsp));
        }
    }
}
