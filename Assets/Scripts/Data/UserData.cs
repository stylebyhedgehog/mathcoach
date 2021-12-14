using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserData
{
    [JsonProperty("username")]
    public string username;
    [JsonProperty("password")]
    public string password;

    public UserData(string username, string password)
    {
        this.username = username;
        this.password = password;
    }
}
