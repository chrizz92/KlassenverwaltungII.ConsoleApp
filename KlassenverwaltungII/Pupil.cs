using System;
using System.Collections.Generic;
using System.Text;

namespace KlassenverwaltungII
{
    /// <summary>
    /// A class that represents pupils of a school
    /// </summary>
    class Pupil
    {
        private int _catalogNr;
        private string _firstName;
        private string _lastName;
        private int _zipCode;

        public void SetCatalogNr(int catalogNr)
        {
            _catalogNr = catalogNr;
        }

        public void SetFirstName(string firstName)
        {
            _firstName = firstName;
        }

        public void SetLastName(string lastName)
        {
            _lastName = lastName;
        }

        public void SetZipCode(int zipCode)
        {
            _zipCode = zipCode;
        }

        public int GetCatalogNr()
        {
            return _catalogNr;
        }

        public string GetFirstName()
        {
            return _firstName;
        }

        public string GetLastName()
        {
            return _lastName;
        }

        public int GetZipCode()
        {
            return _zipCode;
        }
    }
}