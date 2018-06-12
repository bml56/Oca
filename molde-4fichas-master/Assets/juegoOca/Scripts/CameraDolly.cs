using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDolly : MonoBehaviour {

	// Use this for initialization
	void Start () {
        theStateManager = GameObject.FindObjectOfType<StateManager>();
        stone = GameObject.FindObjectsOfType<PlayerStone>();
        distancia = new float[stone.Length];
        baseCamara = this.transform.position;// posicion inicial de la camara
        Debug.Log("numero piedras" + stone.Length);
	}

    StateManager theStateManager;
    PlayerStone [] stone;
    Vector3 baseCamara;

    public float PivotAngle = 35f;
    float pivotVelocity;
   float [] distancia;
	// Update is called once per frame
	void Update () {
       
        float theAngle = this.transform.rotation.eulerAngles.y;
        if(theAngle > 180)
            theAngle -= 360f;

        theAngle = Mathf.SmoothDamp( 
            theAngle, 
            (theStateManager.CurrentPlayerId==0 ? PivotAngle : -PivotAngle), 
            ref pivotVelocity, 
            0.25f );

            this.transform.position = baseCamara+new Vector3(stone[theStateManager.CurrentPlayerId].transform.position.x, 0, 0);
        //Debug.Log("Piedra :" + stone[theStateManager.CurrentPlayerId].name + " Y stone:" + stone[theStateManager.CurrentPlayerId].transform.position.x+"Y el currentPlayer"+theStateManager.CurrentPlayerId);
        //this.transform.rotation = Quaternion.Euler( new Vector3(0, theAngle, 0) );
	}
}
