using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public AudioSource voicelines;

    public AudioClip voice2;
    [SerializeField]
    GameObject VoiceTrigger2;
    private bool playVoice2;

    // Start is called before the first frame update
    void Start()
    {
        voicelines = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (playVoice2 == true)
        {
            voicelines.clip = voice2;
            voicelines.Play();
            
            VoiceTrigger2.transform.position = new Vector3(-6, 0.5f, 3);

            playVoice2 = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.CompareTag("voice2"))
        {
            playVoice2 = true;
        }

        if (other.gameObject.CompareTag("Player"))
        {
            playVoice2 = true;
        }
    }
}
