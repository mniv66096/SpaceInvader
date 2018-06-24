using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour {
    public GameObject DeadExplosionPrefab;
    public GameObject EnemyBulletPrefab;

    public int KillingPoint;
    public float BulletSpeed;

    [HideInInspector]
    public int Column;

    private Animator _animator;

	private void Start()
	{
        _animator = GetComponentInChildren<Animator>();
	}

	public void Fire() {
        if (_animator != null) {
            _animator.SetTrigger("Attack");
        }

        Bullet bullet = Instantiate(EnemyBulletPrefab, transform.position, Quaternion.identity).GetComponent<Bullet>();
        bullet.Speed = BulletSpeed * -Vector3.forward;
    }

	private void OnTriggerEnter(Collider other)
	{
        if (other.CompareTag("PlayerBullet")) {
            Instantiate(DeadExplosionPrefab, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            EnemyController.Instance.RemoveEnemy(this);
            Destroy(gameObject);
        }
	}
}
