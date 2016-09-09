using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    private GameObject player;
    public float camSpeed;

	void Start () {
	    player = GameObject.FindGameObjectWithTag("Player");
	}
	
	void Update () {
        if (DataManagement.dataManage.gameOn) { 
	        Vector3 camPos = transform.position;
            camPos.x = player.transform.position.x - -6.0f;
            transform.position = Vector3.Lerp(transform.position, camPos, 3 * Time.fixedDeltaTime);

            camPos.y = player.transform.position.y + 3.0f;
            transform.position = Vector3.Lerp(transform.position, camPos, 7 * Time.fixedDeltaTime);
        }
	}
}
