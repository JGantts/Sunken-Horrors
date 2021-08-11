using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenScript : MonoBehaviour
{
  DiverScript playerScript;

  // Start is called before the first frame update
  void Start() {
  }

  // Update is called once per frame
  void Update() {

  }

  public void OnTriggerEnter2D(Collider2D collider) {
      if (collider.name == "diver") {
          GameObject player = collider.gameObject;
          DiverScript playerScript = player.GetComponent<DiverScript>();
          playerScript.O2Tank();
          Destroy(gameObject);
      }
  }
}
