using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LifeUI : MonoBehaviour
{
    public Image fullImage;
    public Image emptyImage;

    private void Awake()
    {
        ShowAsFull();
    }

    public bool IsFull()
    {
        return emptyImage.enabled == false;
    }

    public void ShowAsFull()
    {
        fullImage.enabled = true;
        emptyImage.enabled = false;
    }

    public void ShowAsEmpty()
    {
        fullImage.enabled = true;
        emptyImage.enabled = true;
    }
}
