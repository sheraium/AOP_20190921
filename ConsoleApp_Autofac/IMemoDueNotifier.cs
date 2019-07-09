using System.IO;

namespace ConsoleApp_Autofac
{
    //產生通知動作的呼叫介面
    public interface IMemoDueNotifier
    {
        void MemoIsDue(Memo memo);
    }
    //實作由TextWriter輸出的通知服務
    public class PrintingNotifier : IMemoDueNotifier
    {
        TextWriter _writer;
        // 傳入TextWriter的建構式
        public PrintingNotifier(TextWriter writer)
        {
            _writer = writer;
        }
        // 輸出通知訊息到TextWriter
        public void MemoIsDue(Memo memo)
        {
            _writer.WriteLine("Memo '{0}' is due!", memo.Title);
        }
    }

}