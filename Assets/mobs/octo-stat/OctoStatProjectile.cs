using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctoStatProjectile : MonoBehaviour {

    Rigidbody2D m_MyRigidbody2D;

    // Start is called before the first frame update
    void Start() {
        m_MyRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        if (m_MyRigidbody2D.velocity.y < 0) {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D collider) {
        //Debug.Log("1");
        if (collider.name == "diver") {
            Debug.Log("2");
            collider.gameObject.GetComponent<DiverScript>().Attacked();
            Destroy(gameObject);
        }
    }
}
