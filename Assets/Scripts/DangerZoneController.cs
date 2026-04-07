using UnityEngine;
using System.Collections;
public class DangerZoneController : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;
    [SerializeField] private MissileLauncher missileLauncher;
    [SerializeField] private float missileDelay = 5f;

    private Coroutine activeCountdown;

    private void OnTriggerEnter(Collider collision)
    {
    if (collision.CompareTag("Player"))
    {
        Debug.Log("Player entered danger zone");
        examManager.EnterDangerZone();

        if (activeCountdown == null)
        {
            activeCountdown = StartCoroutine(MissileCountdown(collision.transform));
        }
    }
}
    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player exited danger zone");
            examManager.ExitDangerZone();

            if (activeCountdown != null)
            {
                StopCoroutine(activeCountdown);
                activeCountdown = null;
            }
            if (missileLauncher != null)
            {
                missileLauncher.DestroyActiveMissile();
            }
        }
    }

    private IEnumerator MissileCountdown(Transform target)
    {
        yield return new WaitForSeconds(missileDelay);
        Debug.Log("MISSILE SHOULD LAUNCH NOW");

        if (missileLauncher != null)
        {
            missileLauncher.Launch(target);
        }
        activeCountdown = null;
    }
}