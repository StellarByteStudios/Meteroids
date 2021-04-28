using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lifes : MonoBehaviour
{
    private Text lifesText;
    private int lifesValue;

    void Start()
    {
        lifesText = GetComponent<Text>();
        lifesValue = 3;
    }

    void Update()
    {
        lifesText.text = "Lifes: " + lifesValue;
    }

    public void addLife()
    {
        lifesValue++;
    }
    public void decLife()
    {
        lifesValue--;
    }

    public int getLife()
    {
        return lifesValue;
    }

}