using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class FadeInOut : MonoBehaviour
{
    public static FadeInOut instance;

    private void Awake()
    {
        if (FadeInOut.instance == null)
        {
            FadeInOut.instance = this;
        }
    }

    float fadeSpeed = 0.5f;


    // 스프라이트렌더러 페이드인 함수 
    public IEnumerator srFadeIn(SpriteRenderer spriteRenderer)
    {
        StoryManager.instance.coroutineBool = true;

        float fade = 0.0f;

        while (spriteRenderer.material.color.a < 1.0f)
        {
            fade += Time.deltaTime * fadeSpeed;
            spriteRenderer.material.color = new Color(1.0f, 1.0f, 1.0f, fade);
            yield return null;
        }

        StoryManager.instance.coroutineBool = false;
    }

    // 스프라이트 렌더러 페이드아웃 함수 
    public IEnumerator srFadeOut(SpriteRenderer spriteRenderer)
    {
        StoryManager.instance.coroutineBool = true;

        float fade = 1.0f;

        while (spriteRenderer.material.color.a > 0.0f)
        {
            fade -= Time.deltaTime * fadeSpeed;
            spriteRenderer.material.color = new Color(1.0f, 1.0f, 1.0f, fade);
            yield return null;
        }

        StoryManager.instance.coroutineBool = false;
    }

    // 이미지 페이드인 함수
    public IEnumerator imageFadeIn(Image image)
    {
        StoryManager.instance.coroutineBool = true;

        float fade = 0.0f;

        float r = image.color.r;
        float g = image.color.g;
        float b = image.color.b;

        while (image.color.a < 1.0f)
        {
            fade += Time.deltaTime * fadeSpeed;
            image.color = new Color(r, g, b, fade);
            yield return null;
        }

        StoryManager.instance.coroutineBool = false;
    }

    // 이미지 페이드아웃 함수 
    public IEnumerator imageFadeOut(Image image)
    {
        StoryManager.instance.coroutineBool = true;

        float fade = 1.0f;

        float r = image.color.r;
        float g = image.color.g;
        float b = image.color.b;

        while (image.color.a > 0.0f)
        {
            fade -= Time.deltaTime * fadeSpeed;
            image.color = new Color(r, g, b, fade);
            yield return null;
        }

        StoryManager.instance.coroutineBool = false;
    }

    // 텍스트 페이드인 함수
    public IEnumerator textFadeIn(Text text)
    {
        StoryManager.instance.coroutineBool = true;

        float fade = 0.0f;

        float r = text.color.r;
        float g = text.color.g;
        float b = text.color.b;

        while (text.color.a < 1.0f)
        {
            fade += Time.deltaTime * fadeSpeed;
            text.color = new Color(r, g, b, fade);
            yield return null;
        }

        StoryManager.instance.coroutineBool = false;
    }

    // 텍스트 페이드아웃 함수 
    public IEnumerator textFadeOut(Text text)
    {
        StoryManager.instance.coroutineBool = true;

        float fade = 1.0f;

        float r = text.color.r;
        float g = text.color.g;
        float b = text.color.b;

        while (text.color.a > 0.0f)
        {
            fade -= Time.deltaTime * fadeSpeed;
            text.color = new Color(r, g, b, fade);
            yield return null;
        }

        StoryManager.instance.coroutineBool = false;
    }

}
