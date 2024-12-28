using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject Grid;
    public void startButton()
    {
        GameObject tempObj = null;
        tempObj = GameObject.Find("MainMenu");
        tempObj.SetActive(false);
        Grid.SetActive(true);
    }
}