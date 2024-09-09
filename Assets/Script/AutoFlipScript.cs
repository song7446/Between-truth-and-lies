using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.UIElements;
using System.ComponentModel;

// 가져온 함수를 수정했기 때문에 주석이 정확하지 않음 

[RequireComponent(typeof(NoteScript))]
public class AutoFlipScript : MonoBehaviour
{
    // 싱글톤으로 다른 스크립트 불러오기
    public static AutoFlipScript instance;

    private void Awake()
    {
        if (AutoFlipScript.instance == null)
        {
            AutoFlipScript.instance = this;

        }
    }

    // 왼쪽 오른쪽 넘기기 모드
    public FlipMode Mode;
    // 넘기는 시간
    public float PageFlipTime = 1;
    // 노트 스크립트
    public NoteScript ControledNote;
    // 프레임 계산 인트
    public int AnimationFramesCount = 0;
    // 자동 넘기기 상태 
    public bool isFlipping = false;


    void Start()
    {
        // 노트 불러오기
        if (!ControledNote)
            ControledNote = GetComponent<NoteScript>();
    }

    // 노트 열기 함수
    public void OpenNote()
    {
        // 모드 불러오기
        Mode = FlipMode.RightToLeft;
        // 노트 열기 코루틴
        StartCoroutine(FlipToEnd());
    }

    // 노트 닫기 함수 
    public void CloseNote()
    {
        // 모드 불러오기
        Mode = FlipMode.LeftToRight;
        // 노트 닫기 코루틴 
        StartCoroutine(FlipToEnd());
    }

    // 노트 여닫기 함수
    IEnumerator FlipToEnd()
    {
        // 프레임시간 계산
        float frameTime = PageFlipTime / AnimationFramesCount;

        // 노트 꼭지점 및 높이 계산
        float xc = (ControledNote.EndBottomRight.x + ControledNote.EndBottomLeft.x) / 2;
        float xl = ((ControledNote.EndBottomRight.x - ControledNote.EndBottomLeft.x) / 2) * 0.9f;
        float h = Mathf.Abs(ControledNote.EndBottomRight.y) * 0.9f;
        float dx = (xl) * 2 / AnimationFramesCount;

        // 노트다음 이미지 불러오기
        UnityEngine.UI.Image nextClip = ControledNote.NextPageClip;

        switch (Mode)
        {
            // 노트를 열때 
            case FlipMode.RightToLeft:

                // 노트 여는중
                isFlipping = true;

                // 일정 페이지까지만 열기 
                while (ControledNote.currentPage < 6)
                {
                    // 노트 여는 코루틴 시작
                    StartCoroutine(FlipRTL(xc, xl, h, frameTime, dx, nextClip));

                    // 노트 페이지 마다 딜레이 
                    yield return new WaitForSeconds(0.25f);
                }

                // 노트를 다 열고 노트에 있는 텍스트 활성화
                NoteTextObjScript.instance.noteTxtObj.SetActive(true);

                break;

            // 노트를 닫을 때
            case FlipMode.LeftToRight:

                // 노트 닫는중
                isFlipping = true;

                // 노트 닫기 
                while (ControledNote.currentPage > 0)
                {
                    // 노트 닫기 코루틴 시작 
                    StartCoroutine(FlipLTR(xc, xl, h, frameTime, dx, nextClip));

                    // 노트 닫고 살짝 딜레이
                    yield return new WaitForSeconds(0.35f);
                }

                // 노트를 다고 노트 뒷부분 클릭 하지 못하게 만드는 패널 비활성화 
                NoteScript.instance.NotePanel.gameObject.SetActive(false);

                break;
        }

        // 여닫기 상태 종료 
        isFlipping = false;
    }

    // 노트 열기 
    IEnumerator FlipRTL(float xc, float xl, float h, float frameTime, float dx, UnityEngine.UI.Image image)
    {
        // 노트를 열때 필요한 위치 계산
        float x = xc + xl;
        float y = (-h / (xl * xl)) * (x - xc) * (x - xc);

        // 노트 한페이지 열기
        ControledNote.DragRightPageToPoint(new Vector3(x, y, 0), image);

        // 노트 페이지 업데이트
        ControledNote.ReleasePage(); 

        yield return null;
    }

    // 노트 닫기 
    IEnumerator FlipLTR(float xc, float xl, float h, float frameTime, float dx, UnityEngine.UI.Image image)
    {
        // 노트를 열때 필요한 위치 계산
        float x = xc - xl;
        float y = (-h / (xl * xl)) * (x - xc) * (x - xc);

        // 노트를 바로 닫기 위해 제일 앞페이지로 설정
        ControledNote.currentPage = 2;

        // 노트 한페이지 
        ControledNote.DragLeftPageToPoint(new Vector3(x, y, 0), image);

        // 노트 페이지 업데이트
        ControledNote.ReleasePage();

        yield return null;
    }
}