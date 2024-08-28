using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Scene1Script : MonoBehaviour
{
    public static Scene1Script instance;
    public bool storyEnd = false;
    private void Awake()
    {
        if (Scene1Script.instance == null)
        {
            Scene1Script.instance = this;

        }
    }


    // ��#1 ���丮 ��ũ��Ʈ
    public string ScriptCollection(int num)
    {
        string scriptText = "";


        string[] storyScript = {"�̰��ΰ�?", "���̽��ϱ� �����", "�׷� ���� ������ ������ ��.", "������ ����� �ƴմϴ�.", "�� ���� ��� ���� �ƹ����� �����߽��ϴ�.", "�Ű�� ���� ����?", "�װ� �� ������ �߽��ϴ�.",
                                "�ƹ����� �����ϰ� �ٷ� �ڼ��Ѱǰ�...", "���ݱ��� �����غ� �ٷδ�", "��� �����ð� ������ ���ݱ��� ���忡 �ִ� ����� �����ڿ� ������ �ѻ��̰�", "ħ���� ������ ���µ��ٰ�",
                                "��⿡�� ���� �������� ���� �����Դϴ�.","�׷� ���� ���� �� �ƴѰ�?","�� �̷��� ����� ����?" ,"�װ�...", "�� ���� Ư���� ���� �־���?", "�����ڰ� ���ϱ�δ�",
                                "�ڽ��� ������ �͵� �°� �ڼ��ϴ� �͵� �´ٰ� �ϴµ�", "��ü������ ��� �������� �ʽ��ϴ�.", "�׳� �ڽ��� �� ���̶�� �� �ܿ��� �ƹ� ��⵵ ���մϴ�.","��..." ,"���𰡸� ����� �ֱ�.",
                                "�׸��� ��...","����?" , "�Ű� �ð��� ��� ��û �ð��� �� ���̰� ���ϴ�.","���ŵ� ���Դٸ�" , "�������� ���� �ƴ� ���� �ִ� �� �ƴѰ�" ,
                                "�׷����� ������ �����ڰ� ���� ��⸦ �������� �ʾƼ� �� ���� �����ϴ�", "��..." , "���� ���⵵ ��������� �ʾ���?" , "�׷��� �ѵ� ��Ȳ�� ���������� ���Դϴ�." ,
                                "..." , "���� �γ������ ���� �ʾҳ�?" , "�½��ϴ�.", "����...", "������� ��ġ ������..." };
        try
        {
            scriptText = storyScript[num];
        }
        catch (IndexOutOfRangeException)
        {
            storyEnd = true;
        }

        return scriptText;
    }

    // ��#1 ȭ�� �̸� ��ũ��Ʈ
    public string NameCollection(int num)
    {
        string name = "";
        string[] nameScript = { "���ΰ�", "�Ĺ� ����", "���ΰ�", "�Ĺ� ����", "�Ĺ� ����", "���ΰ�", "�Ĺ� ����",
                                "���ΰ�","�Ĺ� ����", "�Ĺ� ����","�Ĺ� ����",
                                "�Ĺ� ����","���ΰ�","���ΰ�", "�Ĺ� ����","���ΰ�" ,"�Ĺ�����",
                                "�Ĺ� ����","�Ĺ� ����","�Ĺ� ����","���ΰ�","���ΰ�",
                                "�Ĺ� ����", "���ΰ�","�Ĺ� ����","���ΰ�","���ΰ�",
                                "�Ĺ� ����","���ΰ�","���ΰ�","�Ĺ� ����",
                                "���ΰ�", "���ΰ�","�Ĺ� ����","���ΰ�","���ΰ�"};
        try
        {
            name = nameScript[num];
        }
        catch (IndexOutOfRangeException)
        {
            storyEnd = true;
        }

        return name;
    }
}

