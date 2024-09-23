using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextPrintScript : MonoBehaviour
{
    // 싱글톤으로 다른 스크립트 불러오기
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
        // 코루틴 상태 활성화로 변경
        StoryManager.instance.coroutineBool = true;
        
        // 텍스트 글자 인덱스
        int count = 0;
        
        // 텍스트 글자가 끝날때까지
        while (count != scriptText.Length)
        {
            // 텍스트 글자가 끝나지 않았다면
            if (count < scriptText.Length)
            {
                // 텍스트의 인덱스번째 글자를 추가 
                objectText.text += scriptText[count].ToString();

                // 텍스트 글자 인덱스 증가 
                count++;
            }

            // d초 만큼 대기
            yield return new WaitForSeconds(d);
        }

        // 코루틴 상태 비활성화로 변경
        StoryManager.instance.coroutineBool = false;
    }
}
