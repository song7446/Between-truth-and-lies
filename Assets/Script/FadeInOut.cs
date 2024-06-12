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


    // ��������Ʈ������ ���̵��� �Լ� 
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

    // ��������Ʈ ������ ���̵�ƿ� �Լ� 
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

    // �̹��� ���̵��� �Լ�
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

    // �̹��� ���̵�ƿ� �Լ� 
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

    // �ؽ�Ʈ ���̵��� �Լ�
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

    // �ؽ�Ʈ ���̵�ƿ� �Լ� 
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
