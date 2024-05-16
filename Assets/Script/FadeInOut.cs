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
        // ���� �̹��� ������Ʈ �ҷ����� 
        policeImg = GameObject.Find("PoliceImg");

        // ���� �̹��� ������Ʈ�� ��������Ʈ������ �ҷ�����
        policeImgSr = policeImg.GetComponent<SpriteRenderer>();

        // ���� �̹��� ������Ʈ ����ȭ 
        policeImgSr.material.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);

        // �� #1 ������ �� ���� �̹��� ���̵���
        StartCoroutine(FadeIn(policeImgSr));

        // ���� �̹��� ���� 
        policeImgOn = true;


        // talkBackGround = GameObject.Find("TalkBackGround");
        // talkBackGroudImg = talkBackGround.GetComponent<SpriteRenderer>();       
        // talkBackGroudImg.color = new Color(0.239f, 0.239f, 0.239f, 0.0f);
        // StartCoroutine(FadeIn(talkBackGroudImg));        
    }

    void Update()
    {

    }

    // �̹��� ���̵��� �Լ� 
    IEnumerator FadeIn(SpriteRenderer spriterenderer)
    {
        float fade = 0.0f;
        while (spriterenderer.material.color.a < 1.0f)
        {
            // ���̵��� ���� ���콺 �� �����̽��� Ŭ���� �̹����� �׳� ��� �� �ڷ�ƾ ����
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

    // �̹��� ���̵�ƿ� �Լ� 
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
