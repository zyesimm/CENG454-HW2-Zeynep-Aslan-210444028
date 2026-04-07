using UnityEngine;

public class MissileLauncher : MonoBehaviour
{
    [SerializeField] private GameObject missilePrefab;
    [SerializeField] private Transform launchPoint;

    private GameObject activeMissile;

    public GameObject Launch(Transform target)
    {
        Debug.Log("LAUNCH FUNCTION CALLED");

        if (activeMissile != null) return null;

        if (missilePrefab == null)
        {
            Debug.LogError("MISSILE PREFAB NULL!!!");
            return null;
        }

        if (launchPoint == null)
        {
            Debug.LogError("LAUNCH POINT NULL!!!");
            return null;
        }

        activeMissile = Instantiate(missilePrefab, launchPoint.position, launchPoint.rotation);

        Debug.Log("MISSILE CREATED");

        MissileHoming homing = activeMissile.GetComponent<MissileHoming>();

        if (homing != null)
        {
            homing.SetTarget(target);
        }
        else
        {
            Debug.LogError("MissileHoming script missing on missile prefab!");
        }

        return activeMissile;
    }

    public void DestroyActiveMissile()
    {
        if (activeMissile != null)
        {
            Destroy(activeMissile);
            activeMissile = null;
        }
    }
}