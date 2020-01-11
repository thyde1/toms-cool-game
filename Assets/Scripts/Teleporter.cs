using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour
{
    public string Scene;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerController>(out _))
        {
            SceneManager.LoadScene(this.Scene);
            SceneManager.sceneLoaded += this.SceneLoaded;
        }
    }

    private void SceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        SceneManager.SetActiveScene(scene);
    }
}
