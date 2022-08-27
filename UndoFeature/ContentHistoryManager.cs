using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndoFeature
{
    public class ContentHistoryManager : IContentHistoryManager
    {

        private Stack<ContentState> _contentChanges = new Stack<ContentState>();
        private Stack<ContentState> _contentChangesUndone = new Stack<ContentState>();

        public ContentHistoryManager()
        {
            _contentChanges.Push(new ContentState(""));
            _contentChangesUndone.Push(new ContentState(""));
        }

        public string Redo()
        {
            if (_contentChangesUndone.Count == 1)
                return null;
            _contentChanges.Push(_contentChangesUndone.Pop());
            return _contentChanges.Peek().getStateContent();
        }

        public string Undo()
        {

            if (_contentChanges.Count == 1)
                return null;
            _contentChangesUndone.Push(_contentChanges.Pop());
            return _contentChanges.Peek().getStateContent();
        }

        public string UpdateContent(string content)
        {
            ContentState newContentState = new ContentState(content);
            _contentChanges.Push(newContentState);
            return newContentState.getStateContent();

        }
    }
}
