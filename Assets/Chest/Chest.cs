using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{

    private Animator myAnimation;

    public Rigidbody2D HeartSprite;
    public Rigidbody2D BubbleShieldSprite;

    Transform m_MyTransform;

    bool m_IsOpen = false;

    // Start is called before the first frame update
    void Start() {
      myAnimation = GetComponent<Animator>();
      m_MyTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update() {

    }

    public void OnTriggerEnter2D(Collider2D collider) {
        if (collider.name == "diver") {
            if (!m_IsOpen) {
                Open(collider.gameObject);
            }
        }
    }

    private void Open(GameObject player) {
        myAnimation.SetBool("IsOpen", true);
        m_IsOpen = true;
        if (Random.value < 0.5) {
            RevealHeart(player);
        } else {
            RevealBubbleShield(player);
        }
    }

    private void RevealHeart(GameObject player) {
        var fireballInst = Instantiate(HeartSprite, m_MyTransform.position, Quaternion.Euler(new Vector2(0, 0)));
        fireballInst.GetComponent<HeartItemScript>().Player = player;
        fireballInst.velocity = new Vector2(0, 8);
    }

    private void RevealBubbleShield(GameObject player) {
        var fireballInst = Instantiate(BubbleShieldSprite, m_MyTransform.position, Quaternion.Euler(new Vector2(0, 0)));
        fireballInst.GetComponent<BubbleShieldItemScript>().Player = player;
        fireballInst.velocity = new Vector2(0, 8);

    }
}
