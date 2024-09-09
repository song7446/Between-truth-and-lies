using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class OpeningScript : MonoBehaviour
{
    public static OpeningScript instance;

    public Text openingTxt;

    public Image obgsp;

    private string txt;
    private float delay;

    public GameObject openingBackGround;

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
        openingBackGround = GameObject.Find("OpeningFrontGround");
        obgsp = openingBackGround.GetComponent<Image>();

        // 프론트 그라운드 이미지 텍스트 페이드 아웃
        StartCoroutine(FadeInOut.instance.imageFadeOut(obgsp));
        StartCoroutine(FadeInOut.instance.textFadeOut(openingTxt));            
    }

    // 오프닝 이미지 페이드아웃 스킵
    public void openingImageFadeOutCoroutineSkip()
    {
        StopCoroutine(FadeInOut.instance.imageFadeOut(obgsp));
        StopCoroutine(FadeInOut.instance.textFadeOut(openingTxt));
        obgsp.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        openingTxt.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
    }

    // 오프닝 텍스트 스킵
    public void openingScriptCoroutineSkip()
    {
        // 이유 불명 코루틴 정지 실패 
        //StopCoroutine(TextPrintScript.instance.TextPrint(delay, txt, openingTxt));
        StopAllCoroutines();
        openingTxt.text = txt;
    }
}
