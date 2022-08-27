using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndoFeature
{
    internal interface IContentHistoryManager
    {
        string UpdateContent(string content);
        string Undo();
        string Redo();
    }
}
