using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class FadeInOut : MonoBehaviour
{
    float fadeSpeed = 0.5f;
    public bool policeImgOn = false;
    public bool fadeOutOnExit = true;

    GameObject policeImg;
    GameObject talkBackGround;

    SpriteRenderer policeImgSr;
    SpriteRenderer talkBackGroudImg;

    void Start()
    {
        // 형사 이미지 오브젝트 불러오기 
        policeImg = GameObject.Find("PoliceImg");

        // 형사 이미지 오브젝트의 스프라이트렌더러 불러오기
        policeImgSr = policeImg.GetComponent<SpriteRenderer>();

        // 형사 이미지 오브젝트 투명화 
        policeImgSr.material.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);

        // 씬 #1 시작할 때 형사 이미지 페이드인
        StartCoroutine(FadeIn(policeImgSr));

        // 형사 이미지 상태 
        policeImgOn = true;


        // talkBackGround = GameObject.Find("TalkBackGround");
        // talkBackGroudImg = talkBackGround.GetComponent<SpriteRenderer>();       
        // talkBackGroudImg.color = new Color(0.239f, 0.239f, 0.239f, 0.0f);
        // StartCoroutine(FadeIn(talkBackGroudImg));        
    }

    void Update()
    {

    }

    // 이미지 페이드인 함수 
    IEnumerator FadeIn(SpriteRenderer spriterenderer)
    {
        float fade = 0.0f;
        while (spriterenderer.material.color.a < 1.0f)
        {
            // 페이드인 도중 마우스 및 스페이스바 클릭시 이미지를 그냥 띄운 후 코루틴 종료
            if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space))
            {
                spriterenderer.material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                yield break;
            }
            fade += Time.deltaTime * fadeSpeed;
            spriterenderer.material.color = new Color(1.0f, 1.0f, 1.0f, fade);
            yield return null;
        }
    }

    // 이미지 페이드아웃 함수 
    IEnumerator FadeOut(SpriteRenderer spriterenderer)
    {
        float fade = 1.0f;
        while (spriterenderer.material.color.a > 0.0f)
        {
            fade -= Time.deltaTime * fadeSpeed;
            spriterenderer.material.color = new Color(1.0f, 1.0f, 1.0f, fade);
            yield return null;
        }
    }

}
