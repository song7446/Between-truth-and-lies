using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoryScript : MonoBehaviour
{
    public Text ScriptTxt;
    public Text Name;

    GameObject textObj;

    private string text;
    private float delay = 0.05f;

    int scriptCount = 0;
    public bool printBool = false;

    void Start()
    {
        // ���丮 ��ũ��Ʈ ��������
        textObj = GameObject.Find("Scene1ScriptObj");

        // ���丮 ��ũ��Ʈ �ʱ�ȭ
        ScriptTxt.text = "";
        Name.text = "";
    }

    void Update()
    {
        // ���콺 �� �����̽��� Ŭ���� ���丮 ��ũ��Ʈ ����
        if (Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.Space))
        {
            scriptCount++;
            // �߰� Ŭ���� �ؽ�Ʈ�� ��ġ�� ������ 2���� ��� 
            if (scriptCount % 2 == 0)
            {
                UpdateScript(scriptCount);
            }
        }
    }

    public void UpdateScript(int num)
    {
        // ���丮 �ؽ�Ʈ
        text = textObj.GetComponent<Scene1Script>().ScriptCollection(num);
        // ȭ�� �̸�
        string name = textObj.GetComponent<Scene1Script>().NameCollection(num);

        Name.text = name;
        ScriptTxt.text = "";

        // �ؽ�Ʈ �ѱ��ھ� ���
        StartCoroutine(TextPrint(delay));

    }

    // �ؽ�Ʈ �ѱ��ھ� ��� �Լ� 
    public IEnumerator TextPrint(float d)
    {
        int count = 0;
        while (count != text.Length)
        {
            // �ؽ�Ʈ �ѱ��ھ� ��� ���� ���콺 �� �����̽��� Ŭ���� ��� �ؽ�Ʈ�� ���� �ڷ�ƾ ����
            if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space))
            {
                ScriptTxt.text = text;
                yield break;
            }
            if (count < text.Length)
            {
                ScriptTxt.text += text[count].ToString();
                count++;
            }
            yield return new WaitForSeconds(d);
        }

        scriptCount++;
    }
}
