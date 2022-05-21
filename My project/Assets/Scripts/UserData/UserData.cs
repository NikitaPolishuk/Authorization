using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserData
{
    private static UserData instance = new UserData();
    public static UserData Instance
    {
        get
        {
            return instance;
        }
    }

    public string name;
    public string subName;
    public string login;
    public string mail;
    public string password;
    public string repeatPassword;
}
