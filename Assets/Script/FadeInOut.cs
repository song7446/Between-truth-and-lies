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

    // ��������Ʈ������ ���̵��� �Լ� 
    public IEnumerator srFadeIn(SpriteRenderer spriteRenderer)
    {
        float fade = 0.0f;       
        while (spriteRenderer.material.color.a < 1.0f)
        {
            // ���̵��� ���� ���콺 �� �����̽��� Ŭ���� �̹����� �׳� ��� �� �ڷ�ƾ ����
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

    // ��������Ʈ ������ ���̵�ƿ� �Լ� 
    public IEnumerator srFadeOut(SpriteRenderer spriteRenderer)
    {
        float fade = 1.0f;
        while (spriteRenderer.material.color.a > 0.0f)
        {
            // ���̵��� ���� ���콺 �� �����̽��� Ŭ���� �̹����� �׳� ��� �� �ڷ�ƾ ����
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

    // �̹��� ���̵��� �Լ�
    public IEnumerator imageFadeIn(Image image)
    {
        float fade = 0.0f;

        float r = image.color.r;
        float g = image.color.g;
        float b = image.color.b;

        while (image.color.a < 1.0f)
        {
            // ���̵��� ���� ���콺 �� �����̽��� Ŭ���� �̹����� �׳� ��� �� �ڷ�ƾ ����
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

    // �̹��� ���̵�ƿ� �Լ� 
    public IEnumerator imageFadeOut(Image image)
    {
        float fade = 1.0f;

        float r = image.color.r;       
        float g = image.color.g;       
        float b = image.color.b; 
        
        while (image.color.a > 0.0f)
        {
            // ���̵��� ���� ���콺 �� �����̽��� Ŭ���� �̹����� �׳� ��� �� �ڷ�ƾ ����
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

    // �ؽ�Ʈ ���̵��� �Լ�
    public IEnumerator textFadeIn(Text text)
    {
        float fade = 0.0f;

        float r = text.color.r;
        float g = text.color.g;
        float b = text.color.b;

        while (text.color.a < 1.0f)
        {
            // ���̵��� ���� ���콺 �� �����̽��� Ŭ���� �̹����� �׳� ��� �� �ڷ�ƾ ����
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

    // �ؽ�Ʈ ���̵�ƿ� �Լ� 
    public IEnumerator textFadeOut(Text text)
    {
        float fade = 1.0f;

        float r = text.color.r;
        float g = text.color.g;
        float b = text.color.b;

        while (text.color.a > 0.0f)
        {
            // ���̵��� ���� ���콺 �� �����̽��� Ŭ���� �̹����� �׳� ��� �� �ڷ�ƾ ����
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
