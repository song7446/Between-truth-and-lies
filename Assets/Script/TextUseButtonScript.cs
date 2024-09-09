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
    int count = 1;

    public bool falseTextUseBool;
    public bool tooManyTextUseBool;

    void Start()
    {
        textUseBtn.onClick.AddListener(textUseBtn_onClick);
        textUnUseBtn.onClick.AddListener(textUnUseBtn_onClick);
        textUseBtn.gameObject.SetActive(false);
        textUnUseBtn.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (StoryManager.instance.coroutineBool==false)
        {
            FalseTextUseScript.instance.falTxtObj.SetActive(false);
            FalseTextUseScript.instance.falTxtObj.GetComponent<Text>().color = new Color(255,0,0,255);

            TooManyTextUseScript.instance.tooManyTextUseObj.SetActive(false);
            TooManyTextUseScript.instance.tooManyTextUseObj.GetComponent<Text>().color = new Color(255, 0, 0, 255);

            AnswerResultScript.instance.worObj.SetActive(false);
            AnswerResultScript.instance.worObj.GetComponent<Text>().color = new Color(255, 0, 0, 255);
        }
    }

    void textUseBtn_onClick()
    {
        Debug.Log("텍스트 사용 버튼 클릭");        
        talkName = talkObj.transform.GetChild(0).gameObject.GetComponent<Text>();
        Debug.Log(talkName.text);
        talkText = talkObj.transform.GetChild(1).gameObject.GetComponent<Text>();
        Debug.Log(talkText.text);

        if (count < 5)
        {
            if (NoteTextObjScript.instance.updateNoteText(talkObj))
            {
                talkName.color = Color.red;
                talkText.color = Color.red;
                count++;
            }
            else
            {
                Vector2 mousePosition = Input.mousePosition;
                FalseTextUseScript.instance.falTxtObj.transform.position = mousePosition;
                FalseTextUseScript.instance.falTxtObj.SetActive(true);
                StartCoroutine(FadeInOut.instance.textFadeOut(FalseTextUseScript.instance.falTxtObj.GetComponent<Text>()));
            }
        }
        else
        {
            Vector2 mousePosition = Input.mousePosition;
            TooManyTextUseScript.instance.tooManyTextUseObj.transform.position = mousePosition;
            TooManyTextUseScript.instance.tooManyTextUseObj.SetActive(true);
            StartCoroutine(FadeInOut.instance.textFadeOut(TooManyTextUseScript.instance.tooManyTextUseObj.GetComponent<Text>()));
        }

        
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

        NoteTextObjScript.instance.deleteNoteText(talkObj);
        count--;
    }
}
