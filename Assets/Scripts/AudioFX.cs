using UnityEngine;
using System.Collections;

public class AudioFX : MonoBehaviour {

    public AudioClip bgm, jump, death;

    void Start () {
        GetComponent<AudioSource> ().clip = bgm;
        GetComponent<AudioSource> ().Play();
    }

	void Update () {
	    if (DataManagement.dataManage.gameOn) {
            if (Input.GetButtonUp("Jump")) {
                GetComponent<AudioSource> ().PlayOneShot (jump, 1.0f);
            }
        }
	}

    void OnCollisionEnter(Collision col) {
        if (col.gameObject.tag == "Obstacle") {
            GetComponent<AudioSource> ().PlayOneShot (death, 1.0f);
        }
    }
}
