using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Character : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;
    [SerializeField]
    private float jumpForce = 6.5f;
    [SerializeField]
    private Rigidbody2D myBody;

    private Animator anim;
    private SpriteRenderer sr;
    
    private float movementX;
    private string WALK_ANIMATION = "Walk";
    private string DEATH_ANIMATION = "Death"; 
    private string GROUND_TAG = "Ground";
    private string ENEMY_TAG = "Enemy";
    private bool isGrounded = true; 
    
    private void Awake() {
       myBody = GetComponent<Rigidbody2D>();
       anim = GetComponent<Animator>();
       sr = GetComponent<SpriteRenderer>();
    }

    void Update() {
        playerMovementKeyboard();
        animatePlayer();
    }

    private void FixedUpdate() {
        playerJump();
    }

    void playerMovementKeyboard () {
        movementX = Input.GetAxisRaw("Horizontal");

        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;
    }

    void animatePlayer() {
        if(movementX > 0) {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;
        } else if(movementX < 0) {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = true;
        } else {
            anim.SetBool(WALK_ANIMATION, false);
        }
    }

    void playerJump() {
        if(Input.GetButtonDown("Jump") && isGrounded == true) {
            isGrounded = false;
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag(GROUND_TAG)) {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag(ENEMY_TAG)) {
            anim.SetTrigger(DEATH_ANIMATION);
            Destroy(gameObject, 1.0f);
        }
    }

}
