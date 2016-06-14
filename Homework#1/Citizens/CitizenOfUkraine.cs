using System;

namespace Citizens
{
    public class CitizenOfUkraine : ICitizen
    {
        private DateTime birthDate;
        private Gender gender;
        private string firstName;
        private string lastName;
        private string vatId;

        public CitizenOfUkraine(string firstName, string lastName, DateTime birthDate, Gender gender)
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
            get
            {
                return this.vatId;
            }

            set
            {
                if (value == null)
                {
                    this.vatId = value;
                    return;
                }

                if (IsVatIdValid(value))
                {
                    this.vatId = value;
                }
                else
                {
                    throw new FormatException("The VAT ID is not valid");
                }
            }
        }

        public object Clone()
        {
            CitizenOfUkraine clone = new CitizenOfUkraine(this.FirstName, this.LastName, this.BirthDate, this.gender);
            clone.VatId = this.VatId;

            return clone;
        }

        private static bool IsVatIdValid(string vatId)
        {
            int idChecksum = (int.Parse(vatId[0].ToString()) * (-1)) +
                (int.Parse(vatId[1].ToString()) * 5) +
                (int.Parse(vatId[2].ToString()) * 7) +
                (int.Parse(vatId[3].ToString()) * 9) +
                (int.Parse(vatId[4].ToString()) * 4) +
                (int.Parse(vatId[5].ToString()) * 6) +
                (int.Parse(vatId[6].ToString()) * 10) +
                (int.Parse(vatId[7].ToString()) * 5) +
                (int.Parse(vatId[8].ToString()) * 7);
            int idCheckNumber = (idChecksum % 11) % 10;

            if (idCheckNumber != int.Parse(vatId[9].ToString()))
            {
                return false;
            }

            return true;
        }
    }
}
