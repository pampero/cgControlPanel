using System;

namespace Buscador.Domain.com.clarin.filters
{
    public class SelectedFilter
    {
        private string _name;
        private string _value;
        private bool _useForSeo;
        private int _priority;
        private bool _deny;

        public SelectedFilter(string name, string value, bool useForSeo, int priority, bool deny = false)
        {
            _name = name;
            _value = value;
            _useForSeo = useForSeo;
            _priority = priority;
            _deny = false;
        }

        public SelectedFilter()
        {
            
        }

        public bool UseForSeo
        {
            get { return _useForSeo; }
        }

        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Priority
        {
            get { return _priority; }
        }

        public bool Deny
        {
            get { return _deny; }
            set { _deny = value; }
        }
    }
}