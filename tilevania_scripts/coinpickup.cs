using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinpickup : MonoBehaviour
{     [SerializeField] AudioClip coinPickupSFX;
      [SerializeField] int pointsForCoinPickup=100;

     void OnTriggerEnter2D(Collider2D other) {
      if(other.tag=="Player") {
        FindObjectOfType<gamesession>().addToScore(pointsForCoinPickup);
        AudioSource.PlayClipAtPoint(coinPickupSFX,Camera.main.transform.position);
        Destroy(gameObject);
      } 
    }
}
