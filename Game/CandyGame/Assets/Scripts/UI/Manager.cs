using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static int currentPalette;

    void Awake() {
        DontDestroyOnLoad(this.gameObject);
    }
}
