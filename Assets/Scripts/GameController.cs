using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct Boundaries {
    public float Up, Down, Left, Right;
}

public class GameController : MonoBehaviour {
    public static GameController Instance;

    [HideInInspector]
    public Boundaries GameBoundaries;

    [Header("Player Settings")]
    [Range(5.0f, 10.0f)]
    public float SpaceShipSpeed;

    [Header("Enemy Settings")]
    [Tooltip("Interval in second for the spawn of another row of enemies")]
    [Range(1.0f, 10.0f)]
    public float EnemySpawnInterval;

    [Range(0.0f, 1.0f)]
    public float BigEnemyAppearingChance;

    [Tooltip("Interval in second for the enemies to fire another bullet")]
    [Range(0.5f, 5.0f)]
    public float EnemyShootingInterval;

    [Range(2, 6)]
    public int EnemyColumnNumer;

    [Range(0.5f, 2.0f)]
    public float EnemyForwardSpeed;


    [Header("UI")]
    public Text ScoreBoard;

    [HideInInspector]
    public int GameScore = 0;

    public void OnEnemyKilledAction (Enemy enemy) {
        GameScore += enemy.KillingPoint;
        ScoreBoard.text = GameScore.ToString();
    }

    public void OnPlayerKilledAction () {
        if (GameScore > PlayerPrefs.GetInt("HighestScore")) {
            PlayerPrefs.SetInt("HighestScore", GameScore);
        }
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("StartScene", UnityEngine.SceneManagement.LoadSceneMode.Single);
    }

    private void Awake()
    {
        //Singleton
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this);
        }
	}

	private void Start()
	{
        PlayerPrefs.SetInt("PlayTimes", PlayerPrefs.GetInt("PlayTimes") + 1);
        PlayerSpaceShip.Instance.OnPlayerKilled += OnPlayerKilledAction;
	}
}
