using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class FadeInOut : MonoBehaviour
{
    float fadeSpeed = 0.5f;
    public bool fadeInOnStart = true;
    public bool fadeOutOnExit = true;

    GameObject policeImg;
    GameObject talkBackGround;

    SpriteRenderer policeImgSr;
    SpriteRenderer talkBackGroudImg;

    int count = 0;

    void Start()
    {
        policeImg = GameObject.Find("PoliceImg");
        // talkBackGround = GameObject.Find("TalkBackGround");

        policeImgSr = policeImg.GetComponent<SpriteRenderer>();
        // talkBackGroudImg = talkBackGround.GetComponent<SpriteRenderer>();

        policeImgSr.material.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        // talkBackGroudImg.color = new Color(0.239f, 0.239f, 0.239f, 0.0f);

    }

    void Update()
    {
        if (fadeInOnStart && count == 0)
        {
            if (Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.Space))
            {
                StartCoroutine(FadeIn(policeImgSr));
                // StartCoroutine(FadeIn(talkBackGroudImg));
                count++;
            }
        }
    }

    IEnumerator FadeIn(SpriteRenderer spriterenderer)
    {
        float fade = 0.0f;
        while (spriterenderer.material.color.a < 1.0f)
        {
            fade += Time.deltaTime * fadeSpeed;
            spriterenderer.material.color = new Color(1.0f, 1.0f, 1.0f, fade);
            yield return null;
        }
    }

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
