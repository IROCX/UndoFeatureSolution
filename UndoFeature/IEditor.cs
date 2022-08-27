using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndoFeature
{
    public interface IEditor
    {

        void Start();

        void TakeInput();

        void HandleUndo();

        void HandleRedo();

    }
}
