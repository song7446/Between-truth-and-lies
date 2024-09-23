using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteButtonScript : MonoBehaviour
{
    // �̱������� �ٸ� ��ũ��Ʈ �ҷ�����
    public static NoteButtonScript instance;

    private void Awake()
    {
        if (NoteButtonScript.instance == null)
        {
            NoteButtonScript.instance = this;
        }
    }

    // ��Ʈ ��ư 
    public Button noteBtn;

    // ��Ʈ ��ư Ŭ���� �� UI Ŭ�� �Ұ� �г�
    public GameObject btnOnPanel;

    void Start()
    {
        // ��ư ������ �߰� 
        noteBtn.onClick.AddListener(noteBtn_onClick);

        // Ŭ�� �Ұ� �г� ã�� 
        btnOnPanel = GameObject.Find("ButtonOnPanel");

        // Ŭ�� �Ұ� �г� ��Ȱ��ȭ
        btnOnPanel.SetActive(false);

        // ��Ʈ ��ư ��Ȱ��ȭ - �����׿����� Ŭ�� �� �� ���� ������ 
        noteBtn.gameObject.SetActive(false);
    }

    // ��Ʈ ��ư Ŭ�� �Լ� 
    public void noteBtn_onClick()
    {
        // ��Ʈ �ڷ�ƾ Ȱ��ȭ�� Ŭ�� ���� 
        if (AutoFlipScript.instance.isFlipping)
        {

        }
        // ��Ʈ�� Ȱ��ȭ�� 
        else if (NoteScript.instance.noteBool)
        {
            // Ŭ�� �Ұ� �г� ��Ȱ��ȭ
            btnOnPanel.SetActive(false);

            // ��Ʈ �� �ؽ�Ʈ ��Ȱ��ȭ 
            NoteTextObjScript.instance.noteTxtObj.SetActive(false);

            // ��Ʈ �ݱ� �Լ�
            AutoFlipScript.instance.CloseNote();

            // ��Ʈ ��Ȱ��ȭ ���·� ����
            NoteScript.instance.noteBool = false;

            // ���� ��ư ��Ȱ��ȭ
            CombinationButtonScript.Instance.comBtn.gameObject.SetActive(false);
        }
        // ��Ʈ�� ��Ȱ��ȭ�� 
        else
        {
            // Ŭ�� �Ұ� �г� Ȱ��ȭ 
            btnOnPanel.SetActive(true);     

            // ��Ʈ Ȱ��ȭ 
            NoteScript.instance.NotePanel.gameObject.SetActive(true);

            // ��Ʈ Ȱ��ȭ ���·� ����
            NoteScript.instance.noteBool = true;

            // ��Ʈ ���� �Լ� 
            AutoFlipScript.instance.OpenNote();

            // ���� ��ư Ȱ��ȭ 
            CombinationButtonScript.Instance.comBtn.gameObject.SetActive(true);           
        }
    }

    void Update()
    {

    }
}
