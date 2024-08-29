using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteButtonScript : MonoBehaviour
{
    public static NoteButtonScript instance;

    private void Awake()
    {
        if (NoteButtonScript.instance == null)
        {
            NoteButtonScript.instance = this;
        }
    }

    public Button noteBtn;
    public GameObject btnOnPanel;

    void Start()
    {
        noteBtn.onClick.AddListener(noteBtn_onClick);
        btnOnPanel = GameObject.Find("ButtonOnPanel");
        btnOnPanel.SetActive(false);

        noteBtn.gameObject.SetActive(false);
    }

    void noteBtn_onClick()
    {
        if (AutoFlipScript.instance.isFlipping)
        {

        }
        else if (NoteScript.instance.noteBool)
        {
            btnOnPanel.SetActive(false);
            NoteTextObjScript.instance.noteTxtObj.SetActive(false);
            AutoFlipScript.instance.CloseNote();
            NoteScript.instance.noteBool = false;
        }
        else
        {
            btnOnPanel.SetActive(true);            
            NoteScript.instance.NotePanel.gameObject.SetActive(true);
            NoteScript.instance.noteBool = true;
            AutoFlipScript.instance.OpenNote();
        }
        Debug.Log("노트 버튼 클릭");
    }

    void Update()
    {

    }
}
