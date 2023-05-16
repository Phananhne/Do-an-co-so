﻿using Do_an_co_so.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Do_an_co_so.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }
        [StringLength(50)]
        [DisplayName("Họ tên")]
        public string CustomerFullName { get; set; }
        [Required]
        [StringLength(50)]
        [DisplayName("Tài khoản")]
        public string CustomerUserName { get; set; }
        [Required]
        [StringLength(50)]
        [DisplayName("Mật khẩu")]
        public string CustomerPassword { get; set; }
        [DisplayName("Ngày khởi tạo")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTime CustomerDateCreated { get; set; } = DateTime.Now;
        [DisplayName("Email")]
        [StringLength(50)]
        public string CustomerEmail { get; set; }
        [DisplayName("Địa chỉ")]
        [StringLength(50)]
        public string CustomerAddress { get; set; }
        [DisplayName("Số điện thoại")]
        public string? CustomerPhone { get; set; }
        [DisplayName("Trạng thái")]
        public bool CustomerState { get; set; }
        [StringLength(50)]
        [DisplayName("Hình đại diện")]
        public string? CustomerImage { get; set; }
        public ICollection<Order> Orders { get; set; }
        public virtual ICollection<ProductRating> ProductRatings { get; set; }
        public virtual ICollection<Favorite> Favorites { get; set; }
    }
}
