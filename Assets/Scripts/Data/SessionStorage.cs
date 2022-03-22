using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionStorage : MonoBehaviour
{
    public static SessionStorage Instance;
    private UserData currentUser;
    public static Action singedInAction;
    public static Action logOutAction;

    private void Awake()
    {
        Instance = this;
    }
    public void setUser(UserData userData)
    {
        currentUser = userData;
        singedInAction?.Invoke();
    }
    public void unsetUser()
    {
        currentUser = null;
        logOutAction?.Invoke();
    }

    public bool isLogIn()
    {
        return currentUser != null;
    }

    public bool isAdmin()
    {
        if (currentUser.username == "admin")
        {
            return true;
        }
        return false;
    }
}
