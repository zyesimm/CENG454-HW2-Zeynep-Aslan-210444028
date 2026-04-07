using UnityEngine;

public class AircraftThreatHandler : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private AudioSource hitAudioSource;
    [SerializeField] private FlightExamManager examManager;
    [SerializeField] private MissileLauncher missileLauncher;

    private Rigidbody rb;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
       
        if (!other.CompareTag("Missile")) return;
        {
            

            if (hitAudioSource != null)
            {
                hitAudioSource.Play();
               
            }

            if (examManager != null)
            {
                examManager.FailMission();
            }

            if (missileLauncher != null)
            {
                missileLauncher.DestroyActiveMissile();
            }

            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }

            if (respawnPoint != null)
            {
                transform.position = respawnPoint.position;
                transform.rotation = respawnPoint.rotation;
            }
            
            if (examManager!=null)
            {
                examManager.ResetAfterFailure();
            }
        }
    }
    




}
