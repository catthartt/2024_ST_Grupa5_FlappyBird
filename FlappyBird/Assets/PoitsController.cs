using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PoitsController : MonoBehaviour
{
    public TextMeshProUGUI textField;
    public BirdController birdController;
    public bool isHighscore;

    // Start is called before the first frame update
    void Start()
    {
        textField.text = "0";
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isHighscore)
        {
            textField.text = PlayerPrefs.GetInt("Highscore").ToString();
        }
        else
        {
            textField.text = birdController.Points.ToString();
        }
    }
}
