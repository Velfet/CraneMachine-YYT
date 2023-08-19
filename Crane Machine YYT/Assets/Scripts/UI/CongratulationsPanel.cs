using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CongratulationsPanel : MonoBehaviour
{
    [SerializeField] private float OnGoingAnimationDuration;
    [SerializeField] private Animator CongratulationAnimator;
    [Space(20)]
    [SerializeField] private GameObject CongratulationBackgroundImage;
    [SerializeField] private GameObject CongratulationText;
    [SerializeField] private Vector3 StartingScale;

    private IEnumerator CongratulationOnGoingRoutine;

    public void BeginCongratulation_Start()
    {
        CongratulationBackgroundImage.transform.localScale = StartingScale;
        CongratulationText.transform.localScale = StartingScale;
        CongratulationBackgroundImage.SetActive(true);
        CongratulationText.SetActive(true);

        CongratulationAnimator.Play("Congratulation_Start");
        //CongratulationAnimation.Play(congratulationAnimationNames[0]);
    }

    public void BeginCongratulation_OnGoing()
    {
        //CongratulationAnimation.Play(congratulationAnimationNames[1]);
        CongratulationAnimator.Play("Congratulation_OnGoing");
        BeginCongratulation_OnGoing_Countdown();
    }

    private void BeginCongratulation_OnGoing_Countdown()
    {
        if(CongratulationOnGoingRoutine != null)
        {
            CongratulationOnGoingRoutine = null;
        }
        CongratulationOnGoingRoutine = Congratulation_OnGoing_Countdown();
        StartCoroutine(CongratulationOnGoingRoutine);
    }

    private IEnumerator Congratulation_OnGoing_Countdown()
    {
        float time = 0f;

        while(time < OnGoingAnimationDuration)
        {
            yield return null;
            time += Time.deltaTime;
        }

        BeginCongratulation_End();

        yield break;
    }

    private void BeginCongratulation_End()
    {
        CongratulationAnimator.Play("Congratulation_End");
        //CongratulationAnimation.Play(congratulationAnimationNames[2]);
    }

    public void Congratulation_End_HasEnded()
    {
        //Deactivate congratulation
        CongratulationBackgroundImage.SetActive(false);
        CongratulationText.SetActive(false);
    }

}
