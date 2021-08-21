using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;

public class DiverScript: MonoBehaviour
{
    public float speedWalk = 5f;
    public float speedRun = 5f;
    public float speedJump = 10f;
    public float speedSwimUp = 5f;
    public float speedSwimHorizontal = 5f;

    public Transform groundCheckPoint;
    public float groundCheckRadius = 1f;
    public LayerMask groundLayer;

    public Slider healthBar;
    public Slider o2Bar;
    public Image paragraph;

    public SpriteRenderer Bubble;

    private Vector2 movement;
    private Rigidbody2D rigidbodyComponent;
    new private Collider2D collider;

    private Animator playerAnimation;

    private bool m_IsTouchingGround;

    private bool m_IsDead;
    public bool IsDead {
      get {
        return m_IsDead;
      }
    }

    private float health = 100;
    private float oxygen = 100;

    private bool m_isInDamageCooldown = false;
    public bool isInDamageCooldown {
      get {
        return m_isInDamageCooldown;
      }
    }

    private bool m_isInBubble = false;
    public bool isInBubble {
      get {
        return m_isInBubble;
      }
    }

    float m_deathTime;

    public ParticleSystem myParticleSystem;

    void Start() {
      rigidbodyComponent = GetComponent<Rigidbody2D>();
      playerAnimation = GetComponent<Animator>();
      collider = GetComponent<Collider2D>();
      //myParticleSystem = GetComponent<ParticleSystem>();
    }

    void Update() {

        if (StoryHandler.The.displayingStory) {
            if (Input.anyKey && (StoryHandler.The.displayedStoryTime + 1.5f) < Time.realtimeSinceStartup) {
                paragraph.color = Color.clear;
                Time.timeScale = 1;
            }
        }

        if (isInBubble) {
          Bubble.color = Color.white;
        } else {
          Bubble.color = Color.clear;
        }
        if (!m_IsDead && Time.timeScale != 0) {
        healthBar.value = health/100f;
            o2Bar.value = oxygen/100f;

            var emitter = myParticleSystem.emission;
            emitter.rateOverTime = ((1-o2Bar.value)*1.2f - 0.2f) * 20f;

            if (playerAnimation.GetCurrentAnimatorClipInfo(0)[0].clip.name == "diver_wake") {
              return;
            }

            Vector3 center = collider.bounds.center;
            Vector3 extents = collider.bounds.extents;
            Vector3 bottomLeft = new Vector3(
              center.x - extents.x,
              center.y - extents.y,
              center.z
            );
            Vector3 bottomRight = new Vector3(
              center.x + extents.x,
              center.y - extents.y,
              center.z
            );

            List<Vector3> rayOrigins = new List<Vector3>();

            int addtnlPointCount = 20;
            float percentLeft = 1f;
            float percentPerRound = 1f/(addtnlPointCount + 1);
            for(int i = 0; i < (addtnlPointCount + 2); i++) {
              float percentRight = 1 - percentLeft;
              rayOrigins.Add(
                new Vector3(
                  bottomLeft.x*percentLeft + bottomRight.x*percentRight,
                  bottomLeft.y*percentLeft + bottomRight.y*percentRight - 0.01f,
                  bottomLeft.z*percentLeft + bottomRight.z*percentRight
                )
              );
              percentLeft -= percentPerRound;
            }

            m_IsTouchingGround = false;
            foreach(Vector3 point in rayOrigins) {
              Debug.DrawRay(point, Vector2.down, Color.green);
              RaycastHit2D hit = Physics2D.Raycast(point, Vector2.down, 0.03f);

              if (hit.collider != null) {
                m_IsTouchingGround = true;
                break;
              }
            }

            //Debug.DrawRay(bottomLeft, Vector2.down, Color.green);
            //Debug.DrawRay(bottomRight, Vector2.down, Color.green);

            //RaycastHit2D hitLeft = Physics2D.Raycast(MyTransform.position, Vector2.left, mLengthOfRay);

            /*if (hitLeft.collider != null) {
              Direction = 1;
            }*/

            playerAnimation.SetFloat("AbsInputHorizontal", Mathf.Abs(Input.GetAxis("Horizontal")));
            playerAnimation.SetBool("InputJump", Input.GetButtonDown("Jump"));
            playerAnimation.SetBool("IsTouchingGround", m_IsTouchingGround);
            playerAnimation.SetFloat("VelocityY", rigidbodyComponent.velocity.y);

            if (m_IsTouchingGround) {
                rigidbodyComponent.gravityScale = 0.3f;
            }

            float inputX = Input.GetAxis("Horizontal");

            /*if (inputX > 0.1 || inputX < -0.1) {
                stamina -= 5f/60f;
            }*/

            float staminaModifier = 1;
            /*if (stamina > 50) {
              staminaModifier = 1f;
            } else if (stamina > 37f) {
              staminaModifier = 0.75f;
            } else if (stamina > 25) {
              staminaModifier = 0.4f;
            } else if (stamina > 10) {
              staminaModifier = 0.25f;
            }*/

            float movementX = speedWalk * inputX * staminaModifier;
            float movementY = 0f;

            if (Input.GetButtonDown("Jump")) {
                if (m_IsTouchingGround) {
                    //if (stamina >= 10) {
                        rigidbodyComponent.gravityScale = 0.3f;
                        movementY = 1 * speedJump;
                        //stamina -= 10;
                    //}
                }
            }

            if (Input.GetButtonUp("Jump") || (rigidbodyComponent.velocity.y < -0.0001 && rigidbodyComponent.gravityScale != 1.7f)) {
                rigidbodyComponent.gravityScale = 1.7f;
            }

            movement = new Vector2(
              movementX,
              movementY
            );

            if (movement.x < 0f) {
              transform.localScale = new Vector2(-1, 1);
            } else if(movement.x > 0f) {
              transform.localScale = new Vector2(1, 1);
            }

            float newYVelo;
            if (movement.y == 0) {
                newYVelo = rigidbodyComponent.velocity.y;
            } else {
                newYVelo = movement.y;
            }

            rigidbodyComponent.velocity = new Vector2(
              movement.x,
              newYVelo
            );
        } else if (m_IsDead) {
            if (Input.GetButtonDown("Jump") && (m_deathTime + 3f) < Time.timeSinceLevelLoad) {
                SceneManager.LoadScene("Retry");
            }

            if ((m_deathTime + 6f) < Time.timeSinceLevelLoad) {
                SceneManager.LoadScene("Retry");
            }

            rigidbodyComponent.velocity = new Vector2(
              0,
              rigidbodyComponent.velocity.y
            );

            var emitter = myParticleSystem.emission;
            emitter.rateOverTime = 0;
        }
    }

