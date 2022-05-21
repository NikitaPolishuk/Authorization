using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PopUPs
{
    [SerializeField]
    public PopUpError PopUpError;
}


public class AuthorizationView : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField name;
    [SerializeField]
    private TMP_InputField subName;
    [SerializeField]
    private TMP_InputField login;
    [SerializeField]
    private TMP_InputField mail;
    [SerializeField]
    private TMP_InputField password;
    [SerializeField]
    private TMP_InputField repeatPassword;
    [SerializeField]
    private Button Authorization;
    [SerializeField]
    private PopUPs popUPs = new PopUPs();

    [SerializeField]
    private ProfileView profileView;

    private void Start()
    {
        name.onEndEdit.AddListener((value) =>
        {
            UserData.Instance.name = value;
        });

        subName.onEndEdit.AddListener((value) =>
        {
            UserData.Instance.subName = value;
        });

        login.onEndEdit.AddListener((value) =>
        {
            UserData.Instance.login = value;
        });

        mail.onEndEdit.AddListener((value) =>
        {
            if (!IsValidEmail(value))
            {
                popUPs.PopUpError.nameError.text = "Почта введена неверно";
                popUPs.PopUpError.Open();
                mail.image.color = Color.red;
            }
            else
            {
                mail.image.color = Color.white;
                UserData.Instance.mail = value;
            }

        });

        password.onEndEdit.AddListener((value) =>
        {
            if (!CheckPass(value))
            {
                password.image.color = Color.red;
                popUPs.PopUpError.nameError.text = "Пароль должен состоять из 6 символов. Cодержать цифры, заглавные, строчные буквы и не содержать пробелов";
                popUPs.PopUpError.Open();
            }
            else
            {
                password.image.color = Color.white;
                UserData.Instance.password = value;
            }
        });

        repeatPassword.onEndEdit.AddListener((value) =>
        {
            if (password.text != value)
            {
                repeatPassword.image.color = Color.red;
                popUPs.PopUpError.nameError.text = "Повторно пароль введен верен";
                popUPs.PopUpError.Open();
            }
            else
            {
                repeatPassword.image.color = Color.white;
                UserData.Instance.repeatPassword = value;
            }
        });

        Authorization.onClick.AddListener(() =>
        {
            if(CheckAuth())
            {
                gameObject.SetActive(false);
                profileView.Open();
            }
            else
            {
                popUPs.PopUpError.nameError.text = "Одно из полей не заполнено или заполнено неверно";
                popUPs.PopUpError.Open();
            }
        });
    }

    public bool IsValidEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }

    bool CheckPass(string pass) => pass.Length >= 6
        && pass.Any(char.IsLetter)
        && pass.Any(char.IsDigit)
        && pass.Any(char.IsLower)
        && !pass.Any(char.IsWhiteSpace)
        && pass.Any(char.IsUpper);

    bool CheckAuth()
    {
        if (string.IsNullOrEmpty(UserData.Instance.repeatPassword)
            || string.IsNullOrEmpty(UserData.Instance.name)
            || string.IsNullOrEmpty(UserData.Instance.subName)
            || string.IsNullOrEmpty(UserData.Instance.login)
            || string.IsNullOrEmpty(UserData.Instance.mail)
            || string.IsNullOrEmpty(UserData.Instance.mail)
            || string.IsNullOrEmpty(UserData.Instance.password)) return false;
        else return true;

    }
}
