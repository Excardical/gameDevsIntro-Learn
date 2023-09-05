using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarbingerOfDeathScript : MonoBehaviour
{
    [HideInInspector]
    public float speed;

    private Rigidbody2D myBody;
    private Animator anim;
    private SpriteRenderer sr;
    private float distance;

    private string ATTACK_ANIMATION = "Slash Attack";
    private string DEATH_ANIMATION = "Death";

    void Awake() {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        speed = 7;
    }

    void FixedUpdate() {
        myBody.velocity = new Vector2(speed, myBody.velocity.y);
    }

    // void Update() {
    //     distance = Vector2.Distance(transform.position, player.transform.position);
    //     // animateEnemy();
    // }

    // void animateEnemy() {
    //     if() {
    //         anim.SetBool(ATTACK_ANIMATION, true);
    //     }
    // }
}
