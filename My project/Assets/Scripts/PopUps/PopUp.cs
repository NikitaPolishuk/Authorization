using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUp : MonoBehaviour
{
    [SerializeField]
    private Button BackButton;
    private void Start()
    {
        BackButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
    }

    public virtual void Open()
    {
        gameObject.SetActive(true);
    }

}
