using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schalken.PhotoDesktop
{
    public class HistoryStack
    {
        Dictionary<string, Stack<int>> _screenList = new Dictionary<string, Stack<int>>();

        internal void Push(string screenName, int currentImage)
        {
            // check if screen exists in the list
            if (_screenList.Keys.Contains(screenName))
            {
                // yes --> use existing                
                _screenList[screenName].Push(currentImage);
            }
            else
            {
                // no --> create new stack
                Stack<int> stack = new Stack<int>();
                stack.Push(currentImage);
                _screenList.Add(screenName, stack);
            }
        }

        internal int Count(string screenName)
        {
            // check if screen exists in the list
            if (_screenList.Keys.Contains(screenName))
            {
                // yes --> use existing                
                return _screenList[screenName].Count();
            }
            else
                throw new IndexOutOfRangeException("Screen '" + screenName + "' doesn't exist.");
        }

        internal int Pop(string screenName)
        {
            // check if screen exists in the list
            if (_screenList.Keys.Contains(screenName))
            {
                // yes --> use existing                
                return _screenList[screenName].Pop();
            }
            else
                throw new IndexOutOfRangeException("Screen '" + screenName + "' doesn't exist.");
        }
    }
}
