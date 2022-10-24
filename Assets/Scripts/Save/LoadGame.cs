using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGame : MonoBehaviour
{
    public SaveLoad saveLoad;
    // Start is called before the first frame update
    void Start()
    {
        saveLoad.LoadGameData();
    }


}
