using Blockchain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blockchain.net
{
    class ChainManager
    {
        public static Queue<Transaction> queuedTransactions = new Queue<Transaction>();
        public static String ChainLocation = @"C:\Users\30630\Desktop\Blockchain\";
    }
}