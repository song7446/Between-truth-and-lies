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

    void Start()
    {
        textUseBtn.onClick.AddListener(textUseBtn_onClick);
        textUseBtn.gameObject.SetActive(false);
    }

    void textUseBtn_onClick()
    {
        Debug.Log("�ؽ�Ʈ ��� ��ư Ŭ��");
        textUseBtn.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
