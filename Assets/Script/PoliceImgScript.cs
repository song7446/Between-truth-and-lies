using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceImgScript : MonoBehaviour
{
    float fadeSpeed = 0.5f;
    public bool policeImgOn = false;
    public bool fadeOutOnExit = true;

    GameObject policeImg;
    GameObject fadeInOutObj;


    SpriteRenderer policeImgSr;

    void Start()
    {
        fadeInOutObj = GameObject.Find("FadeInOutObj");

        // ���� �̹��� ������Ʈ �ҷ����� 
        policeImg = GameObject.Find("PoliceImg");
        policeImgSr = policeImg.GetComponent<SpriteRenderer>();

        // ���� �̹��� ������Ʈ ����ȭ 
        policeImgSr.material.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
    }


    void Update()
    {
        // �� #1 ����Ʈ �׶��尡 ������� ���� �̹��� ���̵���
        StartCoroutine(fadeInOutObj.GetComponent<FadeInOut>().srFadeIn(policeImgSr));

        // ���� �̹��� ���� 
        policeImgOn = true;
    }
}
