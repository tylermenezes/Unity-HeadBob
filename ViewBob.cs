using UnityEngine;
using System.Collections;

public class ViewBob : MonoBehaviour {
    public float 		Speed		= 0.025f;
	public bool			IsFullWave	= true;
	public Vector3		Amount		= new Vector3(1,0,0);
	
	private float timer = 0.0f;
	public void Update()
	{
		var position = transform.localPosition;
		if (!OVRPlayerController.playerIsMoving) {
			if (timer == 0 || Mathf.Abs(timer - Mathf.PI) < 0.01) {
				return;
			}
		}
		
		float moveCyclePercent = Mathf.Sin(timer);
		timer += Speed;
		
		if (timer > Mathf.PI * (IsFullWave ? 2 : 1)) {
			timer = 0.0f;
		}
		
		if (Amount.x != 0) {
			position.x = Amount.x * moveCyclePercent;
		}
		
		if (Amount.y != 0) {
			position.y = Amount.y * moveCyclePercent;
		}
		
		if (Amount.z != 0) {
			position.z = Amount.z * moveCyclePercent;
		}
		
		transform.localPosition = position;
	}
}
