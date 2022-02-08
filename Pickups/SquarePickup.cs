using UnityEngine;

public class SquarePickup : MonoBehaviour
{
    public AudioSource pickUpSound;
    public string propertyName; // e.g. "RedSquaresCollected"
    public ParticleSystem pickupFX;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player")
            return;

        AccomplishmentTracker.CreditProperty(propertyName, 1);
        if (pickupFX != null)
            pickupFX.Play();
        if (pickUpSound != null)
            pickUpSound.Play();
        Destroy(gameObject);
    }
}