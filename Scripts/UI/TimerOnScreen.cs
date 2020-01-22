using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimerOnScreen : MonoBehaviour
{
	public Text scoreText;
    public bool isVisible;


    void Start()
    {
		InvokeRepeating("RunTimer", 1, 1);
    }

    void Update()
    {

    }
	
		void RunTimer() {
		scoreText.text = (int.Parse(scoreText.text) - 1).ToString();
	}

}