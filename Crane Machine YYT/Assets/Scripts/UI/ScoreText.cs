using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ScoreTextMesh;
    [SerializeField] private int PresentScoreAmount;
    [SerializeField] private int TransitionScoreAmount;
    [SerializeField] private float TransitionDuration;

    private IEnumerator TransitionNumberRoutine;

    public void UpdateUIInstant(int newValue)
    {
        if(TransitionNumberRoutine != null)
        {
            StopCoroutine(TransitionNumberRoutine);
            TransitionNumberRoutine = null;
        }

        PresentScoreAmount = newValue;
        TransitionScoreAmount = newValue;
        ScoreTextMesh.text = PresentScoreAmount.ToString();
    }

    public void BeginTransition(int endAmount)
    {
        if(TransitionNumberRoutine != null)
        {
            StopCoroutine(TransitionNumberRoutine);
            TransitionNumberRoutine = null;
        }

        TransitionScoreAmount = int.Parse(ScoreTextMesh.text);
        PresentScoreAmount = endAmount;

        TransitionNumberRoutine = TransitionNumber();
        StartCoroutine(TransitionNumberRoutine);
    }

    private IEnumerator TransitionNumber()
    {
        float time = 0f;
        int startTransitionAmount = TransitionScoreAmount;

        while(time < TransitionDuration)
        {
            TransitionScoreAmount = (int)Mathf.Lerp(startTransitionAmount, PresentScoreAmount, time/TransitionDuration);
            ScoreTextMesh.text = TransitionScoreAmount.ToString();
            time += Time.deltaTime;
            yield return null;
        }

        TransitionScoreAmount = PresentScoreAmount;
        ScoreTextMesh.text = TransitionScoreAmount.ToString();

    }

}
