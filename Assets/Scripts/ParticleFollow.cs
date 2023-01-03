using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode]
public class ParticleFollow : MonoBehaviour
{
    private ParticleSystem particalSystem;
    // Start is called before the first frame update
    void Start()
    {
        particalSystem = transform.parent.gameObject.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (particalSystem.time >= particalSystem.main.duration/2.0f) {
            Vector3 temp = transform.position;
            temp.y += particalSystem.main.startSpeed.constant * Time.deltaTime;
            transform.position = temp;
        }
    }
}
