using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip fireSound, deathSound;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {

        fireSound = Resources.Load<AudioClip>("spellCast");
        deathSound = Resources.Load<AudioClip>("death");
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "attack":
                audioSrc.PlayOneShot(fireSound);
                break;
            case "death":
                audioSrc.PlayOneShot(deathSound);
                break;
        }
    }
}
