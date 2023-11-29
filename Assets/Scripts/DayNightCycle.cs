using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float dayDuration = 30f;
    private Light directionalLight;

    void Start()
    {
        directionalLight = GetComponent<Light>();
        StartCoroutine(UpdateDayNightCycle());
    }

    IEnumerator UpdateDayNightCycle()
    {
        float elapsed = 0f;

        while (true)
        {
            float angle = Mathf.Lerp(0f, 180f, elapsed / dayDuration);
            directionalLight.transform.rotation = Quaternion.Euler(angle, 0f, 0f);

            elapsed += Time.deltaTime;

            if(elapsed > dayDuration)
            {
                elapsed = 0f;
                yield return null;
            }

            yield return null;
        }

    }
}
