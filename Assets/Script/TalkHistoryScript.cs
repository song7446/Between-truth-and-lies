using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class TalkHistoryScript : MonoBehaviour
{
    public static TalkHistoryScript instance;

    private void Awake()
    {
        if (TalkHistoryScript.instance == null)
        {
            TalkHistoryScript.instance = this;

        }
    }

    public bool talkHisBool = false;
    public GameObject talkHis;
    public string talkText;
    public string talkName;

    public GameObject leftRight;
    public GameObject talkLog;
    public GameObject parentObject;

    public Button backBtn;

    void Start()
    {
        talkHis = GameObject.Find("TalkHistory");
        talkHis.SetActive(false);
        parentObject = talkHis.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;

        backBtn.onClick.AddListener(backBtn_onClick);
        backBtn.gameObject.SetActive(false);
    }

    public void updateTalkHistory()
    {
        talkName = StoryScript.instance.speakerName;
        talkText = StoryScript.instance.text;

        if (talkName == "¡÷¿Œ∞¯")
        {
            leftRight = Resources.Load<GameObject>("PreFab/TalkLogRight");
        }
        else
        {
            leftRight = Resources.Load<GameObject>("PreFab/TalkLogLeft");
        }

        talkLog = GameObject.Instantiate<GameObject>(leftRight);      

        talkLog.transform.SetParent(parentObject.transform, false);

        GameObject name = talkLog.transform.GetChild(0).gameObject;
        name.GetComponent<Text>().text = talkName;
        GameObject text = talkLog.transform.GetChild(1).gameObject;
        text.GetComponent<Text>().text = talkText;
    }

    void backBtn_onClick()
    {
        TalkHistoryScript.instance.talkHisBool = false;
        TalkHistoryScript.instance.talkHis.SetActive(false);
        TalkHistoryChapterScript.instance.talkHisCha.SetActive(true);
        backBtn.gameObject.SetActive(false);
    }
}
