using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

// 가져온 함수를 수정했기 때문에 부정확함 
public enum FlipMode
{
    RightToLeft,
    LeftToRight
}

[ExecuteInEditMode]
public class NoteScript : MonoBehaviour
{
    // 싱글톤으로 다른 스크립트 불러오기
    public static NoteScript instance;

    private void Awake()
    {
        if (NoteScript.instance == null)
        {
            NoteScript.instance = this;

        }
    }   

    // 노트의 부모
    public Canvas canvas;

    // 주 노트 오브젝트 
    [SerializeField]
    public RectTransform NotePanel;

    // 노트 배경
    public Sprite background;

    // 노트 페이지 스프라이트
    public Sprite[] notePages;

    // 노트 그림자 상태
    public bool enableShadowEffect = true;

    // 노트 페이지 스프라이트의 인덱스 - 현재 펼쳐져 있는 노트의 오른쪽 페이지 번호
    public int currentPage = 0;

    // 노트의 총 페이지 개수
    public int TotalPageCount
    {
        get { return notePages.Length; }
    }

    // 노트의 왼쪽 아래 꼭지점 위치
    public Vector3 EndBottomLeft
    {
        get { return ebl; }
    }

    // 노트의 오른쪽 아래 꼭지점 위치
    public Vector3 EndBottomRight
    {
        get { return ebr; }
    }

    // 노트의 높이 
    public float Height
    {
        get
        {
            return NotePanel.rect.height;
        }
    }

    // 넘어가는 페이지의 이미지 
    public Image ClippingPlane;

    // 다음 페이지의 이미지 
    public Image NextPageClip;

    // 노트의 그림자 이미지  
    public Image Shadow;

    // 왼쪽에서 오른쪽으로 넘길때 노트의 그림자 이미지 
    public Image ShadowLTR;

    // 현재 펼쳐져 있는 페이지의 왼쪽 이미지 
    public Image Left;

    // 왼쪽으로 넘길 때 다음 이미지 
    public Image LeftNext;

    // 현재 펼쳐져 있는 페이지의 오른쪽 이미지 
    public Image Right;

    // 오른쪽으로 넘길 때 다음 이미지 
    public Image RightNext;

    // 넘기는 상태 이벤트 
    public UnityEvent OnFlip;

    // 페이지를 넘길 때 꼭지점에 생기는 반지름 
    float radius1, radius2;

    // 노트의 가운데 바닥
    Vector3 sb;

    // 노트의 가운데 상단
    Vector3 st;

    // 페이지의 코너 
    Vector3 c;

    // 오른쪽 아래 쪽지점의 위치 
    Vector3 ebr;

    // 왼쪽 아래 꼭지점의 위치 
    Vector3 ebl;

    // 노트가 넘어가는 지점
    Vector3 f;

    // 왼쪽으로 넘기는지 오른쪽으로 넘기는지 상태 enum
    FlipMode mode;

    // 노트 활성화 상태 
    public bool noteBool = false;

    void Start()
    {
        // 노트의 부모요소 받아오기 
        if (!canvas) canvas = GetComponentInParent<Canvas>();
        // 없다면 에러 띄우기 
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