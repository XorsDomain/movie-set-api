using Catalyte.Apparel.Utilities.HttpResponseExceptions;
using Catalyte.Apparel.Data.Model;
using Google.Apis.Auth;
using System;
using System.Threading.Tasks;

namespace Catalyte.Apparel.Providers.Auth
{
    /// <summary>
    /// This class provides tools to complete backend authorization of Google JWT tokes.
    /// </summary>
    public class GoogleAuthService
    {
        /// <summary>
        /// Parses authorization header value and returns the token.
        /// </summary>
        /// <param name="bearerToken">Authorization header value</param>
        /// <returns>Token string.</returns>
        public string GetTokenFromHeader(string bearerToken)
        {
            // PARSE JWT TOKEN
            if (bearerToken != null && bearerToken.StartsWith("Bearer "))
            {
                return bearerToken.Substring(7);
            }
            else
            {
                throw new BadRequestException("Authorization Header must start with 'Bearer '.");
            }
        }

        /// <summary>
        /// Helper method used to validate and get user information from JWT token.
        /// </summary>
        /// <param name="idToken">Token to validate.</param>
        /// <returns>Validated user information from JWT token.</returns>
        private async Task<GoogleJsonWebSignature.Payload> ValidateIdTokenAndGetUserInfoAsync(string idToken)
        {
            if (string.IsNullOrWhiteSpace(idToken))
            {
                return null;
            }

            try
            {
                return await GoogleJsonWebSignature.ValidateAsync(idToken);
            }
            catch (Exception ex)
            {
                throw new BadRequestException(ex.Message);
            }
        }

    }
}

