using MatchingDash.Model;
using System.Collections.Generic;
namespace MatchingDash.Reporthelper.Domain
{
    public class Person
    {
        private List<TableResult> _results = null;
        public List<TableResult> Results
        {
            get { return _results; }
            set { _results = value; }
        }
    }
}
