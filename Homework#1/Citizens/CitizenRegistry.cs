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
        private uint lenth;

        public CitizenRegistry()
        {
            lenth = 20;
            count = 0;
            citizens = new Citizen[lenth];
        }

        public CitizenRegistry(uint lenth)
        {
            this.lenth = lenth;
            count = 0;
            citizens = new Citizen[lenth];
        }

        public ICitizen this[string id]
        {
            get
            {
                if (id == null)
                {
                    throw new ArgumentNullException();
                }

                foreach (ICitizen citizen in this.citizens)
                {
                    if (string.Compare(citizen.VatId, id) == 0)
                    {
                        return citizen;
                    }
                }

                return null;
            }
        }

        public void Register(ICitizen citizen)
        {
            if(count >= lenth)
            {
                throw new IndexOutOfRangeException("Registry is full!");
            }

            citizens[count++] = citizen;
        }

        public string Stats()
        {
            throw new NotImplementedException();
        }

        private static string GenerateVatId(DateTime birthDate, Gender gender)
        {
            throw new NotImplementedException();
        }
    }
}
