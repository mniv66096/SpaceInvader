using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour {

	// Use this for initialization
	void Start () {
        UpdateGameBoundary();
	}

    private void UpdateGameBoundary () {
        if (GameController.Instance.GameBoundaries.Up < transform.position.z) 
        {
            GameController.Instance.GameBoundaries.Up = transform.position.z;
        }

        if (GameController.Instance.GameBoundaries.Down > transform.position.z)
        {
            GameController.Instance.GameBoundaries.Down = transform.position.z;
        }

        if (GameController.Instance.GameBoundaries.Right < transform.position.x)
        {
            GameController.Instance.GameBoundaries.Right = transform.position.x;
        }

        if (GameController.Instance.GameBoundaries.Left > transform.position.x)
        {
            GameController.Instance.GameBoundaries.Left = transform.position.x;
        }
    }
}
