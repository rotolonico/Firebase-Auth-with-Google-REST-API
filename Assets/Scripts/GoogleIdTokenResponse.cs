using System;

/// <summary>
/// Response object to exchanging the Google Auth Code with the Id Token
/// </summary>

[Serializable]
public class GoogleIdTokenResponse
{
    public string id_token;
}
