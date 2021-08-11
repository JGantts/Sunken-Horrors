using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob_Patrol : Mob_Attack
{
  public float Speed = 1;

  public float walkSpeed = 1.0f;
  public float wallLeftOffset = -5.0f;
  public float wallRightOffset = 5.0f;

  float wallLeft = 0f;
  float wallRight = 0f;

  float walkingDirection = 1.0f;
  Vector2 walkAmount;
  float originalX;

  Transform m_myTransform;

  private Rigidbody2D myRigidbody;

  private Vector2 movement;

  private RaycastHit2D hitLeft;
  private RaycastHit2D hitRight;

  public override void Start() {
    base.Start();
    myRigidbody = GetComponent<Rigidbody2D>();
    m_myTransform = GetComponent<Transform>();
    wallLeft = transform.position.x + wallLeftOffset;
    wallRight = transform.position.x + wallRightOffset;
  }

  public override void Update() {
      base.Update();
      if (!isInAttackCooldown) {
        walkAmount.x = walkingDirection * walkSpeed * Time.deltaTime;
        if (walkingDirection > 0.0f && transform.position.x >= wallRight) {
            walkingDirection = -1.0f;
        } else if (walkingDirection < 0.0f && transform.position.x <= wallLeft) {
            walkingDirection = 1.0f;
        }
        if (walkingDirection < 0) {
          transform.localScale = new Vector2(-1, 1);
        } else {
          transform.localScale = new Vector2(1, 1);
        }
      }
      if (!isAttacking) {
        movement = new Vector2(
            walkingDirection * Speed * (1f),
            0
        );
      } else {
        movement = new Vector2(0, 0);
      }
    }

  void FixedUpdate() {

      myRigidbody.velocity = new Vector2(
        movement.x,
        myRigidbody.velocity.y
      );
  }

/*
  public override void Update() {
      base.Update();
      if (!isInAttackCooldown) {
        Debug.DrawRay(MyTransform.position, Vector2.left, Color.red);
        Debug.DrawRay(MyTransform.position, Vector2.right, Color.green);
        hitLeft = Physics2D.Raycast(MyTransform.position, Vector2.left, LengthOfRay);
        hitRight = Physics2D.Raycast(MyTransform.position, Vector2.right, LengthOfRay);
        if (hitLeft.collider != null) {
          Direction = 1;
        } else if (hitRight.collider != null) {
          Direction = -1;
        }
      }
      if (Direction < 0) {
        transform.localScale = new Vector2(-1, 1);
      } else {
        transform.localScale = new Vector2(1, 1);
      }
      if (!isAttacking) {
        movement = new Vector2(
            Direction * Speed * (1f),
            0
        );
      } else {
        movement = new Vector2(0, 0);
      }
  }
*/
}
