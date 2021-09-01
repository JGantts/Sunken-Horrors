using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenScript : MonoBehaviour
{
  public AudioClip o2TankPop;

  public void OnTriggerEnter2D(Collider2D collider) {
      if (collider.name == "diver") {
        AudioSource.PlayClipAtPoint(
            o2TankPop,
            GetComponent<Transform>().position,
            3f
          );
          GameObject player = collider.gameObject;
          DiverScript playerScript = player.GetComponent<DiverScript>();
          playerScript.O2Tank();
          Destroy(gameObject);
      }
  }
}
