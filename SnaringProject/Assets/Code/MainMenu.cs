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
        { //ESC를 눌렀을때
            if (isOption)
            {
                optionBackButton();
            }
            else
            {
                optionButton();
            }
        }
        // 승리 플래그 판정시 종료 화면
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

    // 게임 시작
    public void startButton()
    {
        MainStuff.SetActive(false);
        Title.SetActive(false);
        Grid.SetActive(true);
        isGameStart = true;
    }

    // 옵션 버튼
    public void optionButton()
    {
        MainStuff.SetActive(false);
        Option.SetActive(true);
        if(isGameStart) addOption.SetActive(true);
        isOption = true;
        GamePlay.isGamePaused = true;
    }

    // 옵션 뒤로
    public void optionBackButton()
    {
        if(!isGameStart) MainStuff.SetActive(true);
        addOption.SetActive(false);
        Option.SetActive(false);
        isOption = false;
        GamePlay.isGamePaused = false;
    }

    // 메인메뉴로
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

    // 게임종료 후 재시작
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