﻿using System.ComponentModel.DataAnnotations;

namespace NZWalk.Model
{
    public class AddRegionRequestDto
    {

        [Required]
        [MinLength(3,ErrorMessage ="Code has to be a minimum of 3 characters")]
        [MaxLength(3,ErrorMessage ="Code has to be a maximun of 3 characters")]
        public string? Code { get; set; }

        [Required]
        [MaxLength(3, ErrorMessage = "Code has to be a maximum of 3 characters")]
        public string? Name { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}
