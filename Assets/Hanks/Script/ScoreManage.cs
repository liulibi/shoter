using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManage : MonoBehaviour
{

    public static int Score;
    public Text ScoreText;

	// Use this for initialization
	void Start ()
	{
	    Score = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
        ScoreText.text = "Score:" + Score;
	}
}
