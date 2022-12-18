using Application.Features.Comments.Commands.CreateComment;
using Application.Features.Comments.Commands.UpdateComment;
using Application.Features.Comments.Dtos;
using Application.Features.Comments.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Comments.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Comment, CreateCommentCommand>()
                .ForMember(p => p.ProductId, opt => opt.MapFrom(p => p.Products.Id))
                .ForMember(p => p.BlogId, opt => opt.MapFrom(p => p.Blogs.Id)).ReverseMap();
            CreateMap<Comment, CreatedCommentDto>()
                .ForMember(p => p.CommentId, opt => opt.MapFrom(p => p.Id))
                .ForMember(p => p.ProductId , opt => opt.MapFrom(p => p.Products.Id))
                .ForMember(p => p.BlogId, opt => opt.MapFrom(p => p.Blogs.Id)).ReverseMap();

            CreateMap<Comment, UpdateCommentCommand>()
                .ForMember(p => p.CommentId, opt => opt.MapFrom(p => p.Id))
                .ForMember(p => p.ProductId, opt => opt.MapFrom(p => p.Products.Id))
                .ForMember(p => p.BlogId, opt => opt.MapFrom(p => p.Blogs.Id)).ReverseMap();

            CreateMap<Comment, UpdatedCommentDto>()
                .ForMember(p => p.CommentId, opt => opt.MapFrom(p => p.Id))
                .ForMember(p => p.ProductId, opt => opt.MapFrom(p => p.Products.Id))
                .ForMember(p => p.BlogId, opt => opt.MapFrom(p => p.Blogs.Id)).ReverseMap();

            CreateMap<Comment, CommentListDto>()
                .ForMember(p => p.BlogName, opt => opt.MapFrom(c => c.Blogs.Title))
                .ForMember(p => p.ProductName, opt => opt.MapFrom(c => c.Products.Title)).ReverseMap();
            CreateMap<IPaginate<Comment>, CommentListModel>().ReverseMap();
        }
    }
}
