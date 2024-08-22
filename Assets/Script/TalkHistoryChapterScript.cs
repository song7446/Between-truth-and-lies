using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkHistoryChapterScript : MonoBehaviour
{
    public static TalkHistoryChapterScript instance;
    private void Awake()
    {
        if (TalkHistoryChapterScript.instance == null)
        {
            TalkHistoryChapterScript.instance = this;

        }
    }

    public Button talkHisChaBtn1;
    public Button talkHisChaBtn2;
    public Button talkHisChaBtn3;
    public Button talkHisChaBtn4;

    public GameObject talkHisCha;
    public bool talkHisChaBool = false;

    void Start()
    {
        talkHisChaBtn1.onClick.AddListener(talkHisChaBtn1_onClick);
        talkHisChaBtn2.onClick.AddListener(talkHisChaBtn2_onClick);

        talkHisCha = GameObject.Find("TalkHistoryChapter");
        talkHisCha.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void talkHisChaBtn1_onClick()
    {
        Debug.Log("1번 버튼 클릭");

        TalkHistoryScript.instance.talkHisBool = true;
        TalkHistoryScript.instance.talkHis.SetActive(true);
        TalkHistoryScript.instance.backBtn.gameObject.SetActive(true);
        talkHisCha.SetActive(false);
    }
    void talkHisChaBtn2_onClick()
    {
        Debug.Log("2번 버튼 클릭");
    }
}
