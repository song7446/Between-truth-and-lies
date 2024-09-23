using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingScript : MonoBehaviour
{
    // �̱������� �ٸ� ��ũ��Ʈ �ҷ�����
    public static EndingScript instance;

    private void Awake()
    {
        if (EndingScript.instance == null)
        {
            EndingScript.instance = this;
        }
    }

    // �����̹��� ������Ʈ
    public GameObject endFrontGround;
    // ������ ���� �������� �� ���� �ؽ�Ʈ
    public Text endingText;
    // ���� ����
    public bool endingImgBool;

    void Start()
    {
        // �����̹��� ��Ȱ��ȭ
        endFrontGround.SetActive(false);
    }

    void Update()
    {
        
    }
}
