using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public float minX;
	public float maxX;
	public bool autoPlay = false;

	private Ball ball;

	void Start(){
		ball = GameObject.FindObjectOfType<Ball> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!autoPlay) {
			MoveWithMouse ();
		} else {
			AutoPlay();
		}
	}

	void AutoPlay(){
		Vector3 paddlePos = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z);
		Vector3 ballPos = ball.transform.position;
		paddlePos.x = Mathf.Clamp (ballPos.x, minX, maxX);
		this.transform.position = paddlePos;
		
	}

	void MoveWithMouse(){
		Vector3 paddlePos = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z);
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
		paddlePos.x = Mathf.Clamp (mousePosInBlocks, minX, maxX);
		this.transform.position = paddlePos;
	}
}
