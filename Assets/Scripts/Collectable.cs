using UnityEngine;

public class Collectable : MonoBehaviour {
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player")
            Destroy(gameObject);
    }
}