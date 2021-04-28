using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameBackToStartmenu : MonoBehaviour
{
    void Start()
    {
        Button end = gameObject.GetComponent<Button>();
        end.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Start Menu");
    }
}
