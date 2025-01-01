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
        // 승리 플래그 판정시 종료 화면
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

    // 게임 시작
    public void startButton()
    {
        MainStuff.SetActive(false);
        Title.SetActive(false);
        Grid.SetActive(true);
    }

    // 옵션 버튼
    public void optionButton()
    {
        MainStuff.SetActive(false);
        Option.SetActive(true);
    }

    // 옵션 뒤로
    public void optionBackButton()
    {
        MainStuff.SetActive(true);
        Option.SetActive(false);
    }

    // 게임종료 후 메인메뉴로
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