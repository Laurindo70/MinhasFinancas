using System.ComponentModel.DataAnnotations.Schema;

namespace MinhasFinancas.Domain.TabelsOfRelation
{
    [Table("User_has_account")]
    public class UserAsAccount
    {
        public Guid User_id { get; set; }
        public Guid Account_id { get; set; }
    }
}
