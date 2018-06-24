using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Bullet : MonoBehaviour {
    [HideInInspector]
    public Vector3 Speed;

	private bool CheckIfOutOfBounds () {
        if (transform.position.z > GameController.Instance.GameBoundaries.Up) {
            return true;
        }

        if (transform.position.z < GameController.Instance.GameBoundaries.Down)
        {
            return true;
        }

        return false;
    }
	
	void FixedUpdate () {
        if (Speed == null) {
            Destroy(this);
        }
        transform.Translate(Speed, Space.World);

        if (CheckIfOutOfBounds()) {
            Destroy(gameObject);
        }
	}


}
