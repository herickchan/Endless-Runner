using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    private Rigidbody rb;
    private Animator anim;
    public float jumpSpeed;
    public float runSpeed;
    public float dropSpeed;
    private bool jumping = false;
    private float timer = 0f;

    void Start () {
	    rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        DataManagement.dataManage.LoadData();
        anim.Play("WAIT00");
	}
	
	void Update () {
        if (DataManagement.dataManage.gameOn) { 
            //rb.velocity = new Vector3 (runSpeed, rb.velocity.y, rb.velocity.z);
            transform.Translate(Vector3.forward * runSpeed * Time.fixedDeltaTime);  
            if (!jumping) {
                if (Input.GetButton("Jump")) {
                    timer += Time.deltaTime;
                
                } 
                if (Input.GetButtonUp("Jump")) {
                    if (timer < 0.25f) {
                        jumpSpeed = 5;
                    } else if (timer >= 0.25f) {
                        jumpSpeed = 8;
                    }
                    Debug.Log(timer);
                    jumping = true;
                    anim.Play("JUMP00");
                    rb.velocity = new Vector3(rb.velocity.x, jumpSpeed);
                    timer = 0f;
                }
                
                if (Input.GetButton("Vertical")) {
                    anim.Play("SLIDE00");
                }
            }
        }
	}

    void OnCollisionEnter(Collision col) {
        if (DataManagement.dataManage.gameOn) { 
            if (col.gameObject.tag == "Ground") {
                jumping = false;
                anim.Play("RUN00_F");
                DataManagement.dataManage.score++;
            } else if (col.gameObject.tag == "Obstacle") {
                PlayerDeath();
            }
        }
    }

    void PlayerDeath () {
        DataManagement.dataManage.gameOn = false;
        DataManagement.dataManage.playerDed = true;
        DataManagement.dataManage.SaveData ();
        anim.Play("DAMAGED01");
    }
}
