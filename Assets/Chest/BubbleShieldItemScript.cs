using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleShieldItemScript : MonoBehaviour
{
  Rigidbody2D m_MyRigidbody2D;
  public GameObject Player;

  // Start is called before the first frame update
  void Start()
  {
      m_MyRigidbody2D = GetComponent<Rigidbody2D>();
  }

  // Update is called once per frame
  void Update()
  {
      if (m_MyRigidbody2D.velocity.y < -5) {
          Destroy(gameObject);
          DiverScript playerScript = Player.GetComponent<DiverScript>();
          playerScript.BubbleShieldItem();
      }
  }
}
