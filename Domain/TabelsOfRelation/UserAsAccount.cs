using System.ComponentModel.DataAnnotations.Schema;

namespace MinhasFinancas.Domain.TabelsOfRelation
{
    [Table("User_has_account")]
    public class UserAsAccount
    {
        [Column("User_id")]
        public Guid UserId { get; set; }
        [Column("Account_id")]
        public Guid AccountId { get; set; }
        public virtual User User { get; set; }
        public virtual Account Account { get; set; }
    }
}
