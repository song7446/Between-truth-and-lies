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

    // 텍스트 한글자씩 출력 함수 
    public IEnumerator TextPrint(float d, string scriptText, Text objectText)
    {
        int count = 0;
        while (count != scriptText.Length)
        {
            // 텍스트 한글자씩 출력 도중 마우스 및 스페이스바 클릭시 모든 텍스트를 띄우고 코루틴 종료
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
