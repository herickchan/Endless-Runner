using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour {
    
    public GameObject destroyPoint;
	
    void Start () {
        destroyPoint = GameObject.Find ("DestroyPoint");
    }
	void Update () {
        if (transform.position.x < destroyPoint.transform.position.x) {
            Destroy (gameObject);
        }
	}
}
