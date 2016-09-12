using UnityEngine;
using UnityEngine.UI;


public class ScoreController : MonoBehaviour {

    private GameObject scoreText;
    public int Score;

    // Use this for initialization
    public void ScoreControllerStart () {
       this.scoreText = GameObject.Find("ShowScore");
       this.scoreText.GetComponent<Text>().text = Score.ToString();
    }

    public void TagCollision(string n){
        if(n == "SmallStarTag"){
            this.Score += 1;
        }else if(n == "LargeStarTag"){
            this.Score += 5;
        }else if(n == "SmallCloudTag"){
            this.Score += 10;
        }else if(n == "LargeCloudTag"){
            this.Score += 20;
        }
        this.scoreText.GetComponent<Text>().text = Score.ToString();

    }

}
