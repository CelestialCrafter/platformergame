using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour {
    [SerializeField] private Transform player;
    float xMouse = 90;
    float yMouse = 0;
    float sensitivity = 2;

    void Start() {
        
    }

    void Update() {
        xMouse += Input.GetAxis("Mouse X") * sensitivity;
        yMouse += Input.GetAxis("Mouse Y") * sensitivity;

	yMouse = Mathf.Clamp(yMouse, -90f, 90f);

	transform.localEulerAngles = new Vector3(yMouse * -1, 0, 0);
	player.localEulerAngles = new Vector3(0, xMouse, 0);
    }
}
