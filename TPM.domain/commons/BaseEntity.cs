using System.ComponentModel;

namespace TPM.domain.commons
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public bool DeleteSoft { get; set; }

    }
}
