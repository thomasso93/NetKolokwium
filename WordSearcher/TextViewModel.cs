using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace WordSearcher
{
    /// <summary>
    /// Main class for View Model
    /// TODO: follow guidelines
    /// </summary>
    public class TextViewModel : ITextViewModel, INotifyPropertyChanged
    {
        private readonly IDispatcher _dispatcher;
        
        public TextViewModel(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;            
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        private List<string> _savedKeyWords = new List<string>();
        public List<string> SavedKeyWords 
        {
            get 
            {
                return _savedKeyWords;
            }
            set
            {
                _savedKeyWords = value;
                NotifyPropertyChanged();
            }
        }


        private string _query;
        public string Query
        {
            get
            {
                return _query;
            }
            set
            {
                _query = value;
                NotifyPropertyChanged();

            }
        }

        private string _content = Globals.LoremIpsum;
        public string Content
        {
            get
            {
                return _content;
            }
            set
            {
                _content = value;
            }
        }

        Func<bool> _canExecute;
        public Func<bool> CanExecute
        {
            get 
            {
                return _canExecute;
            }
            set 
            {
                _canExecute = value;
                NotifyPropertyChanged();
            }
        }


        private MyCommand _searchCommand;
        public System.Windows.Input.ICommand SearchCommand
        {
            get
            {
                return _searchCommand ?? (_searchCommand = new MyCommand(OnNewSearchCommand, CanExecute));
            }
        }

        private Action OnNewSearchCommand;
        private void onNewSearchCommand() 
        {
            int count =  0;
            if (!(String.IsNullOrEmpty(Query)) && !(String.IsNullOrEmpty(Content)))
            {
                SavedKeyWords.Add(Content);
                string[] split = Content.Split(new Char [] { ' ', '\t', '\n' });
                foreach (string s in split)
                {
                    if (SelectedMethod.VerifyText(s))
                        count++;
                }
                if (count > 0)
                    SearchResult = "RESULTS FOUND: " + count;
                else
                    SearchResult = Globals.NoSearchResults;
                
            }
        }

        private string _searchResult;
        public string SearchResult
        {
            get
            {
                return _searchResult;
            }
            set
            {
                _searchResult = value;
                NotifyPropertyChanged();
            }
        }

        private MyCommand _saveSearchesCommand;
        public System.Windows.Input.ICommand SaveSearchesCommand
        {
            get
            {
                return _saveSearchesCommand;    
            }
        }

        private ASearcher _selectedMethod;
        public ASearcher SelectedMethod
        {
            get
            {
                return _selectedMethod;
            }
            set
            {
                _selectedMethod = value;
                NotifyPropertyChanged();
            }
        }

        private List<ASearcher> _searchMethods;
        public IEnumerable<ASearcher> SearchMethods
        {
            get 
            {
                return _searchMethods;
            }
        }

        
    }
}
