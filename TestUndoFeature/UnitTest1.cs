using Microsoft.VisualStudio.TestPlatform.TestHost;
using Moq;
using NUnit.Framework;
using System;
using System.IO;
using System.Text;
using UndoFeature;

namespace TestUndoFeature
{
    public class Tests
    {
        StringBuilder _consoleOutput;
        Mock<TextReader> _consoleInput;

        [SetUp]
        public void Setup()
        {

            _consoleOutput = new StringBuilder();
            var consoleOutputWriter = new StringWriter(_consoleOutput);
            Console.SetOut(consoleOutputWriter);

            _consoleInput = new Mock<TextReader>();
            Console.SetIn(_consoleInput.Object);

        }


        private MockSequence SetupInputsSequence(params string[] inputs)
        {
            var inputSequence = new MockSequence();
            foreach (var input in inputs)
            {
                _consoleInput.InSequence(inputSequence).Setup(x => x.ReadLine()).Returns(input);
            }

            return inputSequence;
        }

        private string[] RunMain()
        {
            MainClass.Main();
            return _consoleOutput.ToString().Split("\r\n");
        }

        [Test]
        public void TestUndoOperation()
        {
            SetupInputsSequence("1", "a", "1", "b", "1", "c", "2", "0");
            var expectedOutput = "CONTENT: ab";
            var actualOutput = RunMain();

            Console.WriteLine(actualOutput);

            Assert.AreEqual(expectedOutput, actualOutput[actualOutput.Length-3]);
        }

        [Test]
        public void TestRedoOperation()
        {
            SetupInputsSequence("1", "a", "1", "b", "1", "c", "2", "3", "0");
            var expectedOutput = "CONTENT: abc";
            var actualOutput = RunMain();

            Console.WriteLine(actualOutput);

            Assert.AreEqual(expectedOutput, actualOutput[actualOutput.Length - 3]);
        }



        [Test]
        public void TestNoContentUndo()
        {
            SetupInputsSequence("2", "0");
            var expectedOutput = "Undo not available.";
            var actualOutput = RunMain();

            Console.WriteLine(actualOutput);

            Assert.AreEqual(expectedOutput, actualOutput[actualOutput.Length - 3]);
        }

        [Test]
        public void TestNoContentRedo()
        {
            SetupInputsSequence("3", "0");
            var expectedOutput = "Redo not available.";
            var actualOutput = RunMain();

            Console.WriteLine(actualOutput);

            Assert.AreEqual(expectedOutput, actualOutput[actualOutput.Length - 3]);
        }
    }
}