using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteButtonScript : MonoBehaviour
{
    public Button noteBtn;

    void Start()
    {
        noteBtn.onClick.AddListener(noteBtn_onClick);
    }

    void noteBtn_onClick()
    {
        Debug.Log("��Ʈ ��ư Ŭ��");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
