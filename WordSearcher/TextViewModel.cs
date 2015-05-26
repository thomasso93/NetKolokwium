using System;
using System.Collections.Generic;
using System.Linq;

namespace WordSearcher
{
    /// <summary>
    /// Main class for View Model
    /// TODO: follow guidelines
    /// </summary>
    public class TextViewModel 
    {
        private readonly IDispatcher _dispatcher;
        
        public TextViewModel(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;            
        }
    }
}
