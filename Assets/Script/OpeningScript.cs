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
        // ����Ʈ �׶��� ������Ʈ
        openingBackGround = GameObject.Find("OpeningFrontGround");
        obgsp = openingBackGround.GetComponent<Image>();

        // ����Ʈ �׶��� �̹��� �ؽ�Ʈ ���̵� �ƿ�
        StartCoroutine(FadeInOut.instance.imageFadeOut(obgsp));
        StartCoroutine(FadeInOut.instance.textFadeOut(openingTxt));            
    }

    // ������ �̹��� ���̵�ƿ� ��ŵ
    public void openingImageFadeOutCoroutineSkip()
    {
        StopCoroutine(FadeInOut.instance.imageFadeOut(obgsp));
        StopCoroutine(FadeInOut.instance.textFadeOut(openingTxt));
        obgsp.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        openingTxt.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
    }

    // ������ �ؽ�Ʈ ��ŵ
    public void openingScriptCoroutineSkip()
    {
        // ���� �Ҹ� �ڷ�ƾ ���� ���� 
        //StopCoroutine(TextPrintScript.instance.TextPrint(delay, txt, openingTxt));
        StopAllCoroutines();
        openingTxt.text = txt;
    }
}
