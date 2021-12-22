using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinBlock : MonoBehaviour {
    [SerializeField] private Transform playerCheckTransform;
    [SerializeField] private LayerMask tileMask;
    [SerializeField] private GameObject rootTilePrefab;
    [SerializeField] private HUD hud;
    private GameObject rootTile;
    private GameObject floorTilesParent;
    private GameObject player;

    void Start() {
	hud = GameObject.Find("Canvas").GetComponent<HUD>();
	floorTilesParent = GameObject.Find("FloorTiles");
	player = GameObject.Find("Player");
	rootTile = GameObject.Find("RootTile");
    }

    void FixedUpdate() {
	if (Physics.CheckSphere(playerCheckTransform.position, 0.4f, tileMask)) {
		foreach (GameObject clonedItem in GameObject.FindGameObjectsWithTag("Cloned")) Destroy(clonedItem);

		//Re-Initialize RootTile
		GameObject clonedRootTile = Instantiate(rootTilePrefab, new Vector3(0, 0.5f, 0), Quaternion.identity, floorTilesParent.transform);
		clonedRootTile.name = "RootTile";

		Destroy(rootTile);
		Destroy(this);

		//Trigger Reset() on Player
		player.transform.position = new Vector3(0, -100, 0);

		hud.level++;
	}
    }
}
