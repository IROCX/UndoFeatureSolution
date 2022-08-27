

using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("UndoFeature.Tests")]
namespace UndoFeature
{
    internal class MainClass
    {
        public static void Main()
        {
            IEditor editor = new Editor();
            editor.Start();

        }
    }
}