    void FixedUpdate() {
        if (rigidbodyComponent.velocity.y < -2 * speedJump) {
            rigidbodyComponent.drag = 10;
        } else {
            rigidbodyComponent.drag = 0;
        }
        if (!m_IsDead && (health <= 0 || oxygen <= 0)) {
            m_IsDead = true;
            playerAnimation.SetBool("IsDead", true);
            m_deathTime = Time.timeSinceLevelLoad;
        }
        if (!m_isInBubble) {
            oxygen -= 3f/60f;
        }
        /*if (rigidbodyComponent.gravityScale == 0.3f && !m_IsTouchingGround) {
            stamina -= 20f/60f;
        }*/
    }

    public void Attacked() {
        if (!isInDamageCooldown && !m_isInBubble) {
            playerAnimation.SetBool("TookDamage", true);
            health -= (25 * UnityEngine.Random.value) + 25;
            m_isInDamageCooldown = true;
        }
    }

    void EndHurtAnimation() {
        playerAnimation.SetBool("TookDamage", false);
        m_isInDamageCooldown = false;
    }

    public void O2Tank() {
        oxygen = 100f;
    }

    public void HeartCollectable() {
        HeartItem();
    }

    public void HeartItem() {
        float healthMaxed = health + 50f;
        health = Math.Min(100f, healthMaxed);
    }

    public void BubbleShieldItem() {
        m_isInBubble = true;
        Invoke("NearEndBubbleShield", 10f);
        float o2Maxed = oxygen + 50f;
        oxygen = Math.Min(100f, o2Maxed);
    }

    void NearEndBubbleShield() {
        Bubble.color = Color.clear;
        Invoke("EndBubbleShield", 1f);
    }

    void EndBubbleShield() {
        m_isInBubble = false;
    }
}
