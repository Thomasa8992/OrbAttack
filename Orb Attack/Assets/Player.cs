using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody playerRigidBody;
    private bool isPlayerOnTheGround = false;
    private float jumpForce = 10;
    public float gravityModifier = 1;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();

        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update() {
        ControlPlayerJump();
    }

    private void ControlPlayerJump() {
        if (Input.GetKeyDown(KeyCode.Space) && isPlayerOnTheGround) {
            isPlayerOnTheGround = false;

            playerRigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision other) {
        HandlePlayerCollisionWithGround(other);
    }

    private void HandlePlayerCollisionWithGround(Collision other) {
        if (other.gameObject.name == "Plane") {
            isPlayerOnTheGround = true;
            Debug.Log(isPlayerOnTheGround);
        }
    }
}
