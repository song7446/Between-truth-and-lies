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

    public bool fadeInOutBool = false;

    // ��������Ʈ������ ���̵��� �Լ� 
    public IEnumerator srFadeIn(SpriteRenderer spriteRenderer)
    {
        fadeInOutBool = true;

        float fade = 0.0f;

        while (spriteRenderer.material.color.a < 1.0f)
        {
            fade += Time.deltaTime * fadeSpeed;
            spriteRenderer.material.color = new Color(1.0f, 1.0f, 1.0f, fade);
            yield return null;
        }

        fadeInOutBool = false;
    }

    // ��������Ʈ ������ ���̵�ƿ� �Լ� 
    public IEnumerator srFadeOut(SpriteRenderer spriteRenderer)
    {
        fadeInOutBool = true;

        float fade = 1.0f;

        while (spriteRenderer.material.color.a > 0.0f)
        {
            fade -= Time.deltaTime * fadeSpeed;
            spriteRenderer.material.color = new Color(1.0f, 1.0f, 1.0f, fade);
            yield return null;
        }

        fadeInOutBool = false;
    }

    // �̹��� ���̵��� �Լ�
    public IEnumerator imageFadeIn(Image image)
    {
        fadeInOutBool = true;

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

        fadeInOutBool = false;
    }

    // �̹��� ���̵�ƿ� �Լ� 
    public IEnumerator imageFadeOut(Image image)
    {
        fadeInOutBool = true;

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

        fadeInOutBool = false;
    }

    // �ؽ�Ʈ ���̵��� �Լ�
    public IEnumerator textFadeIn(Text text)
    {
        fadeInOutBool = true;

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

        fadeInOutBool = false;
    }

    // �ؽ�Ʈ ���̵�ƿ� �Լ� 
    public IEnumerator textFadeOut(Text text)
    {
        fadeInOutBool = true;

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

        fadeInOutBool = false;
    }

}
