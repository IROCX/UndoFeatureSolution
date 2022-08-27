using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndoFeature
{
    class ContentState
    {
        private string _stateContent = null;

        public ContentState(string stateContent)
        {
            _stateContent = stateContent;
        }

        public string getStateContent()
        {
            if (_stateContent == null)
                throw new Exception("No state content found.");
            return _stateContent;
        }
    }
}
