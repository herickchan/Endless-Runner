using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {
	
    public GameObject score;
    public GameObject highscore;
    public GameObject panel;
    public GameObject startScreen;
    public GameObject startButton;
    public GameObject finalScoreNum;
    public GameObject finalScore;

	void Update () {
        if (DataManagement.dataManage.gameOn) {
            score.SetActive (true);
            highscore.SetActive (true);
            panel.SetActive (true);
            startScreen.SetActive (false);
            startButton.SetActive (false);
            finalScore.SetActive (false);
            finalScoreNum.SetActive (false);

	        score.GetComponent<Text>().text = ("Score: " + DataManagement.dataManage.score);
            highscore.GetComponent<Text>().text = ("High Score: " + DataManagement.dataManage.highScore);
        } else if (DataManagement.dataManage.playerDed) {
            score.SetActive (false);
            highscore.SetActive (false);
            panel.SetActive (false);
            finalScore.SetActive (true);
            finalScoreNum.SetActive (true);
            startButton.SetActive (true);

            finalScoreNum.GetComponent<Text>().text = ("" + DataManagement.dataManage.score);
        } else {
            score.SetActive (false);
            highscore.SetActive (false);
            panel.SetActive (false);
            finalScore.SetActive (false);
            finalScoreNum.SetActive (false);
        }
	}
}
