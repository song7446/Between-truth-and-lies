using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteTextObjScript : MonoBehaviour
{
    public static NoteTextObjScript instance;

    private void Awake()
    {
        if (NoteTextObjScript.instance == null)
        {
            NoteTextObjScript.instance = this;
        }
    }


    public GameObject noteTxtObj;

    public GameObject leftTextObj;

    public GameObject textObj;

    public GameObject loadTextObj;
    public GameObject noteTextObj;

    public Text talkName;
    public Text talkText;

    public void updateNoteText(GameObject obj)
    {
        talkName = obj.transform.GetChild(0).gameObject.GetComponent<Text>();
        talkText = obj.transform.GetChild(1).gameObject.GetComponent<Text>();

        loadTextObj = Resources.Load<GameObject>("PreFab/NoteText");
        noteTextObj = GameObject.Instantiate<GameObject>(loadTextObj);

        noteTextObj.transform.SetParent(leftTextObj.transform, false);

        noteTextObj.GetComponent<Text>().text = talkName.text + "는 " + talkText.text + "라고 증언함";
    }

    void Start()
    {
        noteTxtObj.SetActive(false);
    }


    void Update()
    {
        
    }
}
