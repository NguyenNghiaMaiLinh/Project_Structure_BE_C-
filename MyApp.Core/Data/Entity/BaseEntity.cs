using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Core.Data.Entity
{
    public abstract class BaseEntity
    {
        [Key]
        [Column("Id")]
        public string Id { get; set; }

        [Column("Created_By")]
        public string CreatedBy { get; set; }

        [Column("Created_At")]
        public DateTime? CreatedAt { get; set; }

        [Column("Updated_By")]
        public string UpdatedBy { get; set; }

        [Column("Updated_At")]
        public DateTime? UpdatedAt { get; set; }

        public virtual void SetDefaultInsertValue(string username)
        {
            Id = Guid.NewGuid().ToString();
            CreatedAt = DateTime.UtcNow;
            CreatedBy = username;

        }

        public virtual void SetDefaultUpdateValue(string username)
        {
            UpdatedAt = DateTime.UtcNow;
            UpdatedBy = username;
        }
    }
}
