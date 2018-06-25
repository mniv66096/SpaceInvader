using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMusic : MonoBehaviour {
    public static BackGroundMusic Singleton;


	private void Awake()
	{
        if (Singleton == null) {
            Singleton = this;
        } else if (Singleton != this)
        {
            Destroy(gameObject);
        }
	}
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
	}
}
