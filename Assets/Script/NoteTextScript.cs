using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public GameObject textObj;

    public Text impText;

}
