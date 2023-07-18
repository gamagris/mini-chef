 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveBurningWarningUI : MonoBehaviour
{
    [SerializeField] private StoveCounter stoveCounter;


    private void Start()
    {
        stoveCounter.OnProgressChanged += StoveCounter_OnProgressChanged;

        Hide();
    }

    private void StoveCounter_OnProgressChanged(object sender, IhasProgress.OnProgressChangedEventArgs e)
    {
        float burnShowAmountProgress = .5f;
        bool show = stoveCounter.IsFried() && e.progressNormalized >= burnShowAmountProgress;

        if (show)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

}
