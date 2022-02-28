using System;
using System.Collections.Generic;
using System.Linq;
using DomainModels.Dtos.PostDtos;
using DomainModels.Dtos.TagDtos;
namespace DomainModels.Dtos
{
    public class ExplorerPageDto
    {
        public ExplorerPageDto(int currentPage,int count,List<PostDto>posts,List<TagDto>tags)
        {
            if (count != 0)
            {
                Posts = posts.Skip((currentPage - 1) * count).Take(count).ToList();
                TotalCount = (int)Math.Ceiling((decimal)posts.Count / count);
                HasNext = currentPage < TotalCount;
                HasPrevious = currentPage > 1;
                Tags = tags;
                CurrentPage = currentPage;
            }
        }
        public int CurrentPage { get; set; } 
        public bool HasNext { get; set; }
        public bool HasPrevious { get; set; }
        public int TotalCount { get; set; }
        public List<PostDto> Posts { get; set; }
        public List<TagDto>Tags{ get; set; }
    }
}
