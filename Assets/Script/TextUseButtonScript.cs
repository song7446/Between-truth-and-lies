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

    public Button textUseBtn;
    public Text talkName;
    public Text talkText;
    public GameObject talkObj;

    void Start()
    {
        textUseBtn.onClick.AddListener(textUseBtn_onClick);
        textUseBtn.gameObject.SetActive(false);
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
    }

    public void getTalkObj(GameObject Obj)
    {
        talkObj = Obj;
    }
}
