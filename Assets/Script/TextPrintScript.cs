using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextPrintScript : MonoBehaviour
{
    // �̱������� �ٸ� ��ũ��Ʈ �ҷ�����
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
        // �ڷ�ƾ ���� Ȱ��ȭ�� ����
        StoryManager.instance.coroutineBool = true;
        
        // �ؽ�Ʈ ���� �ε���
        int count = 0;
        
        // �ؽ�Ʈ ���ڰ� ����������
        while (count != scriptText.Length)
        {
            // �ؽ�Ʈ ���ڰ� ������ �ʾҴٸ�
            if (count < scriptText.Length)
            {
                // �ؽ�Ʈ�� �ε�����° ���ڸ� �߰� 
                objectText.text += scriptText[count].ToString();

                // �ؽ�Ʈ ���� �ε��� ���� 
                count++;
            }

            // d�� ��ŭ ���
            yield return new WaitForSeconds(d);
        }

        // �ڷ�ƾ ���� ��Ȱ��ȭ�� ����
        StoryManager.instance.coroutineBool = false;
    }
}
