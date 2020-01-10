using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public int TargetFrameRate;

    // Use this for initialization
    void Start()
    {
        if (this.TargetFrameRate > 0)
        {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = this.TargetFrameRate;
        }
    }
}
