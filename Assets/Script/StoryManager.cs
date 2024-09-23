using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StoryManager : MonoBehaviour, IPointerClickHandler
{
    // 싱글톤으로 다른 스크립트 불러오기
    public static StoryManager instance;

    private void Awake()
    {
        if (StoryManager.instance == null)
        {
            StoryManager.instance = this;
        }
    }

    // 기본 카운트 
    private int count = 0;
    
    // 스토리 카운트 
    private int storyCount = 0;

    // 기본과 스토리 카운트로 나눈 이유는 코루틴 중간에 클릭이 가능하기 때문

    // 코루틴 상태 
    public bool coroutineBool = false;

    void Start()
    {
        // 오프닝 스크립트 함수 
        OpeningScript.instance.ProceedOpeningScript();

        // 노트 비활성화 
        NoteScript.instance.NotePanel.gameObject.SetActive(false);
    }

    void Update()
    {
        // UI가 활성화 되어있을 때는 클릭 불가  
        if (TalkHistoryScript.instance.talkHisBool || NoteScript.instance.noteBool || TalkHistoryChapterScript.instance.talkHisChaBool)
        {
            
        }
        // UI가 활성화 되어있지 않을 때 클릭 가능 
        else
        {
            // 스페이키를 입력했을 때 
            if (Input.GetKeyUp(KeyCode.Space))
            {
                // 코루틴이 진행될 때
                if (coroutineBool)
                {
                    // 코루틴 스킵 함수
                    CoroutineSkip();

                    // 코루틴 비활성화로 상태 변경 
                    coroutineBool = false;
                }

                // 코루틴이 진행되지 않을 때 스토리 진행 
                else
                {
                    // 스토리가 끝나지 않으면 스토리 진행 
                    if (Scene1Script.instance.storyEnd == false)
                    {
                        // 스토리 진행 함수 
                        StoryProceeding();

                        // 기본 카운트 증가 
                        count++;
                    }
                }
            }
        }
    }

    // UI나 버튼이 아닌 배경 클릭 함수  
    public void OnPointerClick(PointerEventData data)
    {
        // 코루틴이 진행될 때 
        if (coroutineBool)
        {
            // 코루틴 스킵 함수
            CoroutineSkip();

            // 코루틴 비활성화로 상태 변경 
            coroutineBool = false;
        }

        // 코루틴이 진행되지 않을 때 스토리 진행 
        else
        {
            // 스토리가 끝나지 않으면 스토리 진행 
            if (Scene1Script.instance.storyEnd == false)
            {
                // 스토리 진행 함수 
                StoryProceeding();

                // 기본 카운트 증가 
                count++;
            }
        }
    }

    // 스토리 진행 함수 
    void StoryProceeding()
    {
        // 기본 카운트 숫자에 따라 진행 
        switch (count)
        {
            // 0은 오프닝 
            case 0:
                // 오프닝 이미지 페이드 아웃 함수 호출
                OpeningScript.instance.OpeningImageFadeOut();

                // 노트 버튼 활성화 
                NoteButtonScript.instance.noteBtn.gameObject.SetActive(true);

                // 대화 기록 버튼 활성화 
                TalkHistoryButtonScript.Instance.talkHisBtn.gameObject.SetActive(true);
                break;

            // 2는 형사 이미지 페이드인 
            case 2:
                // 형사 이미지 페이드인 함수 호출
                PoliceImgScript.instance.PoliceImageFadeIn();

                break;

            // 기본은 스토리 진행 
            default:             
                // 스토리 텍스트 업데이트 함수 호출 
                StoryScript.instance.UpdateScript(storyCount);

                // 스토리 텍스트 진행에 따라 대화기록 함수도 호출 
                TalkHistoryScript.instance.UpdateTalkHistory(storyCount);

                // 스토리가 진행되면 스토리 카운트 증가 
                storyCount++;

                break;
        }
    }

    // 코루틴 스킵 함수 
    void CoroutineSkip()
    {
        // 기본 카운트 숫자에 따라 진행 
        switch (count)
        {
            // 0은 오프닝 텍스트 출력 스킵 
            case 0:
                // 오프닝 텍스트 코루틴 스킵 함수 호출 
                OpeningScript.instance.openingScriptCoroutineSkip();

                break;

            // 1은 오프닝 이미지 페이드아웃 스킵
            case 1:
                // 오프닝 이미지 코루틴 스킵 함수 호출 
                OpeningScript.instance.openingImageFadeOutCoroutineSkip();

                break;

            // 3은 형사 이미지 페이드인 스킵 
            case 3:
                // 형사 이미지 페이드인 코루틴 스킵 함수 호출
                PoliceImgScript.instance.PoliceImageFadeInSkip();

                break;

            // 기본은 스토리 텍스트 출력 스킵 
            default:
                // 스토리 텍스트 출력 코루틴 스킵 함수 호출 
                StoryScript.instance.ScriptCoroutineSkip();

                break;
        }
    }
}
