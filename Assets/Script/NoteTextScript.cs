using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteTextScript : MonoBehaviour
{
    // �̱������� �ٸ� ��ũ��Ʈ �ҷ�����
    public static NoteTextScript instance;

    private void Awake()
    {
        if (NoteTextScript.instance == null)
        {
            NoteTextScript.instance = this;
        }
    }

    // �ؽ�Ʈ ������Ʈ 
    public GameObject textObj;

    // �߿� �ؽ�Ʈ 
    public Text impText;

}
