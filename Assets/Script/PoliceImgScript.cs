using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceImgScript : MonoBehaviour
{
    // �̱������� �ٸ� ��ũ��Ʈ �ҷ�����
    public static PoliceImgScript instance;

    private void Awake()
    {
        if (PoliceImgScript.instance == null)
        {
            PoliceImgScript.instance = this;
            
        }
    }

    //float fadeSpeed = 0.5f;

    // ���� �̹��� ���� 
    public bool policeImgOn = false;

    // ���� �̹��� ������Ʈ 
    GameObject policeImg;

    // ���� �̹��� ��������Ʈ ������ 
    SpriteRenderer policeImgSr;

    void Start()
    {
        // ���� �̹��� ������Ʈ �ҷ����� 
        policeImg = GameObject.Find("PoliceImg");

        // ���� �̹��� ��������Ʈ ������ �ҷ����� 
        policeImgSr = policeImg.GetComponent<SpriteRenderer>();

        // ���� �̹��� ������Ʈ ����ȭ 
        policeImgSr.material.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
    }

    // ���� �̹��� ���̵��� �Լ� 
    public void PoliceImageFadeIn()
    {
        // �� #1 ����Ʈ �׶��尡 ������� ���� �̹��� ���̵���
        StartCoroutine(FadeInOut.instance.SrFadeIn(policeImgSr));

        // ���� �̹��� ���� 
        policeImgOn = true;
    }

    // ���� �̹��� ���̵��� ��ŵ 
    public void PoliceImageFadeInSkip()
    {
        StopAllCoroutines();
        policeImgSr.material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }

}
