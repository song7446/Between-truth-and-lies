using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Scene1Script : MonoBehaviour
{
    public string scriptCollection(int num)
    {
        string scriptText = "";
        switch (num)
        {
            case 0:
                scriptText = "���̽��ϱ� �����";
                break;
            case 1:
                scriptText = "�׷� ���� ������ ������ ��.";
                break;
            case 2:
                scriptText = "������ ����� �ƴմϴ�.";
                break;
            case 3:
                scriptText = "�� ���� ��� ���� �ƹ����� �����߽��ϴ�.";
                break;
            case 4:
                scriptText = "�Ű�� ���� ����?";
                break;
            case 5:
                scriptText = "�װ� �� ������ �߽��ϴ�.";
                break;
            case 6:
                scriptText = "���ݱ��� �����غ� �ٷδ�";
                break;
            case 7:
                scriptText = "��� �����ð� ������ ���ݱ��� ���忡 �ִ� ����� �����ڿ� ������ �ѻ��̰�";
                break;
            case 8:
                scriptText = "ħ���� ������ ���µ��ٰ�";
                break;
            case 9:
                scriptText = "��⿡�� ���� �������� ���� ���¶󼭿�.";
                break;
            case 10:
                scriptText = "�ƹ����� �����ϰ� �ٷ� �ڼ���...";
                break;
            case 11:
                scriptText = "�׷��� �װ�...";
                break;
            case 12:
                scriptText = "��";
                break;
            case 13:
                scriptText = "���� Ư���� ���� �־���?";
                break;
            case 14:
                scriptText = "�����ڰ� ���ϱ�δ� ";
                break;
            case 15:
                scriptText = "�ڽ��� ������ �͵� �°� �ڼ��ϴ� �͵� �´ٰ� �ϴµ�";
                break;
            case 16:
                scriptText = "����ô���� ������ ������ �ʽ��ϴ�.";
                break;
            case 17:
                scriptText = "�׳� �ڽ��� �� ���̶�� �� �ܿ��� �ƹ� ��⵵ ���մϴ�.";
                break;
            case 18:
                scriptText = "���𰡸� ����� �ֱ�.";
                break;
            case 19:
                scriptText = "�׸��� �� �ϳ� �̻��� ���� �ֽ��ϴ�.";
                break;
            case 21:
                scriptText = "����?";
                break;
            case 22:
                scriptText = "�Ű� �ð��� ��� ��û �ð��� �� ���̰� ���ϴ�.";
                break;
            case 23:
                scriptText = "���ŵ� ���Դٸ�";
                break;
            case 24:
                scriptText = "���̴� �� ���� ���� �ִ� �� �ƴѰ�";
                break;
            case 25:
                scriptText = "�׷����� ������ �����ڰ� ���� ��⸦ �������� �ʾƼ� �� ���� �����ϴ�";
                break;
            case 26:
                scriptText = "��...";
                break;
            case 27:
                scriptText = "���� ���⵵ ��������� �ʾ���?";
                break;
            case 28:
                scriptText = "�׷��� �ѵ� ��Ȳ�� �������� ������ ���Դϴ�.";
                break;
            case 29:
                scriptText = "...";
                break;
            case 30:
                scriptText = "���� �γ������ ���� �ʾҳ�?";
                break;
            case 31:
                scriptText = "�½��ϴ�.";
                break;
            case 32:
                scriptText = "����...";
                break;
        }

        return scriptText;
    }

    public string nameCollection(int num)
    {
        string name = "";

        string juniorDetective = "�Ĺ� ����";
        string protagonist = "���ΰ�";

        switch (num)
        {
            case 0:
                name = juniorDetective;
                break;
            case 1:
                name = protagonist;
                break;
            case 2:
                name = juniorDetective;
                break;
            case 3:
                name = juniorDetective;
                break;
            case 4:
                name = protagonist;
                break;
            case 5:
                name = juniorDetective;
                break;
            case 6:
                name = juniorDetective;
                break;
            case 7:
                name = juniorDetective;
                break;
            case 8:
                name = juniorDetective;
                break;
            case 9:
                name = juniorDetective;
                break;
            case 10:
                name = protagonist;
                break;
            case 11:
                name = juniorDetective;
                break;
            case 12:
                name = protagonist;
                break;
            case 13:
                name = protagonist;
                break;
            case 14:
                name = juniorDetective;
                break;
            case 15:
                name = juniorDetective;
                break;
            case 16:
                name = juniorDetective;
                break;
            case 17:
                name = juniorDetective;
                break;
            case 18:
                name = protagonist;
                break;
            case 19:
                name = juniorDetective;
                break;
            case 21:
                name = protagonist;
                break;
            case 22:
                name = juniorDetective;
                break;
            case 23:
                name = protagonist;
                break;
            case 24:
                name = protagonist;
                break;
            case 25:
                name = juniorDetective;
                break;
            case 26:
                name = protagonist;
                break;
            case 27:
                name = protagonist;
                break;
            case 28:
                name = juniorDetective;
                break;
            case 29:
                name = protagonist;
                break;
            case 30:
                name = protagonist;
                break;
            case 31:
                name = juniorDetective;
                break;
            case 32:
                name = protagonist;
                break;
        }

        return name;
    }
}

