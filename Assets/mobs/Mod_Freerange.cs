using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob_Freerange : Mob_Attack
{
  public float direction = 1;
  public float speed = 1;

  private Rigidbody2D myRigidbody;

  private Vector2 movement;

  private bool isInDirectionalCooldown = false;

  public override void Start() {
    base.Start();
    myRigidbody = GetComponent<Rigidbody2D>();
  }

  public override void Update() {
      base.Update();
      if (!isInDirectionalCooldown && !isInAttackCooldown && Random.value > 0.995) {
        direction = -1 * direction;
        isInDirectionalCooldown = true;
        Invoke("EndDirectionalCooldown", 2f);
      }
      if (direction < 0) {
        transform.localScale = new Vector2(-1, 1);
      } else {
        transform.localScale = new Vector2(1, 1);
      }
      if (!isAttacking){
        movement = new Vector2(
            direction * speed * (1f),
            0
        );
      } else {
        movement = new Vector2(0, 0);
      }
  }

  void FixedUpdate() {
      myRigidbody.velocity = movement;
  }

  void EndDirectionalCooldown() {
      isInDirectionalCooldown = false;
  }
}
