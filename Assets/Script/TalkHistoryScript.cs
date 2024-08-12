using System.Collections;
using System.Collections.Generic;
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

    void Start()
    {
        talkHis = GameObject.Find("TalkHistory");
        talkHis.SetActive(false);
    }

    void Update()
    {

    }
}
