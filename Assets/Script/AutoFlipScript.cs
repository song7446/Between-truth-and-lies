using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.UIElements;
using System.ComponentModel;
[RequireComponent(typeof(NoteScript))]
public class AutoFlipScript : MonoBehaviour
{
    public FlipMode Mode;
    public float PageFlipTime = 1;
    public float DelayBeforeStarting = 0;
    public bool AutoStartFlip = true;
    public NoteScript ControledNote;
    public int AnimationFramesCount = 0;
    bool isFlipping = false;

    // Use this for initialization

    void Start()
    {
        if (!ControledNote)
            ControledNote = GetComponent<NoteScript>();
        ControledNote.OnFlip.AddListener(new UnityEngine.Events.UnityAction(PageFlipped));
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Mode = FlipMode.RightToLeft;
            StartCoroutine(FlipToEnd());
        }
        else if (Input.GetMouseButtonUp(1))
        {
            Mode = FlipMode.LeftToRight;
            StartCoroutine(FlipToEnd());
        }

    }

    void PageFlipped()
    {
        isFlipping = false;
    }

    IEnumerator FlipToEnd()
    {
        yield return new WaitForSeconds(DelayBeforeStarting);
        float frameTime = PageFlipTime / AnimationFramesCount;
        float xc = (ControledNote.EndBottomRight.x + ControledNote.EndBottomLeft.x) / 2;
        float xl = ((ControledNote.EndBottomRight.x - ControledNote.EndBottomLeft.x) / 2) * 0.9f;
        float h = Mathf.Abs(ControledNote.EndBottomRight.y) * 0.9f;
        float dx = (xl) * 2 / AnimationFramesCount;

        UnityEngine.UI.Image nextClip = ControledNote.NextPageClip;


        switch (Mode)
        {
            case FlipMode.RightToLeft:
                while (ControledNote.currentPage < ControledNote.TotalPageCount)
                {
                    StartCoroutine(FlipRTL(xc, xl, h, frameTime, dx, nextClip));
                    yield return new WaitForSeconds(0.25f);
                }
                break;
            case FlipMode.LeftToRight:
                while (ControledNote.currentPage > 0)
                {
                    StartCoroutine(FlipLTR(xc, xl, h, frameTime, dx, nextClip));
                    yield return new WaitForSeconds(0.25f);
                }
                break;
        }
    }

    IEnumerator FlipRTL(float xc, float xl, float h, float frameTime, float dx, UnityEngine.UI.Image image)
    {
        float x = xc + xl;
        float y = (-h / (xl * xl)) * (x - xc) * (x - xc);

        ControledNote.DragRightPageToPoint(new Vector3(x, y, 0), image);
        ControledNote.ReleasePage(); 

        yield return null;
    }
    IEnumerator FlipLTR(float xc, float xl, float h, float frameTime, float dx, UnityEngine.UI.Image image)
    {
        float x = xc - xl;
        float y = (-h / (xl * xl)) * (x - xc) * (x - xc);

        ControledNote.currentPage = 2;

        ControledNote.DragLeftPageToPoint(new Vector3(x, y, 0), image);
        ControledNote.ReleasePage();

        yield return new WaitForSeconds(frameTime);
    }
}