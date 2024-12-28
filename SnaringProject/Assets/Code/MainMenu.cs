using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject Grid;
    public GameObject Option;
    public GameObject MainStuff;

    public void startButton()
    {
        GameObject tempObj = null;
        MainStuff.SetActive(false);
        tempObj = GameObject.Find("Title");
        tempObj.SetActive(false);
        Grid.SetActive(true);
    }

    public void optionButton()
    {
        MainStuff.SetActive(false);
        Option.SetActive(true);
    }

    public void optionBackButton()
    {
        MainStuff.SetActive(true);
        Option.SetActive(false);
    }
}