using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteButtonScript : MonoBehaviour
{
    public Button noteBtn;
    public GameObject btnOnPanel;

    void Start()
    {
        noteBtn.onClick.AddListener(noteBtn_onClick);
        btnOnPanel = GameObject.Find("ButtonOnPanel");
        btnOnPanel.SetActive(false);
    }

    void noteBtn_onClick()
    {
        if (NoteScript.instance.noteBool)
        {
            btnOnPanel.SetActive(false);
            AutoFlipScript.instance.CloseNote();
            NoteScript.instance.NotePanel.gameObject.SetActive(false);
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
