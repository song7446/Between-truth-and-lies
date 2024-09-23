using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

// ������ �Լ��� �����߱� ������ ����Ȯ�� 
public enum FlipMode
{
    RightToLeft,
    LeftToRight
}

[ExecuteInEditMode]
public class NoteScript : MonoBehaviour
{
    // �̱������� �ٸ� ��ũ��Ʈ �ҷ�����
    public static NoteScript instance;

    private void Awake()
    {
        if (NoteScript.instance == null)
        {
            NoteScript.instance = this;

        }
    }   

    // ��Ʈ�� �θ�
    public Canvas canvas;

    // �� ��Ʈ ������Ʈ 
    [SerializeField]
    public RectTransform NotePanel;

    // ��Ʈ ���
    public Sprite background;

    // ��Ʈ ������ ��������Ʈ
    public Sprite[] notePages;

    // ��Ʈ �׸��� ����
    public bool enableShadowEffect = true;

    // ��Ʈ ������ ��������Ʈ�� �ε��� - ���� ������ �ִ� ��Ʈ�� ������ ������ ��ȣ
    public int currentPage = 0;

    // ��Ʈ�� �� ������ ����
    public int TotalPageCount
    {
        get { return notePages.Length; }
    }

    // ��Ʈ�� ���� �Ʒ� ������ ��ġ
    public Vector3 EndBottomLeft
    {
        get { return ebl; }
    }

    // ��Ʈ�� ������ �Ʒ� ������ ��ġ
    public Vector3 EndBottomRight
    {
        get { return ebr; }
    }

    // ��Ʈ�� ���� 
    public float Height
    {
        get
        {
            return NotePanel.rect.height;
        }
    }

    // �Ѿ�� �������� �̹��� 
    public Image ClippingPlane;

    // ���� �������� �̹��� 
    public Image NextPageClip;

    // ��Ʈ�� �׸��� �̹���  
    public Image Shadow;

    // ���ʿ��� ���������� �ѱ涧 ��Ʈ�� �׸��� �̹��� 
    public Image ShadowLTR;

    // ���� ������ �ִ� �������� ���� �̹��� 
    public Image Left;

    // �������� �ѱ� �� ���� �̹��� 
    public Image LeftNext;

    // ���� ������ �ִ� �������� ������ �̹��� 
    public Image Right;

    // ���������� �ѱ� �� ���� �̹��� 
    public Image RightNext;

    // �ѱ�� ���� �̺�Ʈ 
    public UnityEvent OnFlip;

    // �������� �ѱ� �� �������� ����� ������ 
    float radius1, radius2;

    // ��Ʈ�� ��� �ٴ�
    Vector3 sb;

    // ��Ʈ�� ��� ���
    Vector3 st;

    // �������� �ڳ� 
    Vector3 c;

    // ������ �Ʒ� �������� ��ġ 
    Vector3 ebr;

    // ���� �Ʒ� �������� ��ġ 
    Vector3 ebl;

    // ��Ʈ�� �Ѿ�� ����
    Vector3 f;

    // �������� �ѱ���� ���������� �ѱ���� ���� enum
    FlipMode mode;

    // ��Ʈ Ȱ��ȭ ���� 
    public bool noteBool = false;

    void Start()
    {
        // ��Ʈ�� �θ��� �޾ƿ��� 
        if (!canvas) canvas = GetComponentInParent<Canvas>();
        // ���ٸ� ���� ���� 
        if (!canvas) Debug.LogError("Note should be a child to canvas");

        Left.gameObject.SetActive(false);
        Right.gameObject.SetActive(false);
        UpdateSprites();
        CalcCurlCriticalPoints();

        float pageWidth = NotePanel.rect.width / 2.0f;
        float pageHeight = NotePanel.rect.height;
        NextPageClip.rectTransform.sizeDelta = new Vector2(pageWidth, pageHeight + pageHeight * 2);


        ClippingPlane.rectTransform.sizeDelta = new Vector2(pageWidth * 2 + pageHeight, pageHeight + pageHeight * 2);

        //hypotenous (diagonal) page length
        float hyp = Mathf.Sqrt(pageWidth * pageWidth + pageHeight * pageHeight);
        float shadowPageHeight = pageWidth / 2 + hyp;

        Shadow.rectTransform.sizeDelta = new Vector2(pageWidth, shadowPageHeight);
        Shadow.rectTransform.pivot = new Vector2(1, (pageWidth / 2) / shadowPageHeight);

        ShadowLTR.rectTransform.sizeDelta = new Vector2(pageWidth, shadowPageHeight);
        ShadowLTR.rectTransform.pivot = new Vector2(0, (pageWidth / 2) / shadowPageHeight);       
    }

