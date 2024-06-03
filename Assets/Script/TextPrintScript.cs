using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextPrintScript : MonoBehaviour
{
    public static TextPrintScript instance;

    public bool printBool = false;

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
        printBool = true;
        int count = 0;
        while (count != scriptText.Length)
        {
            if (count < scriptText.Length)
            {
                objectText.text += scriptText[count].ToString();
                count++;
            }
            yield return new WaitForSeconds(d);
        }
        printBool = false;
    }
}
