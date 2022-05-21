using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProfileView : MonoBehaviour
{
    [SerializeField]
    private TMP_Text name;
    [SerializeField]
    private TMP_Text subName;
    [SerializeField]
    private TMP_Text login;
    [SerializeField]
    private TMP_Text mail;
    [SerializeField]
    private TMP_Text password;
    [SerializeField]
    private Button Exit;
    [SerializeField]
    private Toggle togglePass;

    private void Start()
    {
        Exit.onClick.AddListener(() =>
        {
            Application.Quit();
        });
        togglePass.onValueChanged.AddListener((value) =>
        {
            if(value)
            {
                password.text = string.Empty;
                for (int i = 0; i < UserData.Instance.password.Length; i++)
                {
                    password.text = password.text + "*";
                }
            }
            else
            {
                password.text = UserData.Instance.password;
            }
        });

    }

    public void Open()
    {
        name.text = UserData.Instance.name;
        subName.text = UserData.Instance.subName;
        login.text = UserData.Instance.login;
        mail.text = UserData.Instance.mail;
        if (!togglePass.isOn)
        {
            password.text = UserData.Instance.password;
        }
        else
        {
            password.text = string.Empty;
            for (int i = 0; i < UserData.Instance.password.Length; i++)
            {
                password.text = password.text + "*";
            }
        }

        gameObject.SetActive(true);
    }

}
