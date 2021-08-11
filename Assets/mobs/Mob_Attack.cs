using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob_Attack : MonoBehaviour
{
  public Transform mouthCheckPoint;
  public float mouthCheckRadius = 1f;
  public LayerMask playerLayer;

  private Animator myAnimation;

  //private bool mouthIsTouchingPlayer;

  protected bool isInAttackCooldown = false;
  protected bool isAttacking = false;

  public virtual void Start() {
    myAnimation = GetComponent<Animator>();
    //playerScript = player.GetComponent<DiverScript>();
  }

  // Update is called once per frame
  public virtual void Update() {
      Collider2D mouthIsTouchingPlayer = Physics2D.OverlapCircle(mouthCheckPoint.position, mouthCheckRadius, playerLayer);
      if (mouthIsTouchingPlayer != null) {
        GameObject player = mouthIsTouchingPlayer.gameObject;
        DiverScript playerScript = player.GetComponent<DiverScript>();
        if (
          !playerScript.isInDamageCooldown &&
          !playerScript.IsDead &&
          !isInAttackCooldown) {
            playerScript.Attacked();
            isInAttackCooldown = true;
            myAnimation.SetBool("IsAttacking", true);
            isAttacking = true;
            Invoke("EndAttackCooldown", 1f);
        }
      }
  }

  void AttackEnd() {
      myAnimation.SetBool("IsAttacking", false);
      isAttacking = false;
  }

  void EndAttackCooldown() {
      isInAttackCooldown = false;
  }
}
