using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanController : MonoBehaviour
{
    public Transform fanObj;
    public float fanSpeed = 200;

    public GameObject windyFX;
    public AudioClip soundFanEngine;
    public AudioSource fanAudioSource;

    [ReadOnly] public bool isWorking = false;
    // Start is called before the first frame update
    void Start()
    {
        windyFX.SetActive(false);

        fanAudioSource.clip = soundFanEngine;
        fanAudioSource.volume = 0;
        fanAudioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (isWorking)
        {
            fanObj.RotateAround(transform.position, Vector3.up, fanSpeed * Time.deltaTime);
        }

        fanAudioSource.volume = isWorking? ( GlobalValue.isSound ?1 : 0) : 0;
    }

    public void Active()
    {
        if (isWorking)
            return;

        isWorking = true;
        windyFX.SetActive(true);
    }
}
