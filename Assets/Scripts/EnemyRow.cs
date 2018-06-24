using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRow : MonoBehaviour {
    [HideInInspector]
    public float _horizontalMoveMultiplier = 0.3f;

    private GameObject _smallEnemyPrefab;
    private GameObject _bigEnemyPrefab;

    private float _horizontalLength;
    private float _enemyDistance;
    private Vector3 _spawnStartingPosition;
    private float _horizontalMoveTimer = 0.0f;

	private void Start()
	{
        print(GameController.Instance.GameBoundaries.Up);
        transform.position = new Vector3(0.0f, 0.0f, GameController.Instance.GameBoundaries.Up);
        _horizontalLength = GameController.Instance.GameBoundaries.Right - GameController.Instance.GameBoundaries.Left;
        // Add two more empty columns so the enemies could move around in the row
        _enemyDistance = _horizontalLength / (GameController.Instance.EnemyColumnNumer + 2);
        _spawnStartingPosition = new Vector3(GameController.Instance.GameBoundaries.Left + _enemyDistance * 1.5f, 0, GameController.Instance.GameBoundaries.Up);

        _smallEnemyPrefab = Resources.Load("Enemy-Small") as GameObject;
        _bigEnemyPrefab = Resources.Load("Enemy-Big") as GameObject;
        SpawnEnemies();
	}


    private void SpawnEnemies() {
        for (int i = 0; i < GameController.Instance.EnemyColumnNumer; i++)
        {
            Enemy newEnemy;
            if (Random.value > GameController.Instance.BigEnemyAppearingChance)
            {
                newEnemy = Instantiate(_smallEnemyPrefab, _spawnStartingPosition + Vector3.right * _enemyDistance * i, Quaternion.identity).GetComponent<Enemy>();
            } else 
            {
                newEnemy = Instantiate(_bigEnemyPrefab, _spawnStartingPosition + Vector3.right * _enemyDistance * i, Quaternion.identity).GetComponent<Enemy>();
            }
            if (newEnemy != null)
            {
                newEnemy.transform.parent = transform;
                newEnemy.Column = i;
                EnemyController.Instance.AddEnemy(newEnemy.GetComponent<Enemy>());
            }
        }
    }


	// Update is called once per frame
	void Update () {
        // Approching to the player
        transform.Translate(-Vector3.forward * GameController.Instance.EnemyForwardSpeed * Time.deltaTime);

        //Move horizontally
        _horizontalMoveTimer += Time.deltaTime;
        Vector3 pos = transform.position;
        transform.position = new Vector3(Mathf.Sin(_horizontalMoveTimer * _horizontalMoveMultiplier) * _enemyDistance, pos.y, pos.z);

        //Incase overflow
        if (_horizontalMoveTimer > 1000f) {
            _horizontalMoveTimer = 0.0f;
        }
	}
}
