using UnityEngine;
using System.Collections;

public class BrightneessRegulator : MonoBehaviour {

    private Material myMaterial;
    public ScoreController score;

    private float minEmission = 0.3f;
    private float magEmission = 2.0f;
    private int speed = 10;
    private int degree = 0;

    Color defaultColor = Color.white;

	// Use this for initialization
	void Start () {
        if(tag == "SmallStarTag"){
            this.defaultColor = Color.white;
        }else if(tag == "LargeStarTag"){
            this.defaultColor = Color.yellow;
        }else if(tag == "SmallCloudTag" || tag == "LargeCloudTag"){
            this.defaultColor = Color.blue;
        }
        this.myMaterial = GetComponent<Renderer>().material;
        myMaterial.SetColor("_EmissionColor", this.defaultColor * minEmission);
        score.Score = 0;
        score.ScoreControllerStart();

	}

	// Update is called once per frame
	void Update () {
        if(this.degree >= 0){
            Color emissionColor = this.defaultColor * (this.minEmission + Mathf.Sin(this.degree * Mathf.Deg2Rad) * this.magEmission);
            myMaterial.SetColor("_EmissionColor", emissionColor);
            this.degree -= this.speed;
        }
	}

    public void OnCollisionEnter(Collision other){
        this.degree = 180;
        score.TagCollision(tag);

    }

}
