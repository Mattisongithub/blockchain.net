using Blockchain;
using Blockchain.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace blockchain.net
{
    class Validation
    {
        public Validation(Block block)
        {
            FileStream pendingBlocksFile = new FileStream (ChainManager.ChainLocation + "PendingBlocks.json", FileMode.Open);

            String pendingBlocksFileContents;
            TextReader textReader = new StreamReader(pendingBlocksFile);
            pendingBlocksFileContents = textReader.ReadLine();
            textReader.Close();

            List<Block> pendingBlockList = JsonConvert.DeserializeObject<List<Block>>(pendingBlocksFileContents
                .Replace("[", "")
                .Replace("]", ""));

            if (pendingBlockList.Contains(block))
            {
                pendingBlockList.Remove(block);

                String json = JsonConvert.SerializeObject(block, Formatting.Indented);

                Block.blocks.Add(block);

                String ValidatedBlocksJSON = JsonConvert.SerializeObject(Block.blocks, Formatting.Indented);
                TextWriter textWriter = new StreamWriter(ChainManager.ChainLocation + "ValidatedBlocks.json");
                textWriter.WriteLine(ValidatedBlocksJSON);
                textWriter.Close();

                int i = 0;
                do
                {
                    i++;
                } while (block.BlockID != Encryption.SHA256(block.BlockHeight.ToString() + block.Transaction) + i);

                if (File.Exists(ChainManager.ChainLocation + "ValidatedBlocks.json"))
                {
                    float bytes = new FileInfo(ChainManager.ChainLocation + "ValidatedBlocks.json").Length;
                    if (bytes >= 10000000)
                    {
                        // TODO: Archive the chain
                    }
                }
            } else
            {
                throw new NullReferenceException();
            }

        }
    }
}
