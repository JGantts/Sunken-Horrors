using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctoLoco : MonoBehaviour
{
    public float Speed = 1;

    Transform m_myTransform;
    Rigidbody2D myRigidbody;

    float m_Direction = 1.0f;


    RaycastHit2D hitUp;
    RaycastHit2D hitDown;

    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        m_myTransform = GetComponent<Transform>();
    }

    void FixedUpdate() {
        hitUp = Physics2D.Raycast(m_myTransform.position, Vector2.up, 0.5f);
        hitDown = Physics2D.Raycast(m_myTransform.position, Vector2.down, 0.5f);
        if (hitUp.collider != null) {
            if (hitUp.collider.name == "diver") {
              GameObject player = hitUp.collider.gameObject;
              DiverScript playerScript = player.GetComponent<DiverScript>();
              playerScript.Attacked();
            } else {
                m_Direction = -1;
            }
        } else if (hitDown.collider != null && hitDown.collider.name != "diver") {
            m_Direction = 1;
        }
        if (m_Direction < 0) {
          m_myTransform.localScale = new Vector2(1, -1);
        } else {
          m_myTransform.localScale = new Vector2(1, 1);
        }
        movement = new Vector2(
            0,
            m_Direction * Speed * (1f)
        );

        myRigidbody.velocity = new Vector2(
          myRigidbody.velocity.x,
          movement.y
        );
    }

    public void OnTriggerEnter2D(Collider2D collider) {
        if (collider.name == "diver") {
            GameObject player = collider.gameObject;
            DiverScript playerScript = player.GetComponent<DiverScript>();
            playerScript.Attacked();
        }
    }
}
