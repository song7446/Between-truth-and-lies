using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteTextScript : MonoBehaviour
{
    // 싱글톤으로 다른 스크립트 불러오기
    public static NoteTextScript instance;

    private void Awake()
    {
        if (NoteTextScript.instance == null)
        {
            NoteTextScript.instance = this;
        }
    }

    // 텍스트 오브젝트 
    public GameObject textObj;

    // 중요 텍스트 
    public Text impText;

}
