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
        // 형사 이미지 오브젝트 불러오기 
        policeImg = GameObject.Find("PoliceImg");
        policeImgSr = policeImg.GetComponent<SpriteRenderer>();

        // 형사 이미지 오브젝트 투명화 
        policeImgSr.material.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
    }


    public void policeImageFadeIn()
    {
        // 씬 #1 프론트 그라운드가 사라질때 형사 이미지 페이드인
        StartCoroutine(FadeInOut.instance.srFadeIn(policeImgSr));

        // 형사 이미지 상태 
        policeImgOn = true;
    }
}
