using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp_Autofac
{
    internal class Program
    {
        //在記憶體中建立一個IQueryable<Memo>資料來源
        private static IQueryable<Memo> GenSomeMemos()
        {
            IQueryable<Memo> memos = new List<Memo>() {
            new Memo { Title = "Release Autofac 1.0",
                DueAt = new DateTime(2007, 12, 14) },
            new Memo { Title = "Write CodeProject Article",
                DueAt = DateTime.Now },
            new Memo { Title = "End of The World",
                DueAt = new DateTime(2012, 12, 21) }
        }.AsQueryable();
            return memos;
        }

        private static void Main(string[] args)
        {
            //傳統寫法，物件的產生是寫死的
            MemoChecker chkr = new MemoChecker(GenSomeMemos(),
                new PrintingNotifier(Console.Out));
            chkr.CheckNow();

        }
    }
}