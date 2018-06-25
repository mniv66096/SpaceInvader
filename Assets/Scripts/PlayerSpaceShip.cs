using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerSpaceShip : MonoBehaviour
{
    public static PlayerSpaceShip Instance;

    [HideInInspector]
    public float SpeedMultiplier = 1.0f;
    [HideInInspector]
    public float TiltingMultiplier = 0.5f;
    [HideInInspector]
    public float FireCoolDownTime = 0.5f;

    public delegate void PlayerKilledHandler();
    public event PlayerKilledHandler OnPlayerKilled;

    private Rigidbody _rb;
    //The spaceship is enable to fire a bullet if timer is less than zero;
    private float _fireTimer = -1f;
    private SpaceShipWeapon _weapon;

    private void Awake() {
        //Singleton
        if (Instance == null) 
        {
            Instance = this;
        } else if (Instance != this) 
        {
            Destroy(this);
        }
    }

	private void Start()
	{
        _rb = GetComponent<Rigidbody>();
        _weapon = GetComponentInChildren<SpaceShipWeapon>();
        SpeedMultiplier = GameController.Instance.SpaceShipSpeed;
	}

    /// <summary>
    /// Will fire a bullet if the cool down time is over since the last fire
    /// </summary>
    public void Fire () {
        if (_fireTimer < 0 && _weapon != null) {
            _fireTimer = 0.0f; // Start counting cool down
            _weapon.Fire();
        }
    }

	/// <summary>
	/// Move the ship to right if the speed is positive
	/// </summary>
	public void HorizontalMove (float inputSpeed) {
        _rb.velocity = Vector3.right * inputSpeed * SpeedMultiplier;
        _rb.rotation = Quaternion.Euler(0.0f, 0.0f, - inputSpeed * TiltingMultiplier);
    }

	private void Update()
	{
        if (_fireTimer >= 0) {
            _fireTimer += Time.deltaTime;
            if (_fireTimer > FireCoolDownTime) {
                _fireTimer = -1f;
            }
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyBullet") || other.CompareTag("Enemy")) {
            if (OnPlayerKilled != null) {
                OnPlayerKilled.Invoke();
            }
        }
	}
}
