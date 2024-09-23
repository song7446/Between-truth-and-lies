using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalseTextUseScript : MonoBehaviour
{
    // �̱������� �ٸ� ��ũ��Ʈ �ҷ�����
    public static FalseTextUseScript instance;

    private void Awake()
    {
        if (FalseTextUseScript.instance == null)
        {
            FalseTextUseScript.instance = this;

        }
    }

    // ���� �ؽ�Ʈ ���� �˸� ������Ʈ
    public GameObject falTxtObj;

    void Start()
    {
        // ���� �ؽ�Ʈ �˸� ������Ʈ ��Ȱ��ȭ
        falTxtObj.SetActive(false);
    }
}
