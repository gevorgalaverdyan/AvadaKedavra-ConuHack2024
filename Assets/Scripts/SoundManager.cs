using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip fireSound, deathSound, gameOverSound, bridgeHitSound;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {

        fireSound = Resources.Load<AudioClip>("spellCast");
        deathSound = Resources.Load<AudioClip>("death");
        gameOverSound = Resources.Load<AudioClip>("avadaKedavraaSpell");
        bridgeHitSound = Resources.Load<AudioClip>("crucioSpell");
        audioSrc = GetComponent<AudioSource>();
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
            case "gameOver":
                audioSrc.PlayOneShot(gameOverSound);
                break;
            case "crucioSpell":
                audioSrc.PlayOneShot(bridgeHitSound);
                break;
        }
    }
}
