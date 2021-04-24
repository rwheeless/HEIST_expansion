using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter2 : MonoBehaviour
{
    public AudioSource voicelines;

    public AudioClip voice4;
    [SerializeField]
    GameObject VoiceTrigger4;
    private bool playVoice4;

    // Start is called before the first frame update
    void Start()
    {
        voicelines = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (playVoice4 == true)
        {
            voicelines.clip = voice4;
            voicelines.Play();
            
            VoiceTrigger4.transform.position = new Vector3(-60, 0.5f, 3);

            playVoice4 = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.CompareTag("voice4"))
        {
            playVoice4 = true;
        }

        if (other.gameObject.CompareTag("Player"))
        {
            playVoice4 = true;
        }
    }
}
