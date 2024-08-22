using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TalkHistoryButtonScript : MonoBehaviour
{
    public Button talkHisBtn;

    void Start()
    {
        talkHisBtn.onClick.AddListener(talkHisBtn_onClick);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void talkHisBtn_onClick()
    {
        if (TalkHistoryChapterScript.instance.talkHisChaBool || TalkHistoryScript.instance.talkHisBool)
        {
            TalkHistoryChapterScript.instance.talkHisCha.SetActive(false);
            TalkHistoryChapterScript.instance.talkHisChaBool = false;

            TalkHistoryScript.instance.talkHis.SetActive(false);
            TalkHistoryScript.instance.talkHisBool = false;
            TalkHistoryScript.instance.backBtn.gameObject.SetActive(false);
        }
        else
        {
            TalkHistoryChapterScript.instance.talkHisCha.SetActive(true);
            TalkHistoryChapterScript.instance.talkHisChaBool = true;
        }
        Debug.Log("대화 기록 버튼 클릭");
    }
}
