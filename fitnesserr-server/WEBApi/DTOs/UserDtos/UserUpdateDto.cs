using System;
using System.ComponentModel.DataAnnotations;

namespace WEBApi.DTOs
{
    public class UserUpdateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public int Score { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
    }
}
