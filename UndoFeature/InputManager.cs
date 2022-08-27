using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndoFeature
{
    public class InputManager
    {
        public static void HandleAction(int inputType)
        {

            //switch (inputType)
            //{
            //    case 1:
            //        HandleInput();
            //        break;
            //    case 2:
            //        string undoResult = _historyManager.Undo();
            //        if (undoResult == null)
            //        {
            //            Console.WriteLine("Undo not available.");
            //            continue;
            //        }
            //        _content = undoResult;
            //        Console.WriteLine("CONTENT: " + _content);
            //        break;
            //    case 3:
            //        string redoResult = _historyManager.Redo();
            //        if (redoResult == null)
            //        {
            //            Console.WriteLine("Redo not available.");
            //            continue;
            //        }
            //        _content = redoResult;
            //        Console.WriteLine("CONTENT: " + _content);
            //        break;
            //    case 0:
            //        isRunning = false;
            //        break;
            //    default:
            //        Console.WriteLine("Invalid input! Try again...");
            //        break;

            //}
        }
        private static void HandleInput()
        {
            //string newContent = Console.ReadLine();
            //_content = _historyManager.updateContent(_content + newContent);
            //Console.WriteLine("CONTENT: " + _content);
        }
    }

}
