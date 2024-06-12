using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class OpeningScript : MonoBehaviour
{
    public static OpeningScript instance;

    public Text openingTxt;

    Image obgsp;

    private string txt;
    private float delay;

    private void Awake()
    {
        if(OpeningScript.instance == null)
        {
            OpeningScript.instance = this;
        }
    }

    public void openingScript()
    {
        openingTxt.text = "";

        txt = "Scene #1";
        delay = 0.25f;

        StartCoroutine(TextPrintScript.instance.TextPrint(delay, txt, openingTxt));
    }

    public void openingImageFadeOut()
    {
        // 프론트 그라운드 오브젝트
        GameObject openingBackGround = GameObject.Find("FrontGround");
        obgsp = openingBackGround.GetComponent<Image>();

        // 프론트 그라운드 이미지 텍스트 페이드 아웃
        StartCoroutine(FadeInOut.instance.imageFadeOut(obgsp));
        StartCoroutine(FadeInOut.instance.textFadeOut(openingTxt));
    }

    public void openingImageFadeOutCoroutineSkip()
    {
        StopAllCoroutines();
        obgsp.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        openingTxt.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
    }
}
