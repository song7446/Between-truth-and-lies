using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class FadeInOut : MonoBehaviour
{
    public static FadeInOut instance;

    private void Awake()
    {
        if(FadeInOut.instance == null)
        {
            FadeInOut.instance = this;
        }
    }

    float fadeSpeed = 0.5f;

    // 스프라이트렌더러 페이드인 함수 
    public IEnumerator srFadeIn(SpriteRenderer spriteRenderer)
    {
        float fade = 0.0f;       
        while (spriteRenderer.material.color.a < 1.0f)
        {
            // 페이드인 도중 마우스 및 스페이스바 클릭시 이미지를 그냥 띄운 후 코루틴 종료
            if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space))
            {
                spriteRenderer.material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                yield break;
            }
            fade += Time.deltaTime * fadeSpeed;
            spriteRenderer.material.color = new Color(1.0f, 1.0f, 1.0f, fade);
            yield return null;
        }
    }

    // 스프라이트 렌더러 페이드아웃 함수 
    public IEnumerator srFadeOut(SpriteRenderer spriteRenderer)
    {
        float fade = 1.0f;
        while (spriteRenderer.material.color.a > 0.0f)
        {
            // 페이드인 도중 마우스 및 스페이스바 클릭시 이미지를 그냥 띄운 후 코루틴 종료
            if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space))
            {
                spriteRenderer.material.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
                yield break;
            }
            fade -= Time.deltaTime * fadeSpeed;
            spriteRenderer.material.color = new Color(1.0f, 1.0f, 1.0f, fade);
            yield return null;
        }
    }

    // 이미지 페이드인 함수
    public IEnumerator imageFadeIn(Image image)
    {
        float fade = 0.0f;

        float r = image.color.r;
        float g = image.color.g;
        float b = image.color.b;

        while (image.color.a < 1.0f)
        {
            // 페이드인 도중 마우스 및 스페이스바 클릭시 이미지를 그냥 띄운 후 코루틴 종료
            if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space))
            {
                image.color = new Color(r, g, b, 1.0f);
                yield break;
            }
            fade += Time.deltaTime * fadeSpeed;
            image.color = new Color(r, g, b, fade);
            yield return null;
        }
    }

    // 이미지 페이드아웃 함수 
    public IEnumerator imageFadeOut(Image image)
    {
        float fade = 1.0f;

        float r = image.color.r;       
        float g = image.color.g;       
        float b = image.color.b; 
        
        while (image.color.a > 0.0f)
        {
            // 페이드인 도중 마우스 및 스페이스바 클릭시 이미지를 그냥 띄운 후 코루틴 종료
            if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space))
            {
                image.color = new Color(r, g, b, 0.0f);
                yield break;
            }
            fade -= Time.deltaTime * fadeSpeed;
            image.color = new Color(r, g, b, fade);
            yield return null;
        }
    }

    // 텍스트 페이드인 함수
    public IEnumerator textFadeIn(Text text)
    {
        float fade = 0.0f;

        float r = text.color.r;
        float g = text.color.g;
        float b = text.color.b;

        while (text.color.a < 1.0f)
        {
            // 페이드인 도중 마우스 및 스페이스바 클릭시 이미지를 그냥 띄운 후 코루틴 종료
            if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space))
            {
                text.color = new Color(r, g, b, 1.0f);
                yield break;
            }
            fade += Time.deltaTime * fadeSpeed;
            text.color = new Color(r, g, b, fade);
            yield return null;
        }
    }

    // 텍스트 페이드아웃 함수 
    public IEnumerator textFadeOut(Text text)
    {
        float fade = 1.0f;

        float r = text.color.r;
        float g = text.color.g;
        float b = text.color.b;

        while (text.color.a > 0.0f)
        {
            // 페이드인 도중 마우스 및 스페이스바 클릭시 이미지를 그냥 띄운 후 코루틴 종료
            if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space))
            {
                text.color = new Color(r, g, b, 0.0f);
                yield break;
            }
            fade -= Time.deltaTime * fadeSpeed;
            text.color = new Color(r, g, b, fade);
            yield return null;
        }
    }

}
