using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StoryManager : MonoBehaviour, IPointerClickHandler
{
    public static StoryManager instance;

    private int count = 0;
    private int storyCount = 0;

    public bool coroutineBool = false;


    private void Awake()
    {
        if (StoryManager.instance == null)
        {
            StoryManager.instance = this;
        }
    }
    
    void Start()
    {
        OpeningScript.instance.openingScript();
        NoteScript.instance.NotePanel.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (coroutineBool)
            {
                coroutineSkip();
                coroutineBool = false;
            }
            else
            {
                storyProceeding();
                if (Scene1Script.instance.storyEnd == false)
                {
                    count++;
                }                
            }
        }
    }

    public void OnPointerClick(PointerEventData data)
    {
        if (coroutineBool)
        {
            coroutineSkip();
            coroutineBool = false;
        }
        else
        {
            storyProceeding();
            count++;
        }
    }

    void storyProceeding()
    {
        switch (count)
        {
            case 0:
                OpeningScript.instance.openingImageFadeOut();
                NoteButtonScript.instance.noteBtn.gameObject.SetActive(true);
                TalkHistoryButtonScript.Instance.talkHisBtn.gameObject.SetActive(true);
                break;
            case 2:
                PoliceImgScript.instance.policeImageFadeIn();
                break;
            default:
                StoryScript.instance.UpdateScript(storyCount);
                TalkHistoryScript.instance.updateTalkHistory();
                storyCount++;
                break;
        }
    }

    void coroutineSkip()
    {
        switch (count)
        {
            case 0:
                OpeningScript.instance.openingScriptCoroutineSkip();
                break;
            case 1:
                OpeningScript.instance.openingImageFadeOutCoroutineSkip();
                break;
            case 3:
                PoliceImgScript.instance.policeImageFadeInSkip();
                break;
            default:
                StoryScript.instance.scriptCoroutineSkip();
                break;
        }
    }
}
