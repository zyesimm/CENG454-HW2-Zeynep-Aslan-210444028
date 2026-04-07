using UnityEngine;

public class MissileHoming:MonoBehaviour
{
    private Transform target;

    public void SetTarget(Transform newTarget)
    {
        target=newTarget;
    }

    void Update()
    {
        if (target == null) return;

        transform.LookAt(target);
        transform.Translate(Vector3.forward * 20f * Time.deltaTime);
    }
}