using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextPrintScript : MonoBehaviour
{
    public static TextPrintScript instance;

    private void Awake()
    {
        if (TextPrintScript.instance == null)
        {
            TextPrintScript.instance = this;

        }
    }

    // �ؽ�Ʈ �ѱ��ھ� ��� �Լ� 
    public IEnumerator TextPrint(float d, string scriptText, Text objectText)
    {
        int count = 0;
        while (count != scriptText.Length)
        {
            // �ؽ�Ʈ �ѱ��ھ� ��� ���� ���콺 �� �����̽��� Ŭ���� ��� �ؽ�Ʈ�� ���� �ڷ�ƾ ����
            if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space))
            {
                objectText.text = scriptText;
                yield break;
            }
            if (count < scriptText.Length)
            {
                objectText.text += scriptText[count].ToString();
                count++;
            }
            yield return new WaitForSeconds(d);
        }
    }
}
