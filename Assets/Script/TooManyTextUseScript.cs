using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooManyTextUseScript : MonoBehaviour
{
    // �̱������� �ٸ� ��ũ��Ʈ �ҷ�����
    public static TooManyTextUseScript instance;

    private void Awake()
    {
        if (TooManyTextUseScript.instance == null)
        {
            TooManyTextUseScript.instance = this;

        }
    }

    // �ʹ� ���� �ؽ�Ʈ ��� ������Ʈ 
    public GameObject tooManyTextUseObj;

    void Start()
    {
        // �ʹ� ���� �ؽ�Ʈ ��� ������Ʈ ��Ȱ��ȭ 
        tooManyTextUseObj.SetActive(false);
    }

    void Update()
    {
        
    }
}
