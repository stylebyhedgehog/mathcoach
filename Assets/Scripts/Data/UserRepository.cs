using Firebase.Database;
using Firebase.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UserRepository : MonoBehaviour
{
    public static UserRepository Instance;
    private DatabaseReference reference;
    private void Awake()
    {
        if (Instance == null)
        {
            reference = FirebaseDatabase.DefaultInstance.GetReference("users");
            Instance = this;
        }
    }

    public void TryToSignIn(UserData userData, UnityAction<bool> callback)
    {
        string searchUsername = userData.username;
        string searchPassword = userData.password;
        reference.GetValueAsync().ContinueWithOnMainThread(tsk =>
        {
            CheckValue(tsk.Result, userData, callback);
        }
        );
    }

    private void CheckValue(DataSnapshot snapshot, UserData userData, UnityAction<bool> callback)
    {
        var json = snapshot.GetRawJsonValue();
        Dictionary<string, UserData> raws = JsonConvert.DeserializeObject<Dictionary<string, UserData>>(json);
        foreach (var user in raws)
        {
            if (user.Key == userData.username)
            {
                if (user.Value.password == userData.password)
                {
                    SessionStorage.Instance.setUser(userData);
                    callback.Invoke(true);
                    return;
                }
            }
        }
        callback.Invoke(false);
    }

    public void TryToSignUp(UserData userData, string passwordConfirm, UnityAction<int> callback)
    {
        string username = userData.username;
        string password = userData.password;
        if (password != passwordConfirm)
        {
            Debug.Log("не совпали");
            callback.Invoke(0);
            return;
        }
        reference.GetValueAsync().ContinueWithOnMainThread(tsk =>
        {
            var json = tsk.Result.GetRawJsonValue();
            Dictionary<string, UserData> raws = JsonConvert.DeserializeObject<Dictionary<string, UserData>>(json);
            foreach (var user in raws)
            {
                if (user.Key == username)
                {
                    Debug.Log("существует");
                    callback.Invoke(1);
                    return;
                }
            }
            reference.Child(username).Child("username").SetValueAsync(userData.username);
            reference.Child(username).Child("password").SetValueAsync(userData.password);
            callback.Invoke(2);
            SessionStorage.Instance.setUser(userData);
        }
        );

     
    }

    public void LogOut()
    {
        SessionStorage.Instance.unsetUser();
    }
}
