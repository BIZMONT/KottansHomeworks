using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citizens
{
    public class CitizenRegistry : ICitizenRegistry
    {
        private ICitizen[] citizens;
        private int count;
        private uint length;

        public CitizenRegistry()
        {
            length = 20;
            count = 0;
            citizens = new Citizen[length];
        }

        public CitizenRegistry(uint length)
        {
            this.length = length;
            count = 0;
            citizens = new Citizen[length];
        }

        public ICitizen this[string id]
        {
            get
            {
                if (id == null)
                {
                    throw new ArgumentNullException();
                }

                for (int i = 0; i < count; i++)
                {
                    if (string.Compare(citizens[i].VatId, id) == 0)
                    {
                        return citizens[i];
                    }
                }

                return null;
            }
        }

        public void Register(ICitizen citizen)
        {
            if (count >= length)
            {
                throw new IndexOutOfRangeException("Registry is full!");
            }

            if (citizen.VatId == null)
            {
                citizen.VatId = GenerateVatId(citizen.BirthDate, citizen.Gender);
            }

            citizens[count++] = citizen;
        }

        public string Stats()
        {
            throw new NotImplementedException();
        }

        private string GenerateVatId(DateTime birthDate, Gender gender)
        {
            string idBirthDate = (birthDate.ToOADate() - 1).ToString();
            idBirthDate = new string('0', 5 - idBirthDate.Length) + idBirthDate;
            int idNumber = 0;

            int maxNumber = 0;

            for (int i = 0; i < count; i++)
            {
                string vatId = citizens[i].VatId;
                if (vatId.StartsWith(idBirthDate))
                {
                    idNumber = int.Parse(vatId.Substring(5, 4));
                    if (idNumber % 2 == (int)gender + 1 && idNumber > maxNumber)
                    {
                        maxNumber = idNumber;
                    }
                }
            }

            if (idNumber == 0)
            {
                idNumber = (int)gender + 1;
            }
            else
            {
                idNumber += 2;
            }

            string idNumberString = idNumber.ToString();
            idNumberString = new string('0', 4 - idNumberString.Length) + idNumberString;
            int idChecksum = int.Parse(idBirthDate[0].ToString()) * (-1) + int.Parse(idBirthDate[1].ToString()) * 5 + int.Parse(idBirthDate[2].ToString()) * 7 + int.Parse(idBirthDate[4].ToString()) * 9 + int.Parse(idBirthDate[4].ToString()) * 4 + int.Parse(idNumberString[0].ToString()) * 6 + int.Parse(idNumberString[1].ToString()) * 10 + int.Parse(idNumberString[2].ToString()) * 5 + int.Parse(idNumberString[3].ToString()) * 7;

            return idBirthDate + idNumberString + idChecksum;
        }
    }
}
