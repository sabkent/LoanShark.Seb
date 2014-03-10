//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Security.Cryptography;
//using System.Web;
//using DotNetOpenAuth.Messaging.Bindings;
//using DotNetOpenAuth.OAuth2;
//using DotNetOpenAuth.OAuth2.ChannelElements;
//using DotNetOpenAuth.OAuth2.Messages;

//namespace LoanShark.AuthenticationServer.Infrastructure
//{
//    public class ServerHost : IAuthorizationServerHost
//    {
//        public AutomatedAuthorizationCheckResponse CheckAuthorizeClientCredentialsGrant(IAccessTokenRequest accessRequest)
//        {
//            throw new NotImplementedException();
//        }

//        public AutomatedUserAuthorizationCheckResponse CheckAuthorizeResourceOwnerCredentialGrant(string userName, string password, IAccessTokenRequest accessRequest)
//        {
//            throw new NotImplementedException();
//        }

//        public AccessTokenResult CreateAccessToken(IAccessTokenRequest accessTokenRequestMessage)
//        {
//            throw new NotImplementedException();
//        }

//        public ICryptoKeyStore CryptoKeyStore
//        {
//            get { throw new NotImplementedException(); }
//        }

//        public IClientDescription GetClient(string clientIdentifier)
//        {
//            throw new NotImplementedException();
//        }

//        public bool IsAuthorizationValid(IAuthorizationDescription authorization)
//        {
//            throw new NotImplementedException();
//        }

//        public INonceStore NonceStore
//        {
//            get { throw new NotImplementedException(); }
//        }
//    }
//}