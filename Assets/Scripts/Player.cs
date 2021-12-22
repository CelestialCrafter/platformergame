using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] private Transform groundCheckTransform;
    [SerializeField] private LayerMask playerMask;
    public HUD hud;
    private bool jumpCalled;
    private float currentHorizontal;
    private float currentVertical;
    private Rigidbody player;
    private GameObject coins;

    void Start()
    {
	//Set the Random seed to x
	Random.InitState(332345);
	hud = GameObject.Find("Canvas").GetComponent<HUD>();
        player = GetComponent<Rigidbody>();
        coins = GameObject.Find("Coins");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) jumpCalled = true;
        currentHorizontal = Input.GetAxis("Horizontal");
        currentVertical = Input.GetAxis("Vertical");
    }

    private void HandleDeath() {
        hud.coins = 0;
	foreach (MeshRenderer coinMesh in coins.GetComponentsInChildren<MeshRenderer>()) coinMesh.enabled = true;
	foreach (SphereCollider coinCollider in coins.GetComponentsInChildren<SphereCollider>()) coinCollider.enabled = true;
        player.position = new Vector3(0, 1.5f, 0);
    }

    private void FixedUpdate() {
	if (player.position.y <= -5) HandleDeath();

	if (jumpCalled) {
		jumpCalled = false;
		if (Physics.CheckSphere(groundCheckTransform.position, 0.1f, playerMask)) {
	    		player.AddForce(Vector3.up * 5, ForceMode.VelocityChange);
		} else if (hud.coins >= 1) {
			hud.coins--;
			player.AddForce(Vector3.up * 5, ForceMode.VelocityChange);
		}
	}

        player.velocity = new Vector3(currentVertical * 3, player.velocity.y, currentHorizontal * 3 * -1);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.layer == 6) {
            other.gameObject.GetComponent<MeshRenderer>().enabled = false;
            other.gameObject.GetComponent<SphereCollider>().enabled = false;
            hud.coins++;
        }
    }
}
