using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        GetComponent<Text>().text = "Breaking points: " + GameController.Instance.Score;
	}
}
