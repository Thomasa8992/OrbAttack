using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody playerRigidBody;
    private bool isPlayerOnTheGround = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isPlayerOnTheGround) {
            isPlayerOnTheGround = false;

            playerRigidBody.AddForce((Vector3.up * 10) / 2, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.name == "Plane") {
            isPlayerOnTheGround = true;
            Debug.Log(isPlayerOnTheGround);
        }
    }
}
