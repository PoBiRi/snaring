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
    public GameObject addOption;

    private bool isOption = false;
    private bool isGameStart = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        { //ESC�� ��������
            if (isOption)
            {
                optionBackButton();
            }
            else
            {
                optionButton();
            }
        }
        // �¸� �÷��� ������ ���� ȭ��
        if (GamePlay.WinFlag == 1)
        {
            GameSet.SetActive(true);
            BlueWin.SetActive(true);
            GamePlay.isGamePaused = true;
        }
        if(GamePlay.WinFlag == 2)
        {
            GameSet.SetActive(true);
            RedWin.SetActive(true);
            GamePlay.isGamePaused = true;
        }
    }

    // ���� ����
    public void startButton()
    {
        MainStuff.SetActive(false);
        Title.SetActive(false);
        Grid.SetActive(true);
        isGameStart = true;
    }

    // �ɼ� ��ư
    public void optionButton()
    {
        MainStuff.SetActive(false);
        Option.SetActive(true);
        if(isGameStart) addOption.SetActive(true);
        isOption = true;
        GamePlay.isGamePaused = true;
    }

    // �ɼ� �ڷ�
    public void optionBackButton()
    {
        if(!isGameStart) MainStuff.SetActive(true);
        addOption.SetActive(false);
        Option.SetActive(false);
        isOption = false;
        GamePlay.isGamePaused = false;
    }

    // ���θ޴���
    public void BackButtion()
    {   
        GamePlay.WinFlag = 0;
        optionBackButton();
        Grid.SetActive(false);
        MainStuff.SetActive(true);
        Title.SetActive(true);
        RedWin.SetActive(false);
        BlueWin.SetActive(false);
        GameSet.SetActive(false);
        GamePlay.isGamePaused = false;
        isGameStart = false;
    }

    // �������� �� �����
    public void RestartButtion()
    {
        GamePlay.WinFlag = 0;
        optionBackButton();
        RedWin.SetActive(false);
        BlueWin.SetActive(false);
        GameSet.SetActive(false);
        GamePlay.isGamePaused = false;
    }
}