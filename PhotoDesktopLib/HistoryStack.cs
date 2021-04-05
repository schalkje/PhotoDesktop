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
        Dictionary<string, List<int>> _screenImagesList = new Dictionary<string, List<int>>();
        Dictionary<string, int> _screenPointer = new Dictionary<string, int>();

        private int _lastNumber = -1; // used for sequential mode

        public Dictionary<string, List<int>> ScreenImagesList
        {
            get { return _screenImagesList;  }
        }

        public List<string> DebugContent
        {
            get
            {
                List<string> output = new List<string>();
                foreach (string screen in _screenImagesList.Keys)
                {
                    output.Add(screen);

                    List<int> imageNumbers = _screenImagesList[screen];
                    for ( int i = 0; i < imageNumbers.Count; i++)
                    {
                        output.Add(string.Format(" - {0} {1}", imageNumbers[i], _screenPointer[screen]==i?"<---":""));
                    }
                }
                return output;
            }
        }

        public int Count(string screenName)
        {
            // check if screen exists in the list
            if (_screenImagesList.Keys.Contains(screenName))
            {
                // yes --> use existing                
                return _screenImagesList[screenName].Count();
            }
            else
                throw new IndexOutOfRangeException("Screen '" + screenName + "' doesn't exist.");
        }

        public int Previous(string screenName)
        {
            // check if screen exists in the list
            if (_screenImagesList.Keys.Contains(screenName))
            {
                // move pointer
                if (_screenPointer[screenName] > 0) _screenPointer[screenName]--;

                // yes --> use existing                
                return _screenImagesList[screenName][_screenPointer[screenName]];
            }
            else
                throw new IndexOutOfRangeException("Screen '" + screenName + "' doesn't exist.");
        }

        public int Next(string screenName, int max, PhotoDesktop.OrderModes orderMode)
        {
            // check if screen exists in the list
            if (!_screenImagesList.Keys.Contains(screenName))
            {
                // no --> create new image list
                List<int> imageNumbers = new List<int>();
                _screenImagesList.Add(screenName, imageNumbers);

                // initialize pointer
                _screenPointer.Add(screenName, -1);
            }

            // check pointer
            if (_screenPointer[screenName] < _screenImagesList[screenName].Count - 1)
            {
                // move pointer
                _screenPointer[screenName]++;

                return _screenImagesList[screenName][_screenPointer[screenName]];
            }
            else
            { 
                // determine next new photo
                int imageNumber;
                if (orderMode == PhotoDesktop.OrderModes.Sequential)
                {
                    // cycle to the begin when the last image has been displayed
                    if (_lastNumber >= max-1) _lastNumber = -1;

                    imageNumber = ++_lastNumber;
                }
                else
                {
                    Random r = new Random((int)DateTime.Now.Ticks);

                    // todo: avoid repeats in random order images
                    imageNumber = r.Next(max);
                }

                _screenImagesList[screenName].Add(imageNumber);
                _screenPointer[screenName]++;

                return imageNumber;
            }
        }

        public int Current(string screenName)
        {
            return _screenImagesList[screenName][_screenPointer[screenName]];
        }

        internal int Rotate(string screenName, string fromScreenName)
        {
            // check if screen exists in the list
            if (!_screenImagesList.Keys.Contains(screenName))
            {
                // no --> create new image list
                List<int> imageNumbers = new List<int>();
                _screenImagesList.Add(screenName, imageNumbers);

                // initialize pointer
                _screenPointer.Add(screenName, -1);
            }

            // check pointer
            if (_screenPointer[screenName] < _screenImagesList[screenName].Count - 1)
            {
                // move pointer
                _screenPointer[screenName]++;

                return _screenImagesList[screenName][_screenPointer[screenName]];
            }
            else
            {
                int imageNumber = _screenImagesList[fromScreenName][_screenPointer[fromScreenName]];
                _screenImagesList[screenName].Add(imageNumber);
                _screenPointer[screenName]++;
                return imageNumber;
            }
        }
    }
}
