using Proyecto26;
using UnityEngine;

/// <summary>
/// Handles authentication calls to Firebase
/// </summary>

public static class FirebaseAuthHandler
{
    private const string ApiKey = "[API_KEY]"; //TODO: Change [API_KEY] to your API_KEY

    /// <summary>
    /// Signs in a user with their Id Token
    /// </summary>
    /// <param name="token"> Id Token </param>
    /// <param name="providerId"> Provider Id </param>
    public static void SingInWithToken(string token, string providerId)
    {
        var payLoad =
            $"{{\"postBody\":\"id_token={token}&providerId={providerId}\",\"requestUri\":\"http://localhost\",\"returnIdpCredential\":true,\"returnSecureToken\":true}}";
        RestClient.Post($"https://identitytoolkit.googleapis.com/v1/accounts:signInWithIdp?key={ApiKey}", payLoad).Then(
            response =>
            {
                // You now have the userId (localId) and the idToken of the user!
                Debug.Log(response.Text);
            }).Catch(Debug.Log);    
    }
}
