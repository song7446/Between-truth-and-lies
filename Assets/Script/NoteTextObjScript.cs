using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteTextObjScript : MonoBehaviour
{
    public static NoteTextObjScript instance;

    private void Awake()
    {
        if (NoteTextObjScript.instance == null)
        {
            NoteTextObjScript.instance = this;
        }
    }

    Dictionary<string, string> noteWrites = new Dictionary<string, string>()
    {
        { "�� ���� ��� ���� �ƹ����� �����߽��ϴ�.","���� �ƹ����� ������" },
        { "�װ� �� ������ �߽��ϴ�.","�� ������ ���� �Ű���" },
        { "��� �����ð� ������ ���ݱ��� ���忡 �ִ� ����� �����ڿ� ������ �ѻ��̰�","���忡 �ִ� ����� �����ڿ� ������ �ѻ���" },
        { "ħ���� ������ ���µ��ٰ�","ħ���� ������ ����" },
        { "��⿡�� ���� �������� ���� �����Դϴ�.","��⿡�� �������� �������� �����" },
        { "�ڽ��� ������ �͵� �°� �ڼ��ϴ� �͵� �´ٰ� �ϴµ�","�����ڴ� �ڽ��� ������ ������" },
        { "��ü������ ��� �������� �ʽ��ϴ�.","�����ڴ� �ڽ��� ������ ���������� ������� �����" },
        { "�׳� �ڽ��� �� ���̶�� �� �ܿ��� �ƹ� ��⵵ ���մϴ�.","�����ڴ� �ڽ��� ������ ���������� ������� �����" },
        { "�Ű� �ð��� ��� ��û �ð��� �� ���̰� ���ϴ�.","�Ű� �ð��� ��������ð��� ���̰� ����" },
        { "�׷��� �ѵ� ��Ȳ�� ���������� ���Դϴ�.","���� ����� ���������� ����" },
    };


    public GameObject noteTxtObj;

    public GameObject leftTextObj;

    public GameObject textObj;

    public GameObject loadTextObj;
    public GameObject noteTextObj;

    public Text talkName;
    public Text talkText;

    public bool updateNoteText(GameObject obj)
    {
        talkName = obj.transform.GetChild(0).gameObject.GetComponent<Text>();
        talkText = obj.transform.GetChild(1).gameObject.GetComponent<Text>();

        if (noteWrites.ContainsKey(talkText.text)) 
        {
            loadTextObj = Resources.Load<GameObject>("PreFab/NoteText");
            noteTextObj = GameObject.Instantiate<GameObject>(loadTextObj);

            noteTextObj.transform.SetParent(leftTextObj.transform, false);

            noteTextObj.name = talkText.text;
            noteTextObj.GetComponent<Text>().text = talkName.text + "�� ���ϸ� " + noteWrites[talkText.text];

            return true;
        }
        else
        {
            return false;
        }       
    }

    public void deleteNoteText(GameObject obj)
    {
        textObj = GameObject.Find(obj.transform.GetChild(1).gameObject.GetComponent<Text>().text);
        Destroy(textObj);
    }

    void Start()
    {
        noteTxtObj.SetActive(false);
    }


    void Update()
    {
        
    }
}
