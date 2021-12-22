using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {
    [SerializeField] private Transform playerCheckTransform;
    [SerializeField] private LayerMask tileMask;
    [SerializeField] private GameObject floorTile;
    [SerializeField] private GameObject coin;
    [SerializeField] private GameObject winBlock;
    private GameObject floorTilesParent;
    private GameObject coinsParent;

    void Start() {
	floorTilesParent = GameObject.Find("FloorTiles");
	coinsParent = GameObject.Find("Coins");
    }

    void FixedUpdate() {
	if (playerCheckTransform != null && this.name == "RootTile" || playerCheckTransform != null && Physics.CheckSphere(playerCheckTransform.position, 0.4f, tileMask)) {
		Destroy(playerCheckTransform.gameObject);

		float tileDistance = Random.Range(1f, 3.2f);
		float tileHeight = Random.Range(0f, 0.3f);
		float tileBack = Random.Range(-0.8f, 0.8f);

		float newX = this.transform.position.x + tileDistance + 1;
		float newY = 0.5f + tileHeight + this.transform.position.y / 1.6f;
		float newZ = tileBack;

		if (floorTilesParent.transform.childCount >= 10) {
			GameObject clonedWinBlock = Instantiate(winBlock, new Vector3(newX, newY, newZ), Quaternion.identity, floorTilesParent.transform);
			clonedWinBlock.tag = "Cloned";
			clonedWinBlock.name = "ClonedWinBlock";
			return;
		}

		if (Random.Range(0, 4) == 1) {
			GameObject clonedCoin = Instantiate(coin, new Vector3(newX, newY + 1, newZ), Quaternion.identity, coinsParent.transform);
			clonedCoin.tag = "Cloned";
			clonedCoin.name = "CloneCoin";
		}

		GameObject clonedTile = Instantiate(floorTile, new Vector3(newX, newY, newZ), Quaternion.identity, floorTilesParent.transform);
		clonedTile.tag = "Cloned";
		clonedTile.name = "CloneTile";
	}
    }
}
