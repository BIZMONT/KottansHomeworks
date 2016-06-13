using System;

namespace Citizens
{
    public class Citizen : ICitizen
    {
        private DateTime birthDate;
        private Gender gender;
        private string firstName;
        private string lastName;
        private string vatId;

        public Citizen(string firstName, string lastName, DateTime birthDate, Gender gender)
        {
            if (string.IsNullOrEmpty(firstName))
            {
                throw new ArgumentException("First name is invalid!");
            }

            this.firstName = char.ToUpper(firstName[0]) + firstName.Substring(1).ToLower();

            if (string.IsNullOrEmpty(lastName))
            {
                throw new ArgumentException("Second name is invalid!");
            }

            this.lastName = char.ToUpper(lastName[0]) + lastName.Substring(1).ToLower();

            if (DateTime.Compare(birthDate.Date, SystemDateTime.Now().Date) == 1)
            {
                throw new ArgumentException("Date is inavalid");
            }

            this.birthDate = birthDate.Date;

            if (!gender.Equals(Gender.Female) && !gender.Equals(Gender.Male))
            {
                throw new ArgumentOutOfRangeException("Gender of this citizen is invalid!");
            }

            this.gender = gender;
        }

        public DateTime BirthDate
        {
            get { return this.birthDate; }
        }

        public string FirstName
        {
            get { return this.firstName; }
        }

        public Gender Gender
        {
            get { return this.gender; }
        }

        public string LastName
        {
            get { return this.lastName; }
        }

        public string VatId
        {
            get { return this.vatId; }
            set { this.vatId = value; }
        }

        public object Clone()
        {
            Citizen clone = new Citizen(this.FirstName, this.LastName, this.BirthDate, this.gender);
            clone.VatId = this.VatId;

            return clone;
        }
    }
}
