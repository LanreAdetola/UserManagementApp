using System;
using System.ComponentModel.DataAnnotations;

namespace MinimalApi.Models
{
public class User
{
        public int Id { get; set; } // ← Add this line

        [Required(ErrorMessage = "First name is required.")]
        public string? FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last name is required.")]
        public string? LastName { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string? Email { get; set; } = string.Empty;

        [Phone(ErrorMessage = "Invalid phone number.")]
        public string? Phone { get; set; } = string.Empty;
 }
}