using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbiantSoundManager : MonoBehaviour
{
    public AudioSource dayAudio;
    public AudioSource nightAudio;
    public AudioSource music;
    public AudioSource birdsChirping;

    public TimeController timeController;
    public PlayerInteract playerInteract;

    public AnimationCurve audioChangeCurve;

    public float musicTime = 60;
    public float musicTimer;





    // Start is called before the first frame update
    void Start()
    {
        musicTimer = musicTime;
        dayAudio.volume = 0;
        nightAudio.volume = 0;

    }

    private void Update()
    {
        if (!music.isPlaying)
        {
            musicTimer -= Time.deltaTime;
        }

        if (musicTimer <= 0 && !music.isPlaying)
        {
            musicTimer = musicTime;
            playMusic();
        }


        if (playerInteract.inside)
        {
            dayAudio.volume = 0;
            nightAudio.volume = 0;


        }
        else
        {
            dayAudio.volume = Mathf.Lerp(0, 0.5f, audioChangeCurve.Evaluate(timeController.dotProduct));
            nightAudio.volume = Mathf.Lerp(0.5f, 0, audioChangeCurve.Evaluate(timeController.dotProduct));

        }
    }

    public void playMusic()
    {
        music.Play();

    }

    public void stopMusic()
    {
        music.Stop();
    }

    public void playBirds()
    {
        birdsChirping.Play();
    }


}
