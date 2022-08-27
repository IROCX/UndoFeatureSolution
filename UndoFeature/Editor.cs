
namespace UndoFeature
{
    public class Editor : IEditor
    {

        private string _content = string.Empty;
        IContentHistoryManager _historyManager = new ContentHistoryManager();

        public void Start()
        {
            bool isRunning = true;
            Console.WriteLine("Select your action");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Undo");
            Console.WriteLine("3. Redo");
            Console.WriteLine("0. Exit");


            while (isRunning)
            {
                Console.Write("ACTION : ");
                int action = -1;

                try
                {
                    action = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Try again...");
                }
                catch
                {
                    Console.WriteLine("Invalid input! Try again...");
                }



                switch (action)
                {
                    case 1:
                        TakeInput();
                        break;
                    case 2:
                        HandleUndo();
                        break;
                    case 3:
                        HandleRedo();
                        break;
                    case 0:
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input! Try again...");
                        break;

                }


            }

        }

        public void TakeInput()
        {
            Console.Write("Enter text -> ");
            string newContent = Console.ReadLine();
            Console.WriteLine();
            _content = _historyManager.UpdateContent(_content + newContent);
            Console.WriteLine("CONTENT: " + _content);
        }

        public void HandleUndo()
        {
            string undoResult = _historyManager.Undo();
            if (undoResult == null)
            {
                Console.WriteLine("Undo not available.");
            }
            else
            {
                _content = undoResult;
                Console.WriteLine("CONTENT: " + _content);
            }
        }

        public void HandleRedo()
        {
            string redoResult = _historyManager.Redo();
            if (redoResult == null)
            {
                Console.WriteLine("Redo not available.");
            }
            else
            {
                _content = redoResult;
                Console.WriteLine("CONTENT: " + _content);
            }
        }

    }
}
