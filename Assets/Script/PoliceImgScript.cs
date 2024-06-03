using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceImgScript : MonoBehaviour
{
    public static PoliceImgScript instance;

    private void Awake()
    {
        if (PoliceImgScript.instance == null)
        {
            PoliceImgScript.instance = this;
            
        }
    }

    float fadeSpeed = 0.5f;
    public bool policeImgOn = false;
    public bool fadeOutOnExit = true;

    GameObject policeImg;

    SpriteRenderer policeImgSr;

    void Start()
    {
        // ���� �̹��� ������Ʈ �ҷ����� 
        policeImg = GameObject.Find("PoliceImg");
        policeImgSr = policeImg.GetComponent<SpriteRenderer>();

        // ���� �̹��� ������Ʈ ����ȭ 
        policeImgSr.material.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
    }


    public void policeImageFadeIn()
    {
        // �� #1 ����Ʈ �׶��尡 ������� ���� �̹��� ���̵���
        StartCoroutine(FadeInOut.instance.srFadeIn(policeImgSr));

        // ���� �̹��� ���� 
        policeImgOn = true;
    }
}
