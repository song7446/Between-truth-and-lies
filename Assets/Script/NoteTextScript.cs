using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteTextScript : MonoBehaviour
{
    public static NoteTextScript instance;

    private void Awake()
    {
        if (NoteTextScript.instance == null)
        {
            NoteTextScript.instance = this;
        }
    }
    public GameObject noteTextObj;

    void Start()
    {
        noteTextObj.SetActive(false);
    }


    void Update()
    {
        
    }
}
