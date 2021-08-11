using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    bool m_IsExplode;

    private Animator myAnimation;

    // Start is called before the first frame update
    void Start()
    {
      myAnimation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D collider) {
        if (!m_IsExplode) {
            if (collider.name == "diver") {
                m_IsExplode = true;
                myAnimation.SetBool("IsExplode", true);
                collider.gameObject.GetComponent<DiverScript>().Attacked();
            }
        }
    }
}
