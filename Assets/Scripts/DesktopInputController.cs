using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesktopInputController : MonoBehaviour {
	
	void FixedUpdate () {
        //Check Movement Input
        PlayerSpaceShip.Instance.HorizontalMove(Input.GetAxis("Horizontal"));

        //Check Fire Input
        if (Input.GetKey("space")) {
            PlayerSpaceShip.Instance.Fire();
        }
	}
}
