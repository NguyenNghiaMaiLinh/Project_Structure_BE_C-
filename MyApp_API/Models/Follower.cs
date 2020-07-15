using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyApp_API.Models
{
    public partial class Follower
    {
        [StringLength(50)]
        public string Id { get; set; }
        [StringLength(50)]
        public string AuthorId { get; set; }
        [StringLength(50)]
        public string FollowerId { get; set; }
        [Column("Create_At", TypeName = "datetime")]
        public DateTime? CreateAt { get; set; }
        [Column("Create_By")]
        [StringLength(50)]
        public string CreateBy { get; set; }
        [Column("Update_At", TypeName = "datetime")]
        public DateTime? UpdateAt { get; set; }
        [Column("Update_By")]
        [StringLength(50)]
        public string UpdateBy { get; set; }
        [Column("Is_Delete")]
        public bool? IsDelete { get; set; }

        [ForeignKey("AuthorId")]
        [InverseProperty("FollowerAuthor")]
        public virtual Register Author { get; set; }
        [ForeignKey("FollowerId")]
        [InverseProperty("FollowerFollowerNavigation")]
        public virtual Register FollowerNavigation { get; set; }
    }
}
