using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerLight : MonoBehaviour
{

    private Light _pointLight;
    private GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        this._pointLight = GetComponent<Light>();
        StartCoroutine(flicker());
        this.player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float distance = (player.transform.position - gameObject.transform.position).magnitude;

        if (distance > 10)
        {
            if (_pointLight.enabled)
            {
                _pointLight.enabled = false;
                Debug.Log("turned off light");
                StopAllCoroutines();
            }
        }
        else {
            if (!_pointLight.enabled)
            {
                _pointLight.enabled = true;
                Debug.Log("turned on light");
                StartCoroutine(flicker());
            }
        }

    }

    IEnumerator flicker()
    {
        while (_pointLight.enabled)
        {
            if (Random.Range(1, 10) == 5)
            {
                int numFlickers = Random.Range(3, 10);

                for (int i = 0; i < numFlickers; i++)
                {
                    _pointLight.intensity = Random.Range(0, 6);
                    yield return new WaitForSeconds(Random.Range(0.05f, .1f));
                }

                _pointLight.intensity = 5;

                yield return new WaitForSeconds(Random.Range(1, 3));
            }
        }
    }
}
