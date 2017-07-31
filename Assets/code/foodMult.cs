using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodMult : MonoBehaviour {

    public float mult;
    public float speedOfDrain   ;
    private MeshRenderer myMesh;


    public flowerManager flowMan;

	// Use this for initialization
	void Start () {
		



	}
	
	// Update is called once per frame
	void Update () {
		
        if (mult < 1f)
        {
            myMesh = this.gameObject.GetComponent<MeshRenderer>();
            myMesh.material.color = Color.black;
        }

	}
}
