using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbiantSoundManager : MonoBehaviour
{
    public AudioSource dayAudio;
    public AudioSource nightAudio;

    public TimeController timeController;
    public PlayerInteract playerInteract;

    public AnimationCurve audioChangeCurve;



    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {

       if (playerInteract.inside)
        {
            dayAudio.volume = 0;
            nightAudio.volume = 0;
        } else
        {
            dayAudio.volume = Mathf.Lerp(0, 0.1f, audioChangeCurve.Evaluate(timeController.dotProduct));
            nightAudio.volume = Mathf.Lerp(0.5f, 0, audioChangeCurve.Evaluate(timeController.dotProduct));
        }
    }


}
