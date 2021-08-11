using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctoStat : MonoBehaviour
{
    public Rigidbody2D projectile;
    public float projectileSpeed;

    Transform m_MyTransform;

    void Start()
    {
        m_MyTransform = GetComponent<Transform>();
    }

    void Update()
    {
        if (Time.fixedTime % 1 == 0) {
            var fireballInst = Instantiate(projectile, m_MyTransform.position, Quaternion.Euler(new Vector2(0, 0)));
            fireballInst.velocity = new Vector2(0, projectileSpeed);
        }
    }
}
