using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerResultScript : MonoBehaviour
{
    // �̱������� �ٸ� ��ũ��Ʈ �ҷ�����
    public static AnswerResultScript instance;

    private void Awake()
    {
        if (AnswerResultScript.instance == null)
        {
            AnswerResultScript.instance = this;

        }
    }

    // ���� ������Ʈ 
    public GameObject corObj;

    // ���� ������Ʈ 
    public GameObject worObj;

    void Start()
    {
        // ���� ���� ������Ʈ�� ��Ʈ�� ������ ���� ��ư�� ������ ����ϱ� ������ ������ ���� ��Ȱ��ȭ
        corObj.SetActive(false);
        worObj.SetActive(false);
    }
}
