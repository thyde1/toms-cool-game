using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public string Scene;

    private float colorChangeDelay = 0.1f;
    private float updateTime;

    private void Start()
    {
        this.updateTime = this.colorChangeDelay;
    }

    private void Update()
    {
        this.updateTime -= Time.deltaTime;

        if (this.updateTime > 0)
        {
            return;
        }

        this.updateTime = this.colorChangeDelay;
        var renderer = this.GetComponent<Renderer>();
        renderer.material.color = new Color(Random.value, Random.value, Random.value);
    }

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
