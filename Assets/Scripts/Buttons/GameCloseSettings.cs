using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameCloseSettings : MonoBehaviour
{
    public GameObject menu;
    void Start()
    {
        Button closeSettings = gameObject.GetComponent<Button>();
        closeSettings.onClick.AddListener(TaskOnClick);
    }
    void TaskOnClick()
    {
        Debug.Log("Close Settings gedrückt");
        GameObject settingsMenu = GameObject.FindGameObjectWithTag("MenuSettings");
        GameObject.Instantiate(menu);
        Destroy(settingsMenu);
    }
}
