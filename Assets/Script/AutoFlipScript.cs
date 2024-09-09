using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.UIElements;
using System.ComponentModel;

// ������ �Լ��� �����߱� ������ �ּ��� ��Ȯ���� ���� 

[RequireComponent(typeof(NoteScript))]
public class AutoFlipScript : MonoBehaviour
{
    // �̱������� �ٸ� ��ũ��Ʈ �ҷ�����
    public static AutoFlipScript instance;

    private void Awake()
    {
        if (AutoFlipScript.instance == null)
        {
            AutoFlipScript.instance = this;

        }
    }

    // ���� ������ �ѱ�� ���
    public FlipMode Mode;
    // �ѱ�� �ð�
    public float PageFlipTime = 1;
    // ��Ʈ ��ũ��Ʈ
    public NoteScript ControledNote;
    // ������ ��� ��Ʈ
    public int AnimationFramesCount = 0;
    // �ڵ� �ѱ�� ���� 
    public bool isFlipping = false;


    void Start()
    {
        // ��Ʈ �ҷ�����
        if (!ControledNote)
            ControledNote = GetComponent<NoteScript>();
    }

    // ��Ʈ ���� �Լ�
    public void OpenNote()
    {
        // ��� �ҷ�����
        Mode = FlipMode.RightToLeft;
        // ��Ʈ ���� �ڷ�ƾ
        StartCoroutine(FlipToEnd());
    }

    // ��Ʈ �ݱ� �Լ� 
    public void CloseNote()
    {
        // ��� �ҷ�����
        Mode = FlipMode.LeftToRight;
        // ��Ʈ �ݱ� �ڷ�ƾ 
        StartCoroutine(FlipToEnd());
    }

    // ��Ʈ ���ݱ� �Լ�
    IEnumerator FlipToEnd()
    {
        // �����ӽð� ���
        float frameTime = PageFlipTime / AnimationFramesCount;

        // ��Ʈ ������ �� ���� ���
        float xc = (ControledNote.EndBottomRight.x + ControledNote.EndBottomLeft.x) / 2;
        float xl = ((ControledNote.EndBottomRight.x - ControledNote.EndBottomLeft.x) / 2) * 0.9f;
        float h = Mathf.Abs(ControledNote.EndBottomRight.y) * 0.9f;
        float dx = (xl) * 2 / AnimationFramesCount;

        // ��Ʈ���� �̹��� �ҷ�����
        UnityEngine.UI.Image nextClip = ControledNote.NextPageClip;

        switch (Mode)
        {
            // ��Ʈ�� ���� 
            case FlipMode.RightToLeft:

                // ��Ʈ ������
                isFlipping = true;

                // ���� ������������ ���� 
                while (ControledNote.currentPage < 6)
                {
                    // ��Ʈ ���� �ڷ�ƾ ����
                    StartCoroutine(FlipRTL(xc, xl, h, frameTime, dx, nextClip));

                    // ��Ʈ ������ ���� ������ 
                    yield return new WaitForSeconds(0.25f);
                }

                // ��Ʈ�� �� ���� ��Ʈ�� �ִ� �ؽ�Ʈ Ȱ��ȭ
                NoteTextObjScript.instance.noteTxtObj.SetActive(true);

                break;

            // ��Ʈ�� ���� ��
            case FlipMode.LeftToRight:

                // ��Ʈ �ݴ���
                isFlipping = true;

                // ��Ʈ �ݱ� 
                while (ControledNote.currentPage > 0)
                {
                    // ��Ʈ �ݱ� �ڷ�ƾ ���� 
                    StartCoroutine(FlipLTR(xc, xl, h, frameTime, dx, nextClip));

                    // ��Ʈ �ݰ� ��¦ ������
                    yield return new WaitForSeconds(0.35f);
                }

                // ��Ʈ�� �ٰ� ��Ʈ �޺κ� Ŭ�� ���� ���ϰ� ����� �г� ��Ȱ��ȭ 
                NoteScript.instance.NotePanel.gameObject.SetActive(false);

                break;
        }

        // ���ݱ� ���� ���� 
        isFlipping = false;
    }

    // ��Ʈ ���� 
    IEnumerator FlipRTL(float xc, float xl, float h, float frameTime, float dx, UnityEngine.UI.Image image)
    {
        // ��Ʈ�� ���� �ʿ��� ��ġ ���
        float x = xc + xl;
        float y = (-h / (xl * xl)) * (x - xc) * (x - xc);

        // ��Ʈ �������� ����
        ControledNote.DragRightPageToPoint(new Vector3(x, y, 0), image);

        // ��Ʈ ������ ������Ʈ
        ControledNote.ReleasePage(); 

        yield return null;
    }

    // ��Ʈ �ݱ� 
    IEnumerator FlipLTR(float xc, float xl, float h, float frameTime, float dx, UnityEngine.UI.Image image)
    {
        // ��Ʈ�� ���� �ʿ��� ��ġ ���
        float x = xc - xl;
        float y = (-h / (xl * xl)) * (x - xc) * (x - xc);

        // ��Ʈ�� �ٷ� �ݱ� ���� ���� ���������� ����
        ControledNote.currentPage = 2;

        // ��Ʈ �������� 
        ControledNote.DragLeftPageToPoint(new Vector3(x, y, 0), image);

        // ��Ʈ ������ ������Ʈ
        ControledNote.ReleasePage();

        yield return null;
    }
}