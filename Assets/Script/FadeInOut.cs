using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class FadeInOut : MonoBehaviour
{
    // 싱글톤으로 다른 스크립트 불러오기
    public static FadeInOut instance;

    private void Awake()
    {
        if (FadeInOut.instance == null)
        {
            FadeInOut.instance = this;
        }
    }

    // 페이드 인아웃 속도
    float fadeSpeed = 0.5f;


    // 스프라이트렌더러 페이드인 함수 
    public IEnumerator srFadeIn(SpriteRenderer spriteRenderer)
    {
        // 코루틴 중
        StoryManager.instance.coroutineBool = true;

        // 페이드 인이기 때문에 투명한 상태에서 시작 
        float fade = 0.0f;

        // 투명도가 모두 채워질때까지 반복
        while (spriteRenderer.material.color.a < 1.0f)
        {
            // 투명도 속도 조절
            fade += Time.deltaTime * fadeSpeed;
            // 투명도 조절
            spriteRenderer.material.color = new Color(1.0f, 1.0f, 1.0f, fade);

            yield return null;
        }

        // 코루틴 끝
        StoryManager.instance.coroutineBool = false;
    }

    // 스프라이트 렌더러 페이드아웃 함수 
    public IEnumerator srFadeOut(SpriteRenderer spriteRenderer)
    {
        // 코루틴 중
        StoryManager.instance.coroutineBool = true;

        // 페이드 아웃이기 때문에 투명도가 모두 채워진 상태에서 시작
        float fade = 1.0f;

        // 투명해질때까지 반복
        while (spriteRenderer.material.color.a > 0.0f)
        {
            // 투명도 속도 조절
            fade -= Time.deltaTime * fadeSpeed;

            // 투명도 조절
            spriteRenderer.material.color = new Color(1.0f, 1.0f, 1.0f, fade);

            yield return null;
        }

        // 코루틴 끝
        StoryManager.instance.coroutineBool = false;
    }

    // 이미지 페이드인 함수
    public IEnumerator imageFadeIn(Image image)
    {
        // 코루틴 중
        StoryManager.instance.coroutineBool = true;

        // 페이드 인이기 때문에 투명한 상태에서 시작 
        float fade = 0.0f;

        // 이미지의 색 받아오기 
        float r = image.color.r;
        float g = image.color.g;
        float b = image.color.b;

        // 투명도가 모두 채워질때까지 반복
        while (image.color.a < 1.0f)
        {
            // 투명도 속도 조절
            fade += Time.deltaTime * fadeSpeed;

            // 투명도 조절
            image.color = new Color(r, g, b, fade);

            yield return null;
        }

        // 코루틴 끝
        StoryManager.instance.coroutineBool = false;
    }

    // 이미지 페이드아웃 함수 
    public IEnumerator imageFadeOut(Image image)
    {
        // 코루틴 중
        StoryManager.instance.coroutineBool = true;

        // 페이드 아웃이기 때문에 투명도가 모두 채워진 상태에서 시작
        float fade = 1.0f;

        // 이미지의 색 받아오기
        float r = image.color.r;
        float g = image.color.g;
        float b = image.color.b;

        // 투명해질때까지 반복
        while (image.color.a > 0.0f)
        {
            // 투명도 속도 도절
            fade -= Time.deltaTime * fadeSpeed;

            // 투명도 조절
            image.color = new Color(r, g, b, fade);

            yield return null;
        }

        // 코루틴 끝
        StoryManager.instance.coroutineBool = false;
    }

    // 텍스트 페이드인 함수
    public IEnumerator textFadeIn(Text text)
    {
        // 코루틴 중
        StoryManager.instance.coroutineBool = true;

        // 페이드 인이기 때문에 투명한 상태에서 시작 
        float fade = 0.0f;

        // 텍스트 색 받아오기
        float r = text.color.r;
        float g = text.color.g;
        float b = text.color.b;

        // 투명도가 모두 채워질때까지 반복
        while (text.color.a < 1.0f)
        {
            // 투명도 속도 조절
            fade += Time.deltaTime * fadeSpeed;

            // 투명도 조절
            text.color = new Color(r, g, b, fade);

            yield return null;
        }

        // 코루틴 끝
        StoryManager.instance.coroutineBool = false;
    }

    // 텍스트 페이드아웃 함수 
    public IEnumerator textFadeOut(Text text)
    {
        // 코루틴 중
        StoryManager.instance.coroutineBool = true;

        // 페이드 아웃이기 때문에 투명도가 모두 채워진 상태에서 시작
        float fade = 1.0f;

        // 텍스트 색 받아오기
        float r = text.color.r;
        float g = text.color.g;
        float b = text.color.b;

        // 투명해질때까지 반복
        while (text.color.a > 0.0f)
        {
            // 투명도 속도 조절
            fade -= Time.deltaTime * fadeSpeed;

            // 투명도 조절 
            text.color = new Color(r, g, b, fade);

            yield return null;
        }

        // 코루틴 끝
        StoryManager.instance.coroutineBool = false;

        // 다른 곳으로 옮겨야함 
        // 오프닝 이미지 비활성화
        OpeningScript.instance.openingBackGround.SetActive(false);
    }

}
