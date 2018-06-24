using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipWeapon : MonoBehaviour {
    public GameObject PlayerBulletPrefab;
    public float RecoilDistance = 0.5f;
    public float BulletSpeed = 0.01f;

    private float _recoilingTimer;
    private Vector3 _defaultLocalPosition;

	private void Start()
	{
        _defaultLocalPosition = transform.localPosition;
	}

	public void Fire() {
        StopAllCoroutines();
        StartCoroutine(FireBullet());
    }

    private IEnumerator FireBullet() {
        //InitRecoilingAnimation
        _recoilingTimer = 0.0f;
        transform.localPosition = _defaultLocalPosition - Vector3.forward * RecoilDistance;

        //Init bullet
        Bullet bullet = Instantiate(PlayerBulletPrefab, transform.position, Quaternion.identity).GetComponent<Bullet>();
        bullet.Speed = Vector3.forward * BulletSpeed;

        //RecoilingAnimation
        while (_recoilingTimer < PlayerSpaceShip.Instance.FireCoolDownTime) {
            _recoilingTimer += Time.deltaTime;
            transform.localPosition = _defaultLocalPosition - Vector3.forward * Mathf.Lerp(RecoilDistance, 0.0f, _recoilingTimer/PlayerSpaceShip.Instance.FireCoolDownTime);
            yield return null;
        }
        transform.localPosition = _defaultLocalPosition;
    }

}
