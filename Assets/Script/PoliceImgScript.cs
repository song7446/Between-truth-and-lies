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

        // 형사 이미지 오브젝트 불러오기 
        policeImg = GameObject.Find("PoliceImg");
        policeImgSr = policeImg.GetComponent<SpriteRenderer>();

        // 형사 이미지 오브젝트 투명화 
        policeImgSr.material.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
    }


    void Update()
    {
        // 씬 #1 프론트 그라운드가 사라질때 형사 이미지 페이드인
        StartCoroutine(fadeInOutObj.GetComponent<FadeInOut>().srFadeIn(policeImgSr));

        // 형사 이미지 상태 
        policeImgOn = true;
    }
}
