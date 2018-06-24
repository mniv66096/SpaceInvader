using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyColumn {
    private List<Enemy> _enemies = new List<Enemy>();

    public void AddEnemy (Enemy enemy) {
        _enemies.Add(enemy);
    }

    public void RemoveEnemy(Enemy enemy) {
        _enemies.Remove(enemy);
    } 

    //Make sure only the enemy in the front line could fire the bullet
    public void Fire() {
        if (_enemies.Count > 0)
        {
            _enemies[0].Fire();
        }
    }
}

public class EnemyController : MonoBehaviour {
    public static EnemyController Instance;

    [HideInInspector]
    /// <summary>
    /// The enemy columns counted from the left;
    /// </summary>
    public List<EnemyColumn> EnemyColumns = new List<EnemyColumn>();

    private float _fireTimer = 0.0f;
    private float _spawnTimer = 0.0f;

	private void Awake()
	{
        if (Instance == null) {
            Instance = this;
        } else if (Instance != this)
        {
            Destroy(this);
        }
	}

	private void Start()
	{
        SpawnRow();
	}

	public void AddEnemy (Enemy enemy) {
        while (enemy.Column >= EnemyColumns.Count) {
            EnemyColumns.Add(new EnemyColumn());
        }
        EnemyColumns[enemy.Column].AddEnemy(enemy);
    }

    public void RemoveEnemy (Enemy enemy) {
        EnemyColumns[enemy.Column].RemoveEnemy(enemy);
    }

	public void RandomFire() {
        EnemyColumns[Random.Range(0, EnemyColumns.Count - 1)].Fire();
    }

    public void SpawnRow() {
        GameObject row = new GameObject("EnemyRow", typeof(EnemyRow));
    }

	private void Update()
	{
        _fireTimer += Time.deltaTime;
        _spawnTimer += Time.deltaTime;

        if (_fireTimer > GameController.Instance.EnemyShootingInterval) {
            RandomFire();
            _fireTimer = 0.0f;
        }

        if (_spawnTimer > GameController.Instance.EnemySpawnInterval) {
            SpawnRow();
            _spawnTimer = 0.0f;
        }
	}
}
