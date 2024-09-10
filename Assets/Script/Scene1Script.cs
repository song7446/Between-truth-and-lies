using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scene1Script : MonoBehaviour
{
    public static Scene1Script instance;
    public bool storyEnd = false;
    private void Awake()
    {
        if (Scene1Script.instance == null)
        {
            Scene1Script.instance = this;

        }
    }


    // 씬#1 스토리 스크립트
    public string ScriptCollection(int num)
    {
        string scriptText = "";


        string[] storyScript = {"이곳인가?", "오셨습니까 선배님", "그래 무슨 일인지 설명해 봐.", "복잡한 사건은 아닙니다.", "이 집에 살던 딸이 아버지를 살해했습니다.", "신고는 누가 했지?", "그게 딸 본인이 했습니다.",
                                "아버지를 살해하고 바로 자수한건가...", "지금까지 조사해본 바로는", "사망 추정시각 전부터 지금까지 현장에 있던 사람이 피해자와 용의자 둘뿐이고", "침입의 흔적도 없는데다가",
                                "흉기에서 딸의 지문까지 나온 상태입니다.","그럼 대충 끝난 것 아닌가?","왜 이렇게 어수선 하지?" ,"그게...", "왜 무슨 특이한 점이 있었나?", "용의자가 말하기로는",
                                "자신이 살해한 것도 맞고 자수하는 것도 맞다고 하는데", "구체적으로 얘기 해주지를 않습니다.", "그냥 자신이 한 것이라는 것 외에는 아무 얘기도 안합니다.","음..." ,"무언가를 숨기고 있군.",
                                "그리고 또...","뭔데?" , "신고 시간과 사망 추청 시간이 좀 차이가 납니다.","증거도 나왔다며" , "그정도는 별일 아닐 수도 있는 것 아닌가" ,
                                "그럴수도 있지만 용의자가 무슨 얘기를 해주지를 않아서 알 수가 없습니다", "음..." , "살해 동기도 얘기해주지 않았지?" , "그렇긴 한데 정황상 성폭행으로 보입니다." ,
                                "..." , "둘이 부녀관계라고 하지 않았나?" , "맞습니다.", "젠장...", "벌써부터 골치 아프군..." };
        try
        {
            scriptText = storyScript[num];
        }
        catch (IndexOutOfRangeException)
        {
            if (CombinationButtonScript.Instance.ansCheckBool)
            {
                OpeningScript.instance.openingTxt.text = "";
                OpeningScript.instance.obgsp.color = new Color(0,0,0,0);
                OpeningScript.instance.openingBackGround.SetActive(true);
                StartCoroutine(FadeInOut.instance.imageFadeIn(OpeningScript.instance.obgsp));
                Invoke("nextSceneLoad", 10);
            }
            else
            {
                EndingScript.instance.endFrontGround.SetActive(true);
                StartCoroutine(FadeInOut.instance.imageFadeIn(EndingScript.instance.endFrontGround.GetComponent<Image>()));
                StartCoroutine(FadeInOut.instance.textFadeIn(EndingScript.instance.endingText));
            }
            storyEnd = true;
        }

        return scriptText;
    }

    // 씬#1 화자 이름 스크립트
    public string NameCollection(int num)
    {
        string name = "";
        string[] nameScript = { "주인공", "후배 형사", "주인공", "후배 형사", "후배 형사", "주인공", "후배 형사",
                                "주인공","후배 형사", "후배 형사","후배 형사",
                                "후배 형사","주인공","주인공", "후배 형사","주인공" ,"후배형사",
                                "후배 형사","후배 형사","후배 형사","주인공","주인공",
                                "후배 형사", "주인공","후배 형사","주인공","주인공",
                                "후배 형사","주인공","주인공","후배 형사",
                                "주인공", "주인공","후배 형사","주인공","주인공"};
        try
        {
            name = nameScript[num];
        }
        catch (IndexOutOfRangeException)
        {
            storyEnd = true;
        }

        return name;
    }

    public void nextSceneLoad()
    {
        SceneManager.LoadScene("Scene#2");
    }
}

