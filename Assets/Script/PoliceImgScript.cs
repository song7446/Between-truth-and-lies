using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceImgScript : MonoBehaviour
{
    // 싱글톤으로 다른 스크립트 불러오기
    public static PoliceImgScript instance;

    private void Awake()
    {
        if (PoliceImgScript.instance == null)
        {
            PoliceImgScript.instance = this;
            
        }
    }

    //float fadeSpeed = 0.5f;

    // 형사 이미지 상태 
    public bool policeImgOn = false;

    // 형사 이미지 오브젝트 
    GameObject policeImg;

    // 형사 이미지 스프라이트 렌더러 
    SpriteRenderer policeImgSr;

    void Start()
    {
        // 형사 이미지 오브젝트 불러오기 
        policeImg = GameObject.Find("PoliceImg");

        // 형사 이미지 스프라이트 렌더러 불러오기 
        policeImgSr = policeImg.GetComponent<SpriteRenderer>();

        // 형사 이미지 오브젝트 투명화 
        policeImgSr.material.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
    }

    // 형사 이미지 페이드인 함수 
    public void PoliceImageFadeIn()
    {
        // 씬 #1 프론트 그라운드가 사라질때 형사 이미지 페이드인
        StartCoroutine(FadeInOut.instance.SrFadeIn(policeImgSr));

        // 형사 이미지 상태 
        policeImgOn = true;
    }

    // 형사 이미지 페이드인 스킵 
    public void PoliceImageFadeInSkip()
    {
        StopAllCoroutines();
        policeImgSr.material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }

}
