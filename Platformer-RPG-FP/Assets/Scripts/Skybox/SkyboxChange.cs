using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkyboxChange : MonoBehaviour
{
    [SerializeField] private Material[] skyboxes;
    [SerializeField] private Score score;
    [SerializeField] private int currentSkybox = 0;
    [SerializeField] private float fadeOutTime = 0.5f;
    [SerializeField] private float fadeInTime = 1f;
    [SerializeField] private float fadeWaitTime = 0.5f;

    private float delay;
    private float timeToFree = 2f;

    private void Start()
    {
        RenderSettings.skybox = skyboxes[currentSkybox];
    }

    private void Update()
    {
        if (score.IntScore % 1000 == 0 && score.IntScore > 0 && delay <= 0)
        {
            Debug.Log(score.IntScore);
            currentSkybox++;
            delay = timeToFree;
            TriggerCoroutine();
        }

        delay -= Time.deltaTime;
    }

    private void TriggerCoroutine()
    {
        StartCoroutine(Transition());
    }

    private IEnumerator Transition()
    {
        Fader fader = FindObjectOfType<Fader>();

        yield return fader.FadeOut(fadeOutTime);

        SwitchSkybox();

        yield return new WaitForSeconds(fadeWaitTime);
        yield return fader.FadeIn(fadeInTime);

        //Destroy(gameObject);
    }

    private void SwitchSkybox()
    {
        if (currentSkybox == skyboxes.Length)
        {
            currentSkybox = 0;
        }
        RenderSettings.skybox = skyboxes[currentSkybox];
    }
}
