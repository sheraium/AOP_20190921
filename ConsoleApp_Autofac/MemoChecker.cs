using System;
using System.Linq;

namespace ConsoleApp_Autofac
{
    public class MemoChecker
    {
        IQueryable<Memo> _memos;
        IMemoDueNotifier _notifier;
        // 建立備忘錄檢查器，顯示到期待辦事項
        public MemoChecker(IQueryable<Memo> memos, IMemoDueNotifier notifier)
        {
            _memos = memos;
            _notifier = notifier;
        }
        // 依目前日期找出已到期項目
        public void CheckNow()
        {
            var overdueMemos = _memos.Where(memo => memo.DueAt < DateTime.Now);
            foreach (var memo in overdueMemos)
                _notifier.MemoIsDue(memo);
        }
    }
}