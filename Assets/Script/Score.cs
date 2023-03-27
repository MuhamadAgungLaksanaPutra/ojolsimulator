using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI pointText;

    private int point;

    void Start ()
    {
        point = 0;

        SetCountText ();
    }

    void OnTriggerEnter(Collider player) 
	{
		if (player.gameObject.CompareTag ("Motor"))
		{
            point = point + 1;

            SetCountText ();
        }
    }

    void SetCountText()
	{
		pointText.text = "Point: " + point.ToString();
	}
/*
    public Text scoreText;

    int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString() + "POINTS";
    }

   public void AddPoint()
   {
       score += 1;
   }
*/
}
