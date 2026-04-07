using UnityEngine;

public class BlinkLight : MonoBehaviour
{
    private Light lightComp;

    void Start()
    {
        lightComp = GetComponent<Light>();
    }

    void Update()
    {
        lightComp.enabled = Mathf.Sin(Time.time * 5f) > 0;
    }
}