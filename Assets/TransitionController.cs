using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TransitionController : MonoBehaviour
{
    [SerializeField]
    private Material transitionMaterial;

    [SerializeField]
    private float transitionTime = 3f;

    [SerializeField]
    private string propertyName = "_Progress";

    public UnityEvent OnTransitionDone;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(InitialTransition());
    }

    private IEnumerator InitialTransition()
    {
        float currentTime = 0;
        while (currentTime < transitionTime)
        {
            currentTime += Time.deltaTime;
            transitionMaterial.SetFloat(propertyName, Mathf.Clamp01(currentTime / transitionTime));
            yield return null;
        }
        //OnTransitionDone?.Invoke();
    }
}
