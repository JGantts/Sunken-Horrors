using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartCollectable : MonoBehaviour
{
  public void OnTriggerEnter2D(Collider2D collider) {
      if (collider.name == "diver") {
          GameObject player = collider.gameObject;
          DiverScript playerScript = player.GetComponent<DiverScript>();
          playerScript.HeartCollectable();
          Destroy(gameObject);
      }
  }
}
