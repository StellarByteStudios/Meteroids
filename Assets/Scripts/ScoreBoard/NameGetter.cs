using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NameGetter : MonoBehaviour
{
    private new string name;
    public GameObject scoreBoard;
    //public GameObject scoreSystemTemplate;

    public void Start()
    {
        scoreBoard = GameObject.Find("Canvas (Enter Highscore)");
        GameObject scoreTextField = scoreBoard.transform.GetChild(0).gameObject;
        Text scoreText = scoreTextField.GetComponent<Text>();
        scoreText.text = "Game Over\nYour Score was: " + ScoreData.getScore();
        //Nach dem Tot den Ship Thrust Sound beenden (Hällt manchmal noch bis in die nächste Szene an)
        FindObjectOfType<AudioManager>().Stop("Ship Thrust");
    }

    public void ReadStringInput(string input)
    {
        name = input;
        ScoreData.setName(name);
        //GameObject table = GameObject.Instantiate(scoreSystemTemplate);
        Debug.Log(name);
        SceneManager.LoadScene("Start Menu");

    }
}
