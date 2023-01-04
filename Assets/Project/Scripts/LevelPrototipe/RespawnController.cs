using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnController : MonoBehaviour
{
    [SerializeField]
    private Material transitionMaterial;

    [SerializeField]
    private float transitionTime = 3f;

    [SerializeField]
    private string propertyName = "_Progress";

    private bool onlyOnce = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Restart")
        {
            StartCoroutine(DeathTranition());
        }
    }

    private IEnumerator DeathTranition()
    {
        float currentTime = transitionTime;
        while (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            transitionMaterial.SetFloat(propertyName, Mathf.Clamp01(currentTime / transitionTime));
            yield return null;
        }
        PlayerDeath();
    }

    private void PlayerDeath()
    {
        if (onlyOnce)
        {
            onlyOnce = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
        }
    }
}
