using AutoMapper;
using ScoreTracker.Dtos;
using ScoreTracker.Models;

namespace ScoreTracker.Profiles
{
    public class ScoresProfile : Profile
    {

        public ScoresProfile()
        {
            CreateMap<ScoreDetails, ScoreDetailsDto>();
        }
    }
}
