#pragma warning disable
using UnityEngine;
using System.Collections.Generic;

public class MoveMyGuy : MonoBehaviour {
	public Rigidbody2D rb;
	public float moveSpeed = 0F;
	public GameObject Player;

	public void Start() {
		rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Component>().GetComponent<UnityEngine.Rigidbody2D>();
		moveSpeed = 5F;
		Player = GameObject.FindGameObjectWithTag("Player");
		Cursor.lockState = CursorLockMode.Locked;
	}

	public void Update() {
		Movement();
	}

	public void Movement() {
		if((Input.GetAxisRaw("Horizontal") != 0F)) {
			rb.AddForce(new Vector2((Input.GetAxisRaw("Horizontal") + (moveSpeed * Time.deltaTime)), Player.transform.position.y), ForceMode2D.Force);
		}
	}
}
