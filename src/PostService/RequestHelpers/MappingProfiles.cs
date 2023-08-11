using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PostService.DTOs;
using PostService.Entities;

namespace PostService.RequestHelpers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Post, PostDto>().IncludeMembers(x => x.Comments);
        CreateMap<Comment, CommentDto>();
        CreateMap<List<Comment>, PostDto>()
            .ForMember(p => p.Comments, o => o.MapFrom(s => s));

        CreateMap<CreatePostDto, Post>();

    }
}