    private void CalcCurlCriticalPoints()
    {
        sb = new Vector3(0, -NotePanel.rect.height / 2);
        ebr = new Vector3(NotePanel.rect.width / 2, -NotePanel.rect.height / 2);
        ebl = new Vector3(-NotePanel.rect.width / 2, -NotePanel.rect.height / 2);
        st = new Vector3(0, NotePanel.rect.height / 2);
        radius1 = Vector2.Distance(sb, ebr);
        float pageWidth = NotePanel.rect.width / 2.0f;
        float pageHeight = NotePanel.rect.height;
        radius2 = Mathf.Sqrt(pageWidth * pageWidth + pageHeight * pageHeight);
    }

    public Vector3 transformPoint(Vector3 mouseScreenPos)
    {
        if (canvas.renderMode == RenderMode.ScreenSpaceCamera)
        {
            Vector3 mouseWorldPos = canvas.worldCamera.ScreenToWorldPoint(new Vector3(mouseScreenPos.x, mouseScreenPos.y, canvas.planeDistance));
            Vector2 localPos = NotePanel.InverseTransformPoint(mouseWorldPos);

            return localPos;
        }
        else if (canvas.renderMode == RenderMode.WorldSpace)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 globalEBR = transform.TransformPoint(ebr);
            Vector3 globalEBL = transform.TransformPoint(ebl);
            Vector3 globalSt = transform.TransformPoint(st);
            Plane p = new Plane(globalEBR, globalEBL, globalSt);
            float distance;
            p.Raycast(ray, out distance);
            Vector2 localPos = NotePanel.InverseTransformPoint(ray.GetPoint(distance));
            return localPos;
        }
        else
        {
            //Screen Space Overlay
            Vector2 localPos = NotePanel.InverseTransformPoint(mouseScreenPos);
            return localPos;
        }
    }

    public void UpdateBookLTRToPoint(Vector3 followLocation, Image image)
    {
        mode = FlipMode.LeftToRight;
        f = followLocation;
        ShadowLTR.transform.SetParent(ClippingPlane.transform, true);
        ShadowLTR.transform.localPosition = new Vector3(0, 0, 0);
        ShadowLTR.transform.localEulerAngles = new Vector3(0, 0, 0);
        Left.transform.SetParent(ClippingPlane.transform, true);

        Right.transform.SetParent(NotePanel.transform, true);
        Right.transform.localEulerAngles = Vector3.zero;
        LeftNext.transform.SetParent(NotePanel.transform, true);

        c = Calc_C_Position(followLocation);
        Vector3 t1;
        float clipAngle = CalcClipAngle(c, ebl, out t1);
        //0 < T0_T1_Angle < 180
        clipAngle = (clipAngle + 180) % 180;

        ClippingPlane.transform.localEulerAngles = new Vector3(0, 0, clipAngle - 90);
        ClippingPlane.transform.position = NotePanel.TransformPoint(t1);

        //page position and angle
        Left.transform.position = NotePanel.TransformPoint(c);
        float C_T1_dy = t1.y - c.y;
        float C_T1_dx = t1.x - c.x;
        float C_T1_Angle = Mathf.Atan2(C_T1_dy, C_T1_dx) * Mathf.Rad2Deg;
        Left.transform.localEulerAngles = new Vector3(0, 0, C_T1_Angle - 90 - clipAngle);

        image.transform.localEulerAngles = new Vector3(0, 0, clipAngle - 90);

        image.transform.position = NotePanel.TransformPoint(t1);

        LeftNext.transform.SetParent(image.transform, true);

        Right.transform.SetParent(ClippingPlane.transform, true);
        Right.transform.SetAsFirstSibling();

        ShadowLTR.rectTransform.SetParent(Left.rectTransform, true);
    }
    public void UpdateBookRTLToPoint(Vector3 followLocation, Image image)
    {
        mode = FlipMode.RightToLeft;
        f = followLocation;
        Shadow.transform.SetParent(ClippingPlane.transform, true);
        Shadow.transform.localPosition = Vector3.zero;
        Shadow.transform.localEulerAngles = Vector3.zero;
        Right.transform.SetParent(ClippingPlane.transform, true);

        Left.transform.SetParent(NotePanel.transform, true);
        Left.transform.localEulerAngles = Vector3.zero;
        RightNext.transform.SetParent(NotePanel.transform, true);
        c = Calc_C_Position(followLocation);
        Vector3 t1;
        float clipAngle = CalcClipAngle(c, ebr, out t1);
        if (clipAngle > -90) clipAngle += 180;

        ClippingPlane.rectTransform.pivot = new Vector2(1, 0.35f);
        ClippingPlane.transform.localEulerAngles = new Vector3(0, 0, clipAngle + 90);
        ClippingPlane.transform.position = NotePanel.TransformPoint(t1);

        //page position and angle
        Right.transform.position = NotePanel.TransformPoint(c);
        float C_T1_dy = t1.y - c.y;
        float C_T1_dx = t1.x - c.x;
        float C_T1_Angle = Mathf.Atan2(C_T1_dy, C_T1_dx) * Mathf.Rad2Deg;
        Right.transform.localEulerAngles = new Vector3(0, 0, C_T1_Angle - (clipAngle + 90));

        image.transform.localEulerAngles = new Vector3(0, 0, clipAngle + 90);

        image.transform.position = NotePanel.TransformPoint(t1);

        RightNext.transform.SetParent(image.transform, true);
        Left.transform.SetParent(ClippingPlane.transform, true);
        Left.transform.SetAsFirstSibling();

        Shadow.rectTransform.SetParent(Right.rectTransform, true);
    }
    private float CalcClipAngle(Vector3 c, Vector3 bookCorner, out Vector3 t1)
    {
        Vector3 t0 = (c + bookCorner) / 2;
        float T0_CORNER_dy = bookCorner.y - t0.y;
        float T0_CORNER_dx = bookCorner.x - t0.x;
        float T0_CORNER_Angle = Mathf.Atan2(T0_CORNER_dy, T0_CORNER_dx);
        float T0_T1_Angle = 90 - T0_CORNER_Angle;

        float T1_X = t0.x - T0_CORNER_dy * Mathf.Tan(T0_CORNER_Angle);
        T1_X = normalizeT1X(T1_X, bookCorner, sb);
        t1 = new Vector3(T1_X, sb.y, 0);

        //clipping plane angle=T0_T1_Angle
        float T0_T1_dy = t1.y - t0.y;
        float T0_T1_dx = t1.x - t0.x;
        T0_T1_Angle = Mathf.Atan2(T0_T1_dy, T0_T1_dx) * Mathf.Rad2Deg;
        return T0_T1_Angle;
    }
    private float normalizeT1X(float t1, Vector3 corner, Vector3 sb)
    {
        if (t1 > sb.x && sb.x > corner.x)
            return sb.x;
        if (t1 < sb.x && sb.x < corner.x)
            return sb.x;
        return t1;
    }
    private Vector3 Calc_C_Position(Vector3 followLocation)
    {
        Vector3 c;
        f = followLocation;
        float F_SB_dy = f.y - sb.y;
        float F_SB_dx = f.x - sb.x;
        float F_SB_Angle = Mathf.Atan2(F_SB_dy, F_SB_dx);
        Vector3 r1 = new Vector3(radius1 * Mathf.Cos(F_SB_Angle), radius1 * Mathf.Sin(F_SB_Angle), 0) + sb;

        float F_SB_distance = Vector2.Distance(f, sb);
        if (F_SB_distance < radius1)
            c = f;
        else
            c = r1;
        float F_ST_dy = c.y - st.y;
        float F_ST_dx = c.x - st.x;
        float F_ST_Angle = Mathf.Atan2(F_ST_dy, F_ST_dx);
        Vector3 r2 = new Vector3(radius2 * Mathf.Cos(F_ST_Angle),
           radius2 * Mathf.Sin(F_ST_Angle), 0) + st;
        float C_ST_distance = Vector2.Distance(c, st);
        if (C_ST_distance > radius2)
            c = r2;
        return c;
    }

    public void DragRightPageToPoint(Vector3 point, Image image)
    {
        if (currentPage >= notePages.Length) return;
        mode = FlipMode.RightToLeft;
        f = point;


        image.rectTransform.pivot = new Vector2(0, 0.12f);

        ClippingPlane.rectTransform.pivot = new Vector2(1, 0.35f);

        Left.gameObject.SetActive(true);
        Left.rectTransform.pivot = new Vector2(0, 0);
        Left.transform.position = RightNext.transform.position;
        Left.transform.eulerAngles = new Vector3(0, 0, 0);
        Left.sprite = (currentPage < notePages.Length) ? notePages[currentPage] : background;
        Left.transform.SetAsFirstSibling();

        Right.gameObject.SetActive(true);
        Right.transform.position = RightNext.transform.position;
        Right.transform.eulerAngles = new Vector3(0, 0, 0);
        Right.sprite = (currentPage < notePages.Length - 1) ? notePages[currentPage + 1] : background;

        RightNext.sprite = (currentPage < notePages.Length - 2) ? notePages[currentPage + 2] : background;

        LeftNext.transform.SetAsFirstSibling();
        if (enableShadowEffect) Shadow.gameObject.SetActive(true);
        UpdateBookRTLToPoint(f, image);
    }

    public void DragLeftPageToPoint(Vector3 point, Image image)
    {
        if (currentPage <= 0) return;
        mode = FlipMode.LeftToRight;
        f = point;

        image.rectTransform.pivot = new Vector2(1, 0.12f);

        ClippingPlane.rectTransform.pivot = new Vector2(0, 0.35f);

        Right.gameObject.SetActive(true);
        Right.transform.position = LeftNext.transform.position;
        Right.sprite = notePages[currentPage - 1];
        Right.transform.eulerAngles = new Vector3(0, 0, 0);
        Right.transform.SetAsFirstSibling();

        Left.gameObject.SetActive(true);
        Left.rectTransform.pivot = new Vector2(1, 0);
        Left.transform.position = LeftNext.transform.position;
        Left.transform.eulerAngles = new Vector3(0, 0, 0);
        Left.sprite = (currentPage >= 2) ? notePages[currentPage - 2] : background;

        LeftNext.sprite = (currentPage >= 3) ? notePages[currentPage - 3] : background;

        RightNext.transform.SetAsFirstSibling();
        if (enableShadowEffect) ShadowLTR.gameObject.SetActive(true);
        UpdateBookLTRToPoint(f, image);
    }

    public void ReleasePage()
    {
        float distanceToLeft = Vector2.Distance(c, ebl);
        float distanceToRight = Vector2.Distance(c, ebr);
        TweenForward();
    }

    Coroutine currentCoroutine;

    public void UpdateSprites()
    {
        LeftNext.sprite = (currentPage > 0 && currentPage <= notePages.Length) ? notePages[currentPage - 1] : background;
        RightNext.sprite = (currentPage >= 0 && currentPage < notePages.Length) ? notePages[currentPage] : background;

        Debug.Log(currentPage);
    }
    public void TweenForward()
    {
        if (mode == FlipMode.RightToLeft)
            currentCoroutine = StartCoroutine(TweenTo(ebl, 0.25f, () => { Flip(); }));
        else
            currentCoroutine = StartCoroutine(TweenTo(ebr, 0.25f, () => { Flip(); }));
    }
    void Flip()
    {
        if (mode == FlipMode.RightToLeft)
            currentPage += 2;
        else
            currentPage -= 2;
        LeftNext.transform.SetParent(NotePanel.transform, true);
        Left.transform.SetParent(NotePanel.transform, true);
        LeftNext.transform.SetParent(NotePanel.transform, true);
        Left.gameObject.SetActive(false);
        Right.gameObject.SetActive(false);
        Right.transform.SetParent(NotePanel.transform, true);
        RightNext.transform.SetParent(NotePanel.transform, true);
        UpdateSprites();
        Shadow.gameObject.SetActive(false);
        ShadowLTR.gameObject.SetActive(false);
        if (OnFlip != null)
            OnFlip.Invoke();
    }

    public IEnumerator TweenTo(Vector3 to, float duration, System.Action onFinish)
    {
        int steps = (int)(duration / 0.025f);
        Vector3 displacement = (to - f) / steps;
        for (int i = 0; i < steps - 1; i++)
        {
            if (mode == FlipMode.RightToLeft)
                UpdateBookRTLToPoint(f + displacement, NextPageClip);
            else
                UpdateBookLTRToPoint(f + displacement, NextPageClip);

            yield return new WaitForSeconds(0.025f);
        }
        if (onFinish != null)
            onFinish();
    }
}