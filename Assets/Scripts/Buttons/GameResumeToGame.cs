using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameResumeToGame : MonoBehaviour
{
    void Start()
    {
        Button resume = gameObject.GetComponent<Button>();
        resume.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        GameObject controller = GameObject.FindGameObjectWithTag("GameController");
        GameObject menu = GameObject.FindGameObjectWithTag("Menu");
        GamePausemenuOpenAndCloseESC menuSkrip = controller.GetComponent<GamePausemenuOpenAndCloseESC>();
        menuSkrip.menuOn = false;
        Destroy(menu);
        Time.timeScale = 1;
    }
}
