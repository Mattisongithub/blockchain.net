using System;
using System.Collections.Generic;
using Blockchain.Utils;

namespace Blockchain
{
    public class Account
    {
        public String PublicKey;

        public double Balance { get; internal set; }

        public enum AccountUnlockType
        {
            Private_Key,
            Public_Key,
        }

        public Account (String key, AccountUnlockType accountType)
        {
            if (accountType.Equals(AccountUnlockType.Private_Key))
            {
                PublicKey = Encryption.SHA256(key);
            }
            else if (accountType.Equals(AccountUnlockType.Public_Key))
            {
                PublicKey = key;
            }
        }

    }
}
