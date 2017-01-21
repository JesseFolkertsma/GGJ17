using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kernel : MonoBehaviour {

    public ILives lives;

    public void PopKernel()
    {
        lives.lives--;
    }
}
