using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Essentialbooks.Models
{
    public class MediaRating
    {
        [Key]
        public int Id { get; set; }
        public virtual int MediaId { get; set; }
        //     public virtual int UserId { get; set; }
        // public virtual string UserId { get; set; }
        public int Rating { get; set; }

        [ForeignKey("MediaId")]
        public virtual TextPiece TextPiece { get; set; }
        /* [ForeignKey("UserId")]
         public virtual RealUser RealUser { get; set; }*/
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }

        //        public string UserId { get; set; }

        /*  public virtual string UserId { get; set; }
          [ForeignKey("UserId")]
          public virtual ApplicationUser AspNetUserLogins { get; set; }*/
        /*  [ForeignKey("")]
          public virtual IndexViewModel UserModel { get; set; }*/

    }
}