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

        [Column("Create_By")]
        public string CreateBy { get; set; }

        [Column("Create_At")]
        public DateTime? CreateAt { get; set; }

        [Column("Update_By")]
        public string UpdateBy { get; set; }

        [Column("Update_At")]
        public DateTime? UpdateAt { get; set; }

        public virtual void SetDefaultInsertValue(string username)
        {
            Id = Guid.NewGuid().ToString();
            CreateAt = DateTime.UtcNow;
            CreateBy = username;

        }

        public virtual void SetDefaultUpdateValue(string username)
        {
            UpdateAt = DateTime.UtcNow;
            UpdateBy = username;
        }
    }
}
