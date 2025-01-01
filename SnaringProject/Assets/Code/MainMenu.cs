using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject Grid;
    public GameObject Option;
    public GameObject Title;
    public GameObject MainStuff;
    public GameObject BlueWin;
    public GameObject RedWin;
    public GameObject GameSet;

    void Update()
    {
        // �¸� �÷��� ������ ���� ȭ��
        if(GamePlay.WinFlag == 1)
        {
            GameSet.SetActive(true);
            BlueWin.SetActive(true);
        }
        if(GamePlay.WinFlag == 2)
        {
            GameSet.SetActive(true);
            RedWin.SetActive(true);
        }
    }

    // ���� ����
    public void startButton()
    {
        MainStuff.SetActive(false);
        Title.SetActive(false);
        Grid.SetActive(true);
    }

    // �ɼ� ��ư
    public void optionButton()
    {
        MainStuff.SetActive(false);
        Option.SetActive(true);
    }

    // �ɼ� �ڷ�
    public void optionBackButton()
    {
        MainStuff.SetActive(true);
        Option.SetActive(false);
    }

    // �������� �� ���θ޴���
    public void BackButtion()
    {   
        GamePlay.WinFlag = 0;
        Grid.SetActive(false);
        MainStuff.SetActive(true);
        Title.SetActive(true);
        RedWin.SetActive(false);
        BlueWin.SetActive(false);
        GameSet.SetActive(false);
    }
}