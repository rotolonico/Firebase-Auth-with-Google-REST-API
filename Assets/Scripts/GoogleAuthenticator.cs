using System;
using Proyecto26;
using UnityEngine;

/// <summary>
/// Handles calls to the Google provider for authentication
/// </summary>

public static class GoogleAuthenticator
{
    private const string ClientId = "[CLIENT_ID]"; //TODO: Change [CLIENT_ID] to your CLIENT_ID
    private const string ClientSecret = "[CLIENT_SECRET]"; //TODO: Change [CLIENT_SECRET] to your CLIENT_SECRET

    /// <summary>
    /// Opens a webpage that prompts the user to sign in and copy the auth code 
    /// </summary>
    public static void GetAuthCode()
    {
        Application.OpenURL($"https://accounts.google.com/o/oauth2/v2/auth?client_id={ClientId}&redirect_uri=urn:ietf:wg:oauth:2.0:oob&response_type=code&scope=email");
    }
    
    /// <summary>
    /// Exchanges the Auth Code with the user's Id Token
    /// </summary>
    /// <param name="code"> Auth Code </param>
    /// <param name="callback"> What to do after this is successfully executed </param>
    public static void ExchangeAuthCodeWithIdToken(string code, Action<string> callback)
    {
        RestClient.Post($"https://oauth2.googleapis.com/token?code={code}&client_id={ClientId}&client_secret={ClientSecret}&redirect_uri=urn:ietf:wg:oauth:2.0:oob&grant_type=authorization_code", null).Then(
            response => {
                var data = StringSerializationAPI.Deserialize(typeof(GoogleIdTokenResponse), response.Text) as GoogleIdTokenResponse;
                callback(data.id_token);
            }).Catch(Debug.Log);
    }
}
