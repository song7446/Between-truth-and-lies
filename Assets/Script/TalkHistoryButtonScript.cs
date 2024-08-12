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
        if (TalkHistoryScript.instance.talkHisBool)
        {
            TalkHistoryScript.instance.talkHisBool = false;
            TalkHistoryScript.instance.talkHis.SetActive(false);
        }
        else
        {
            TalkHistoryScript.instance.talkHisBool = true;
            TalkHistoryScript.instance.talkHis.SetActive(true);
        }
        Debug.Log("대화 기록 버튼 클릭");
    }
}
