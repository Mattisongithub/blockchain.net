using System;
using Blockchain.Utils;
using blockchain.net;

namespace Blockchain
{

    public class Transaction
    {
        public String TransactionID;
        public Account To;
        public Account From;
        public String Data;
        public Double Value;
        public String Date;

        public static Transaction GenerateNewTransaction(String _to, String _privateKey, String _data, Double _value)
        {
            Transaction transaction = new Transaction (_to, _privateKey, Encryption.Encrypt(_data), _value);
            
            if (new Account(_privateKey, Account.AccountUnlockType.Private_Key).Balance >= _value)
            {
                Validation validation = new Validation (Block.GenerateBlock(transaction));
            }

            return transaction;
        }

        Transaction(String to, String privateKey, string data, double value)
        {
            // Initialize transaction
            To = new Account(to, Account.AccountUnlockType.Public_Key); 
            From = new Account(privateKey, Account.AccountUnlockType.Private_Key);
            Data = data;
            Value = value;
            Date = DateTime.Now.ToString();
            TransactionID = Encryption.SHA256(To.PublicKey + From.PublicKey + Date + DateTime.Now.Millisecond);

            // Verifying previous transactions


            // Signing
                // TODO: Digital signing
        }
    }
}
