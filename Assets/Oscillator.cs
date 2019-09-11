using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[DisallowMultipleComponent]

public class Oscillator : MonoBehaviour {
    [SerializeField] Vector3 movementVector = new Vector3(10f ,10f ,10f);
    [SerializeField] float Period = 2f;

    Vector3 startingPos;  // Must be stored for absolute movement...

    // todo remove from inspector later
    [Range(0,1)] [SerializeField]  float movementFactor;  // 0 for not moved and 1 for fully moved !!!
    private Vector3 offset;

    // Use this for initialization
    void Start () {
        startingPos = transform.position;
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Period <= Mathf.Epsilon) { return; }  // todo protect against period is 0 !!!

        float cycles = Time.time / Period;  //grows continually from 0  !!!

        const float tau = Mathf.PI * 2f;  // About 6.28 !!!
        float rawSineWave = Mathf.Sin(cycles * tau);  // goes from -1 to +1!!

        movementFactor = rawSineWave / 2f + 0.5f;  // goes from 0 to 1 !!!
        

        Vector3 offset = movementFactor * movementVector;
        transform.position = startingPos + offset;
		
	}
}
