using MatchingDash.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchingDash.Helpers
{
   public  interface IDialogService
    {
      // public IDialogService(string text, DateTime st);
       //public string Text;
      // public DateTime Timestamp;
      // public async void progressTerminated();
      // public async void ProgressDialog();
        void Setvalues(string text, DateTime timespan);
        string getText();
    }
}
