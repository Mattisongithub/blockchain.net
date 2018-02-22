using blockchain.net;
using Blockchain.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Blockchain
{
    class Block
    {
        public String BlockID;
        public UInt32 BlockHeight;
        public Transaction Transaction;
        public String ValidatedAt;

        private static List<Block> pendingBlocks = new List<Block>();
        public static List<Block> blocks = new List<Block>();

        List<Transaction> validatedTransactions = new List<Transaction>();

        public static Block GenerateBlock(Transaction transaction)
        {
            Block block = new Block(transaction);
            pendingBlocks.Add(block);

            String PendingBlocksJSON = JsonConvert.SerializeObject(pendingBlocks, Formatting.Indented);
            TextWriter textWriter = new StreamWriter(ChainManager.ChainLocation + "PendingBlocks.json");
            textWriter.WriteLine(PendingBlocksJSON);
            textWriter.Close();

            return block;
        }

        Block(Transaction transaction)
        {
            BlockHeight = uint.Parse(blocks.Count.ToString()) + 1;
            Transaction = transaction;
            BlockID = Encryption.SHA256(BlockHeight.ToString() + Transaction) + new Random().Next(0, 10000000);
        }
    }
}
