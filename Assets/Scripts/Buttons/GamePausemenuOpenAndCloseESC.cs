using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePausemenuOpenAndCloseESC : MonoBehaviour
{
    public GameObject menuTemplate;
    public bool menuOn;

    private void Start()
    {
        menuOn = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !(menuOn))
        {
            Debug.Log("ESC gedrückt, menuOn == false");
            Time.timeScale = 0;
            GameObject menu = Instantiate(menuTemplate);
            menuOn = true;
            return;

        }

        if (Input.GetKeyDown(KeyCode.Escape) && menuOn)
        {
            Debug.Log("ESC gedrückt, menuOn == true");
            GameObject menu = GameObject.FindGameObjectWithTag("Menu");
            GameObject settingsMenu = GameObject.FindGameObjectWithTag("MenuSettings");
            Destroy(settingsMenu);
            Destroy(menu);
            menuOn = false;
            Time.timeScale = 1;
            return;
        }

    }
}
