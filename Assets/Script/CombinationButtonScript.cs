using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CombinationButtonScript : MonoBehaviour
{
    // 싱글톤으로 다른 스크립트 불러오기
    public static CombinationButtonScript Instance;

    private void Awake()
    {
        if (CombinationButtonScript.Instance == null)
        {
            CombinationButtonScript.Instance = this;
        }
    }

    // 조합 버튼
    public Button comBtn;

    // 조합 버튼 상태
    public bool comBtnBool;

    // 노트 왼쪽 페이지 오브젝트
    public GameObject noteLeftTextObj;

    // 정답 상태
    public bool ansCheckBool;

    // 노트 왼쪽 페이지 텍스트 프리펩 불러오기용 오브젝트
    public GameObject loadTextObj;

    // 실제 활성화되는 노트 텍스트 오브젝트 
    public GameObject noteTextObj;

    // 정답이라고 알려주는 텍스트 상태
    public bool correctAnswerBool;

    // 오답이라고 알려주는 텍스트 상태
    public bool worngAnswerBool;

    void Start()
    {
        // 조합 버튼 리스너
        comBtn.onClick.AddListener(ComBtn_onClick);

        // 조합 버튼은 노트가 열렸을 때 사용하기 때문에 시작할때는 비활성화
        comBtn.gameObject.SetActive(false);
    }


    void Update()
    {

    }

    // 조합 버튼 리스너 함수
    void ComBtn_onClick()
    {
        // 정답 체크 함수 불러오기
        if (AnsCheck())
        {
            // 정답 일때  

            // 답으로 넣은 대화 로그 자식들 모두 물러오기
            Transform[] allChildren = noteLeftTextObj.GetComponentsInChildren<Transform>();

            // 모든 자식을 사용하기 위한 반복문
            foreach (Transform child in allChildren)
            {
                // GetComponentsInChildren 함수는 자식뿐만 아니라 본인도 가져오기 때문에 본인 제외
                if (child.name == "LeftTextObj")
                {
                    // 부모 요소는 넘기기
                }
                else
                {
                    // 자식요소는 모두 제거 
                    Destroy(child.gameObject);
                }
            }

            // 정답일 때 정답이라고 알려주는 오브젝트 활성화 
            AnswerResultScript.instance.corObj.SetActive(true);

            // 정답이라고 알려주는 오브젝트 활성화 후 페이드 아웃
            StartCoroutine(FadeInOut.instance.TextFadeOut(AnswerResultScript.instance.corObj.GetComponent<Text>()));

            // 정답 텍스트 추가하기 위해 프리펩 불러오기 
            loadTextObj = Resources.Load<GameObject>("PreFab/NoteText");

            // 정답 텍스트 프리펩 복사 
            noteTextObj = GameObject.Instantiate<GameObject>(loadTextObj);

            // 정답 텍스트 부모 오브젝트 설정
            noteTextObj.transform.SetParent(noteLeftTextObj.transform, false);

            // 정답 텍스트 이름 변경
            noteTextObj.name = "CorrectAnswer";

            // 정답 텍스트 정리 
            noteTextObj.GetComponent<Text>().text = "";
            string answer = "후배 형사에 의하면 이 사건은 성폭행으로 인해 딸이 아버지를 살해했고 " +
                                                    "자신이 직접 자신의 범행을 신고했다. " +
                                                    "현장에서 발견된 증거도 용의자를 가르키는 중이지만 " +
                                                    "용의자는 자신의 범행을 인정하면서도 묵비권을 행사중이다. ";
            // 정답 텍스트 한글자씩 출력 
            StartCoroutine(TextPrintScript.instance.TextPrint(0.05f, answer, noteTextObj.GetComponent<Text>()));

            // 정답 이후 버튼 페이드 아웃
            StartCoroutine(FadeInOut.instance.TextFadeOut(comBtn.transform.GetChild(0).GetComponent<Text>()));        

            if (Scene1Script.instance.storyEnd)
            {
                Invoke("endingImgFadeIn", 10);
                Invoke("nextSceneLoad", 15);               
            }
        }

        else
        {
            // 오답일때 

            // 오답이라고 알려주는 오브젝트 활성화
            AnswerResultScript.instance.worObj.SetActive(true);

            // 오답이라고 알려주는 오브젝트 활성화 후 페이드 아웃
            StartCoroutine(FadeInOut.instance.TextFadeOut(AnswerResultScript.instance.worObj.GetComponent<Text>()));
        }
    }

    // 정답 체크 함수
    public bool AnsCheck()
    {
        // 답 오브젝트 모두 불러오기 
        Transform[] allChildren = noteLeftTextObj.GetComponentsInChildren<Transform>();

        // 정답 체크하기 위한 배열
        // 0 : 딸이 아빠를 살해/ 1 : 범인은 딸이 유력/ 2 : 딸은 자신의 범행을 인정/ 3: 살해 동기
        // 모든 요소가 하나씩 들어가야 정답으로 인정
        int[] ansInt = { 0, 0, 0, 0 };

        // 모든 자식을 사용하기 위한 반복문
        foreach (Transform child in allChildren)
        {
            // GetComponentsInChildren 함수는 자식뿐만 아니라 본인도 가져오기 때문에 본인 제외
            if (child.name == "LeftTextObj")
            {
                // 부모 요소는 넘기기
            }
            else
            {
                // 0 : 딸이 아빠를 살해 
                if (NoteTextObjScript.instance.noteWrites[child.name] == "딸이 아버지를 살해함")
                {
                    ansInt[0]++;
                }

                // 2 : 딸은 자신의 범행을 인정
                else if (NoteTextObjScript.instance.noteWrites[child.name] == "딸 본인이 직접 신고함")
                {
                    ansInt[2]++;
                }

                // 1 : 범인은 딸이 유력
                else if (NoteTextObjScript.instance.noteWrites[child.name] == "현장에 있던 사람은 피해자와 용의자 둘뿐임")
                {
                    ansInt[1]++;
                }

                // 1 : 범인은 딸이 유력
                else if (NoteTextObjScript.instance.noteWrites[child.name] == "침입의 흔적도 없음")
                {
                    ansInt[1]++;
                }

                // 1 : 범인은 딸이 유력
                else if (NoteTextObjScript.instance.noteWrites[child.name] == "흉기에서 용의자의 지문까지 검출됨")
                {
                    ansInt[1]++;
                }

                // 2 : 딸은 자신의 범행을 인정
                else if (NoteTextObjScript.instance.noteWrites[child.name] == "용의자는 자신의 범행을 인정함")
                {
                    ansInt[2]++;
                }

                //2 : 딸은 자신의 범행을 인정
                else if (NoteTextObjScript.instance.noteWrites[child.name] == "용의자는 자신의 범행을 인정하지만 묵비권을 행사중")
                {
                    ansInt[2]++;
                }

                // 3: 살해 동기
                else if (NoteTextObjScript.instance.noteWrites[child.name] == "살해 동기는 성폭행으로 보임")
                {
                    ansInt[3]++;
                }
            }
        }

        // 모든 요소가 들어있는지 확인 
        foreach (int i in ansInt)
        {
            // 어느 하나라도 빠져있으면 
            if (i == 0)
            {
                // 오답
                ansCheckBool = false;
                return false;
            }
        }

        // 그게 아니면 정답
        ansCheckBool = true;
        return true;
    }

    public void EndingImgFadeIn()
    {
        OpeningScript.instance.openingTxt.text = "";
        OpeningScript.instance.obgsp.color = new Color(0, 0, 0, 0);
        OpeningScript.instance.openingBackGround.SetActive(true);
        StartCoroutine(FadeInOut.instance.ImageFadeIn(OpeningScript.instance.obgsp));
    }

    public void NextSceneLoad()
    {
        SceneManager.LoadScene("Scene#2");
    }
}
