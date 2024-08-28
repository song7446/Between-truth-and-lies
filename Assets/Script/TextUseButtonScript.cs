using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUseButtonScript : MonoBehaviour
{
    public static TextUseButtonScript instance;

    private void Awake()
    {
        if (TextUseButtonScript.instance == null)
        {
            TextUseButtonScript.instance = this;

        }
    }

    public GameObject textUseBtnObj;
    public Button textUseBtn;
    public Button textUnUseBtn;
    public Text talkName;
    public Text talkText;
    public GameObject talkObj;

    void Start()
    {
        textUseBtn.onClick.AddListener(textUseBtn_onClick);
        textUnUseBtn.onClick.AddListener(textUnUseBtn_onClick);
        textUseBtn.gameObject.SetActive(false);
        textUnUseBtn.gameObject.SetActive(false);
    }

    void textUseBtn_onClick()
    {
        Debug.Log("텍스트 사용 버튼 클릭");
        talkName = talkObj.transform.GetChild(0).gameObject.GetComponent<Text>();
        Debug.Log(talkName.text);
        talkText = talkObj.transform.GetChild(1).gameObject.GetComponent<Text>();
        Debug.Log(talkText.text);

        talkName.color = Color.red;
        talkText.color = Color.red;
        
        textUseBtn.gameObject.SetActive(false);
        textUnUseBtn.gameObject.SetActive(false);
    }

    public void getTalkObj(GameObject Obj)
    {
        talkObj = Obj;
    }

    void textUnUseBtn_onClick()
    {
        Debug.Log("텍스트 사용 취소 버튼 클릭");

        talkName = talkObj.transform.GetChild(0).gameObject.GetComponent<Text>();
        Debug.Log(talkName.text);
        talkText = talkObj.transform.GetChild(1).gameObject.GetComponent<Text>();
        Debug.Log(talkText.text);

        talkName.color = Color.white;
        talkText.color = Color.white;

        textUseBtn.gameObject.SetActive(false);
        textUnUseBtn.gameObject.SetActive(false);
    }
}
