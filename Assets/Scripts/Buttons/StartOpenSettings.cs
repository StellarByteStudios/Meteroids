using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartOpenSettings : MonoBehaviour
{
    public GameObject settingsMenu;

    void Start()
    {
        Button openSettings = gameObject.GetComponent<Button>();
        openSettings.onClick.AddListener(TaskOnClick);
    }
    void TaskOnClick()
    {
        Debug.Log("Open Settings gedrückt");
        GameObject scoreBoard = GameObject.FindGameObjectWithTag("ScoreBoard");
        GameObject mainMenu = GameObject.FindGameObjectWithTag("Menu");
        GameObject.Instantiate(settingsMenu);
        Destroy(mainMenu);
        Destroy(scoreBoard);
    }
}
