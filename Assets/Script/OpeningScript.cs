using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class OpeningScript : MonoBehaviour
{
    // �̱������� �ٸ� ��ũ��Ʈ �ҷ�����
    public static OpeningScript instance;
    private void Awake()
    {
        if (OpeningScript.instance == null)
        {
            OpeningScript.instance = this;
        }
    }

    // ������ �ؽ�Ʈ 
    public Text openingTxt;

    // ������ �̹��� 
    public Image obgsp;

    // �ؽ�Ʈ
    private string txt;

    // �ϳ��� ��µǴ� �ӵ� 
    private float delay;

    // ������ ��׶��� ������Ʈ
    public GameObject openingBackGround;

   
    // ������ �Լ�
    public void openingScript()
    {
        // �� �ҷ����� 
        Scene scene = SceneManager.GetActiveScene();

        // �� �̸��� ���� ������ �ؽ�Ʈ ��ȯ 
        switch (scene.name)
        {
            case "Scene#1":
                txt = "Scene #1";
                break;
            case "Scene#2":
                txt = "Scene #2";
                break;
        }

        // �ϳ��� ����ϱ� ������ �ϴ� ���� 
        openingTxt.text = "";

        // �ϳ��� ��µǴ� �ӵ� 
        delay = 0.25f;

        // ������ �ؽ�Ʈ �ѱ��ھ� ��� �ڷ�ƾ
        StartCoroutine(TextPrintScript.instance.TextPrint(delay, txt, openingTxt));
    }

    // ������ �̹��� ���̵� �ƿ� �Լ� 
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
        // ������ �̹��� �ڷ�ƾ ����
        StopCoroutine(FadeInOut.instance.imageFadeOut(obgsp));
        // ������ �ؽ�Ʈ �ڷ�ƾ ���� 
        StopCoroutine(FadeInOut.instance.textFadeOut(openingTxt));

        // ���̵� �ƿ� ��ŵ�̱� ������ �ٷ� ����ȭ 
        obgsp.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        openingTxt.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
    }

    // ������ �ؽ�Ʈ ��ŵ
    public void openingScriptCoroutineSkip()
    {
        // ���� �Ҹ� �ڷ�ƾ ���� ���� 
        //StopCoroutine(TextPrintScript.instance.TextPrint(delay, txt, openingTxt));
        
        // ��� �ڷ�ƾ ���� 
        StopAllCoroutines();

        // �ؽ�Ʈ �ڷ�ƾ �����̱� ������ ��� �ؽ�Ʈ �ֱ�
        openingTxt.text = txt;
    }
}
