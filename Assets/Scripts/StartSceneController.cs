using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StartSceneController : MonoBehaviour {
    public Text TotalPlayTimes;
    public Text HighestScore;

	private void Start()
	{
        TotalPlayTimes.text = TotalPlayTimes.text + PlayerPrefs.GetInt("PlayTimes");
        HighestScore.text = HighestScore.text + PlayerPrefs.GetInt("HighestScore"); 
	}

    public void LoadLevel(string name) {
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(name, UnityEngine.SceneManagement.LoadSceneMode.Single);
    }
}
