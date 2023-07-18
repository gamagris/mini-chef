using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeliveryResultUI : MonoBehaviour
{
    private const string Popup = "Popup";

    [SerializeField] private Image backgroundImage;
    [SerializeField] private Image iconImage;
    [SerializeField] private TextMeshProUGUI messageText;
    [SerializeField] private Color successColor;
    [SerializeField] private Color failedColor;
    [SerializeField] private Sprite successSprite;
    [SerializeField] private Sprite failedSprite;

    private Animator animator;
    
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }


    private void Start()
    {
        DeliveryManager.Instance.OnRecipeSuccess += Instance_OnRecipeSuccess;
        DeliveryManager.Instance.OnRecipeFailed += Instance_OnRecipeFailed;

        gameObject.SetActive(false);
    }

    private void Instance_OnRecipeFailed(object sender, System.EventArgs e)
    {
        gameObject.SetActive(true);
        animator.SetTrigger(Popup);
        backgroundImage.color = failedColor;
        iconImage.color = failedColor;
        messageText.text = "DELIVERY\nFAILED";
    }

    private void Instance_OnRecipeSuccess(object sender, System.EventArgs e)
    {
        gameObject.SetActive(true);
        animator.SetTrigger(Popup);
        backgroundImage.color = successColor;
        iconImage.color = successColor;
        messageText.text = "DELIVERY\nSUCCES";
    }
}
