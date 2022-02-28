using System.Collections.Generic;
using DomainModels.Dtos.TagDtos;
using DomainModels.Models;

namespace DomainModels.Dtos
{
   public class ParentChildrenTagDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<TagDto> ChildrenTags { get; set; }
    }
}
