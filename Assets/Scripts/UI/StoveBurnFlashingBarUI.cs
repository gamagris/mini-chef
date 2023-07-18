using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveBurnFlashingBarUI : MonoBehaviour
{
    private const string Is_Flashing = "IsFlashing";

    [SerializeField] private StoveCounter stoveCounter;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        stoveCounter.OnProgressChanged += StoveCounter_OnProgressChanged;

        animator.SetBool(Is_Flashing, false);
    }

    private void StoveCounter_OnProgressChanged(object sender, IhasProgress.OnProgressChangedEventArgs e)
    {
        float burnShowAmountProgress = .5f;
        bool show = stoveCounter.IsFried() && e.progressNormalized >= burnShowAmountProgress;

        animator.SetBool(Is_Flashing, show);
    }
}