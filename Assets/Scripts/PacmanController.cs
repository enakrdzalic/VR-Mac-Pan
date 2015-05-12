using UnityEngine;
using System.Collections;

public class PacmanController : MonoBehaviour {
		
		private int result;
		public GUIText resultText;
		public GUIText winText;
		public GUIText loseText;
		public GUIText timerText;
	public GUIText startText;
		public float distance;
		private bool isOver;
		private float timer;
		private bool isStarted;
	private float startTimer;
	public GameObject[] ghosts;
	public AudioSource[] sounds;
	public int numPickups;
		
		
		void Start() {
			result = 0;
			resultStringText();
			winText.text = "";	
			loseText.text = "";
			timerText.text = "";
			isOver = false;
			timer = 6;
			isStarted = false;
			startTimer = 4;
			startText.text = "";
		for (int i = 0 ; i < ghosts.Length ; i++) {
			ghosts[i].SetActive(false);
		}
		}
		void FixedUpdate() {
			if (!isStarted) {

				if (startTimer > 1) {
					startText.text = ((int)startTimer).ToString ();
					startTimer -= Time.deltaTime;
					return;
			} else if (startTimer > 0) {
				startText.text = "Go!";
				startTimer -= Time.deltaTime;
				return;
			} else {
				for (int i = 0 ; i < ghosts.Length ; i++) {
					ghosts[i].SetActive(true);
				}
				isStarted = true;
				startText.text = "";
			}
		}
			else if (isOver) {
				if (timer > 1) {
				timerText.text = ((int)timer).ToString ();
				timer -= Time.deltaTime;
				return;
			} else Application.LoadLevel("Main Menu");
		} else transform.position = transform.position + Camera.main.transform.forward * distance * Time.deltaTime;
		}
		
		void OnTriggerEnter(Collider other) {
			if (other.gameObject.tag == "Pickup") {
				other.gameObject.SetActive (false);
				sounds[0].Play();
				result++;
				resultStringText();
			}
			if (other.gameObject.tag == "Sprite") {
				if (!isOver) {
				sounds[1].Play();
				loseText.text = "You lose!";
				isOver = true;
				}
		}
			
		}
		
		void resultStringText() {
		resultText.text = "Remaining: " + (numPickups-result).ToString();
			if (result >= numPickups) {
				winText.text = "You win!";
				isOver = true;
			}
		}

}
