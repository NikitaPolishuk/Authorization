using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopUpError : PopUp
{
    [SerializeField]
    public TMP_Text nameError;

    public override void Open()
    {
        base.Open();
    }
}
