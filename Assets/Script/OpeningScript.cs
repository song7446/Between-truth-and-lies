using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class OpeningScript : MonoBehaviour
{
    // 싱글톤으로 다른 스크립트 불러오기
    public static OpeningScript instance;
    private void Awake()
    {
        if (global::OpeningScript.instance == null)
        {
            global::OpeningScript.instance = this;
        }
    }

    // 오프닝 텍스트 
    public Text openingTxt;

    // 오프닝 이미지 
    public Image obgsp;

    // 텍스트
    private string txt;

    // 하나씩 출력되는 속도 
    private float delay;

    // 오프닝 백그라운드 오브젝트
    public GameObject openingBackGround;

   
    // 오프닝 함수
    public void ProceedOpeningScript()
    {
        // 씬 불러오기 
        Scene scene = SceneManager.GetActiveScene();

        // 씬 이름에 따라 오프닝 텍스트 반환 
        switch (scene.name)
        {
            case "Scene#1":
                txt = "Scene #1";
                break;
            case "Scene#2":
                txt = "Scene #2";
                break;
        }

        // 하나씩 출력하기 때문에 일단 비우기 
        openingTxt.text = "";

        // 하나씩 출력되는 속도 
        delay = 0.25f;

        // 오프닝 텍스트 한글자씩 출력 코루틴
        StartCoroutine(TextPrintScript.instance.TextPrint(delay, txt, openingTxt));
    }

    // 오프닝 이미지 페이드 아웃 함수 
    public void OpeningImageFadeOut()
    {
        // 프론트 그라운드 오브젝트
        openingBackGround = GameObject.Find("OpeningFrontGround");
        obgsp = openingBackGround.GetComponent<Image>();

        // 프론트 그라운드 이미지 텍스트 페이드 아웃
        StartCoroutine(FadeInOut.instance.ImageFadeOut(obgsp));
        StartCoroutine(FadeInOut.instance.TextFadeOut(openingTxt));            
    }

    // 오프닝 이미지 페이드아웃 스킵
    public void openingImageFadeOutCoroutineSkip()
    {
        // 오프닝 이미지 코루틴 정지
        StopCoroutine(FadeInOut.instance.ImageFadeOut(obgsp));
        // 오프닝 텍스트 코루틴 정지 
        StopCoroutine(FadeInOut.instance.TextFadeOut(openingTxt));

        // 페이드 아웃 스킵이기 때문에 바로 투명화 
        obgsp.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        openingTxt.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
    }

    // 오프닝 텍스트 스킵
    public void openingScriptCoroutineSkip()
    {
        // 이유 불명 코루틴 정지 실패 
        //StopCoroutine(TextPrintScript.instance.TextPrint(delay, txt, openingTxt));
        
        // 모든 코루틴 정지 
        StopAllCoroutines();

        // 텍스트 코루틴 정지이기 때문에 모든 텍스트 넣기
        openingTxt.text = txt;
    }
}
