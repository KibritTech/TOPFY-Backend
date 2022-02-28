using System.Collections.Generic;
using DomainModels.Dtos.TagDtos;
using DomainModels.Dtos.UserDtos;

namespace DomainModels.Dtos.PostDtos
{
   public class PostDto
    {
        public int Id { get; set; }
        public string MainImage { get; set; }
        public string Description { get; set; }
        public UserDto User{ get; set; }
        public int MainTagId { get; set; }
        public string MainTagName { get; set; }
        public ICollection<TagDto> SpecificTags { get; set; }
    }
}
