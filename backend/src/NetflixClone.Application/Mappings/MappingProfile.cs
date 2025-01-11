using AutoMapper;
using NetflixClone.Application.DTOs;
using NetflixClone.Domain.Entities;

namespace NetflixClone.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // User mappings
        CreateMap<User, UserDto>();
        CreateMap<CreateUserDto, User>();
        CreateMap<UpdateUserDto, User>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

        // Profile mappings
        CreateMap<Profile, ProfileDto>();
        CreateMap<CreateProfileDto, Profile>();
        CreateMap<UpdateProfileDto, Profile>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

        // Movie mappings
        CreateMap<Movie, MovieDto>();
        CreateMap<CreateMovieDto, Movie>();
        CreateMap<UpdateMovieDto, Movie>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

        // Series mappings
        CreateMap<Series, SeriesDto>();
        CreateMap<CreateSeriesDto, Series>();
        CreateMap<UpdateSeriesDto, Series>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

        // Episode mappings
        CreateMap<Episode, EpisodeDto>();
        CreateMap<CreateEpisodeDto, Episode>();
        CreateMap<UpdateEpisodeDto, Episode>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

        // Category mappings
        CreateMap<Category, CategoryDto>();
        CreateMap<CreateCategoryDto, Category>();
        CreateMap<UpdateCategoryDto, Category>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

        // WatchHistory mappings
        CreateMap<WatchHistory, WatchHistoryDto>();
        CreateMap<CreateWatchHistoryDto, WatchHistory>();
        CreateMap<UpdateWatchHistoryDto, WatchHistory>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
    }
} 