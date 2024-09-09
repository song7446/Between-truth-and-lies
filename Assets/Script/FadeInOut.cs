using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class FadeInOut : MonoBehaviour
{
    // �̱������� �ٸ� ��ũ��Ʈ �ҷ�����
    public static FadeInOut instance;

    private void Awake()
    {
        if (FadeInOut.instance == null)
        {
            FadeInOut.instance = this;
        }
    }

    // ���̵� �ξƿ� �ӵ�
    float fadeSpeed = 0.5f;


    // ��������Ʈ������ ���̵��� �Լ� 
    public IEnumerator srFadeIn(SpriteRenderer spriteRenderer)
    {
        // �ڷ�ƾ ��
        StoryManager.instance.coroutineBool = true;

        // ���̵� ���̱� ������ ������ ���¿��� ���� 
        float fade = 0.0f;

        // ������ ��� ä���������� �ݺ�
        while (spriteRenderer.material.color.a < 1.0f)
        {
            // ���� �ӵ� ����
            fade += Time.deltaTime * fadeSpeed;
            // ���� ����
            spriteRenderer.material.color = new Color(1.0f, 1.0f, 1.0f, fade);

            yield return null;
        }

        // �ڷ�ƾ ��
        StoryManager.instance.coroutineBool = false;
    }

    // ��������Ʈ ������ ���̵�ƿ� �Լ� 
    public IEnumerator srFadeOut(SpriteRenderer spriteRenderer)
    {
        // �ڷ�ƾ ��
        StoryManager.instance.coroutineBool = true;

        // ���̵� �ƿ��̱� ������ ������ ��� ä���� ���¿��� ����
        float fade = 1.0f;

        // �������������� �ݺ�
        while (spriteRenderer.material.color.a > 0.0f)
        {
            // ���� �ӵ� ����
            fade -= Time.deltaTime * fadeSpeed;

            // ���� ����
            spriteRenderer.material.color = new Color(1.0f, 1.0f, 1.0f, fade);

            yield return null;
        }

        // �ڷ�ƾ ��
        StoryManager.instance.coroutineBool = false;
    }

    // �̹��� ���̵��� �Լ�
    public IEnumerator imageFadeIn(Image image)
    {
        // �ڷ�ƾ ��
        StoryManager.instance.coroutineBool = true;

        // ���̵� ���̱� ������ ������ ���¿��� ���� 
        float fade = 0.0f;

        // �̹����� �� �޾ƿ��� 
        float r = image.color.r;
        float g = image.color.g;
        float b = image.color.b;

        // ������ ��� ä���������� �ݺ�
        while (image.color.a < 1.0f)
        {
            // ���� �ӵ� ����
            fade += Time.deltaTime * fadeSpeed;

            // ���� ����
            image.color = new Color(r, g, b, fade);

            yield return null;
        }

        // �ڷ�ƾ ��
        StoryManager.instance.coroutineBool = false;
    }

    // �̹��� ���̵�ƿ� �Լ� 
    public IEnumerator imageFadeOut(Image image)
    {
        // �ڷ�ƾ ��
        StoryManager.instance.coroutineBool = true;

        // ���̵� �ƿ��̱� ������ ������ ��� ä���� ���¿��� ����
        float fade = 1.0f;

        // �̹����� �� �޾ƿ���
        float r = image.color.r;
        float g = image.color.g;
        float b = image.color.b;

        // �������������� �ݺ�
        while (image.color.a > 0.0f)
        {
            // ���� �ӵ� ����
            fade -= Time.deltaTime * fadeSpeed;

            // ���� ����
            image.color = new Color(r, g, b, fade);

            yield return null;
        }

        // �ڷ�ƾ ��
        StoryManager.instance.coroutineBool = false;
    }

    // �ؽ�Ʈ ���̵��� �Լ�
    public IEnumerator textFadeIn(Text text)
    {
        // �ڷ�ƾ ��
        StoryManager.instance.coroutineBool = true;

        // ���̵� ���̱� ������ ������ ���¿��� ���� 
        float fade = 0.0f;

        // �ؽ�Ʈ �� �޾ƿ���
        float r = text.color.r;
        float g = text.color.g;
        float b = text.color.b;

        // ������ ��� ä���������� �ݺ�
        while (text.color.a < 1.0f)
        {
            // ���� �ӵ� ����
            fade += Time.deltaTime * fadeSpeed;

            // ���� ����
            text.color = new Color(r, g, b, fade);

            yield return null;
        }

        // �ڷ�ƾ ��
        StoryManager.instance.coroutineBool = false;
    }

    // �ؽ�Ʈ ���̵�ƿ� �Լ� 
    public IEnumerator textFadeOut(Text text)
    {
        // �ڷ�ƾ ��
        StoryManager.instance.coroutineBool = true;

        // ���̵� �ƿ��̱� ������ ������ ��� ä���� ���¿��� ����
        float fade = 1.0f;

        // �ؽ�Ʈ �� �޾ƿ���
        float r = text.color.r;
        float g = text.color.g;
        float b = text.color.b;

        // �������������� �ݺ�
        while (text.color.a > 0.0f)
        {
            // ���� �ӵ� ����
            fade -= Time.deltaTime * fadeSpeed;

            // ���� ���� 
            text.color = new Color(r, g, b, fade);

            yield return null;
        }

        // �ڷ�ƾ ��
        StoryManager.instance.coroutineBool = false;

        // �ٸ� ������ �Űܾ��� 
        // ������ �̹��� ��Ȱ��ȭ
        OpeningScript.instance.openingBackGround.SetActive(false);
    }

}
