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

    void Start()
    {
        talkHis = GameObject.Find("TalkHistory");
        talkHis.SetActive(false);
        //parentObject = GameObject.Find("Content");
    }

    void Update()
    {

    }

    public void updateTalkHistory()
    {
        talkName = StoryScript.instance.speakerName;
        talkText = StoryScript.instance.text;

        if (talkName == "¡÷¿Œ∞¯")
        {
            leftRight = Resources.Load("TalkLogRight") as GameObject;
        }
        else
        {
            leftRight = Resources.Load("TalkLogLeft") as GameObject;
        }
        talkLog = PrefabUtility.InstantiatePrefab(leftRight) as GameObject;
        talkLog.transform.SetParent(parentObject.transform, false);
    }
}
