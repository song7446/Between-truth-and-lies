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
        // ����Ʈ �׶��� ������Ʈ
        GameObject openingBackGround = GameObject.Find("FrontGround");
        obgsp = openingBackGround.GetComponent<Image>();

        // ����Ʈ �׶��� �̹��� �ؽ�Ʈ ���̵� �ƿ�
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
