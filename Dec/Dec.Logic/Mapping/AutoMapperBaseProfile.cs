using AutoMapper;
using System;
using Dec.DataAccess.Entities;
using Dec.Logic.Identity;
using Dec.Shared.DTOs;

namespace Dec.Logic.Mapping
{
    public class AutoMapperBaseProfile : Profile
    {
        public AutoMapperBaseProfile()
        {
            CreateMap<PersonEntity, PersonDTO>()
                .ForMember(dest => dest.ResidenceId, m => m.MapFrom(src => src.Residence.Id));
            CreateMap<PersonDTO, PersonEntity>()
                .ForMember(dest => dest.UserName, m => m.MapFrom(src => src.Email))
                .ForMember(dest => dest.NormalizedUserName, m => m.MapFrom(src => src.Email.ToUpper()))
                .ForMember(dest => dest.Residence, m => m.MapFrom(src => src.ResidenceId.HasValue ? new ResidenceEntity { Id = src.ResidenceId.Value } : null));
                

            CreateMap<PersonDTO, AppIdentityPerson>()
                .ForMember(dest => dest.LockoutEnd, m => m.MapFrom(src => src.LockoutEnd))
                .ForMember(dest => dest.UserName, m => m.MapFrom(src => src.Email))
                .ForMember(dest => dest.NormalizedUserName, m => m.MapFrom(src => src.Email.ToUpper()));
            CreateMap<AppIdentityPerson, PersonDTO>()
                .ForMember(dest => dest.LockoutEnd, m => m.MapFrom(src => src.LockoutEnd.HasValue ? (DateTime?)DateTime.Parse(src.LockoutEnd.ToString()) : null));

            CreateMap<PersonEntity, AppIdentityPerson>()
                .ForMember(dest => dest.LockoutEnd, m => m.MapFrom(src => src.LockoutEnd));
            CreateMap<AppIdentityPerson, PersonEntity>()
                .ForMember(dest => dest.LockoutEnd, m => m.MapFrom(src => src.LockoutEnd.HasValue ? (DateTime?)DateTime.Parse(src.LockoutEnd.ToString()) : null));

            CreateMap<PersonClaimEntity, PersonClaimDTO>()
                .ForMember(dest => dest.PersonId, m => m.MapFrom(src => src.User != null ? src.User.Id : (int?)null));
            CreateMap<PersonClaimDTO, PersonClaimEntity>()
                .ForMember(dest => dest.User, m => m.MapFrom(src => src.PersonId.HasValue ?  new PersonEntity { Id = src.PersonId.Value } : null));

            CreateMap<PersonClaimDTO, AppIdentityPersonClaim>().ReverseMap();

            //AcceptedLaw
            CreateMap<AcceptedLawEntity, AcceptedLawDTO>()
                .ForMember(dest => dest.BillId, m => m.MapFrom(src => src.Bill != null ? src.Bill.Id : (int?)null));
            CreateMap<AcceptedLawDTO, AcceptedLawEntity>()
                .ForMember(dest => dest.Bill, m => m.MapFrom(src => src.BillId.HasValue ? new BillEntity { Id = src.BillId.Value } : null));

            //ApplySuperVisor
            CreateMap<ApplySuperVisorEntity, ApplySuperVisorDTO>()
                .ForMember(dest => dest.PersonId, m => m.MapFrom(src => src.Person != null ? src.Person.Id : (int?)null));
            CreateMap<ApplySuperVisorDTO, ApplySuperVisorEntity>()
                .ForMember(dest => dest.Person, m => m.MapFrom(src => src.PersonId.HasValue ? new PersonEntity { Id = src.PersonId.Value } : null));

            //Bill
            CreateMap<BillEntity, BillDTO>()
                .ForMember(dest => dest.Pre_BillId, m => m.MapFrom(src => src.Pre_Bill != null ? src.Pre_Bill.Id : (int?)null));
            CreateMap<BillDTO, BillEntity>()
                .ForMember(dest => dest.Pre_Bill, m => m.MapFrom(src => src.Pre_BillId.HasValue ? new Pre_BillEntity { Id = src.Pre_BillId.Value } : null));

            //County
            CreateMap<CountyEntity, CountyDTO>().ReverseMap();

            //Educations
            CreateMap<EducationsEntity, EducationsDTO>().ReverseMap();

            //FingerPrints
            CreateMap<FingerPrintsEntity, FingerPrintsDTO>()
                .ForMember(dest => dest.PersonId, m => m.MapFrom(src => src.Person != null ? src.Person.Id : (int?)null));
            CreateMap<FingerPrintsDTO, FingerPrintsEntity>()
                .ForMember(dest => dest.Person, m => m.MapFrom(src => src.PersonId.HasValue ? new PersonEntity { Id = src.PersonId.Value } : null));

            //NecessaryEducationsList
            CreateMap<NecessaryEducationsListEntity, NecessaryEducationsListDTO>()
                .ForMember(dest => dest.Pre_BillId, m => m.MapFrom(src => src.Pre_Bill != null ? src.Pre_Bill.Id : (int?)null));
            CreateMap<NecessaryEducationsListDTO, NecessaryEducationsListEntity>()
                .ForMember(dest => dest.Pre_Bill, m => m.MapFrom(src => src.Pre_BillId.HasValue ? new Pre_BillEntity { Id = src.Pre_BillId.Value } : null));

            //PersonEducationsList
            CreateMap<PersonEducationsListEntity, PersonEducationsListDTO>()
                .ForMember(dest => dest.PersonId, m => m.MapFrom(src => src.Person != null ? src.Person.Id : (int?)null))
                .ForMember(dest => dest.EducationsId, m => m.MapFrom(src => src.Educations != null ? src.Educations.Id : (int?)null));
            CreateMap<PersonEducationsListDTO, PersonEducationsListEntity>()
                .ForMember(dest => dest.Person, m => m.MapFrom(src => src.PersonId.HasValue ? new PersonEntity { Id = src.PersonId.Value } : null))
                .ForMember(dest => dest.Educations, m => m.MapFrom(src => src.EducationsId.HasValue ? new EducationsEntity { Id = src.EducationsId.Value } : null));

            //Pre_Bill
            CreateMap<Pre_BillEntity, Pre_BillDTO>().ReverseMap();

            //Residence
            CreateMap<ResidenceEntity, ResidenceDTO>()
                .ForMember(dest => dest.CountyID, m => m.MapFrom(src => src.County != null ? src.County.Id : (int?)null));
            CreateMap<ResidenceDTO, ResidenceEntity>()
                .ForMember(dest => dest.County, m => m.MapFrom(src => src.CountyID.HasValue ? new CountyEntity { Id = src.CountyID.Value } : null));

            //ResidenceList
            CreateMap<ResidenceListEntity, ResidenceListDTO>()
                .ForMember(dest => dest.Pre_BillId, m => m.MapFrom(src => src.Pre_Bill != null ? src.Pre_Bill.Id : (int?)null))
                .ForMember(dest => dest.ResidenceId, m => m.MapFrom(src => src.Residence != null ? src.Residence.Id : (int?)null));
            CreateMap<ResidenceListDTO, ResidenceListEntity>()
                .ForMember(dest => dest.Pre_Bill, m => m.MapFrom(src => src.Pre_BillId.HasValue ? new Pre_BillEntity { Id = src.Pre_BillId.Value } : null))
                .ForMember(dest => dest.Residence, m => m.MapFrom(src => src.ResidenceId.HasValue ? new ResidenceEntity { Id = src.ResidenceId.Value } : null));

            //SignatoryList
            CreateMap<SignatoryListEntity, SignatoryListDTO>()
                .ForMember(dest => dest.Pre_BillId, m => m.MapFrom(src => src.Pre_Bill != null ? src.Pre_Bill.Id : (int?)null))
                .ForMember(dest => dest.PersonId, m => m.MapFrom(src => src.Person != null ? src.Person.Id : (int?)null));
            CreateMap<SignatoryListDTO, SignatoryListEntity>()
                .ForMember(dest => dest.Pre_Bill, m => m.MapFrom(src => src.Pre_BillId.HasValue ? new Pre_BillEntity { Id = src.Pre_BillId.Value } : null))
                .ForMember(dest => dest.Person, m => m.MapFrom(src => src.PersonId.HasValue ? new PersonEntity { Id = src.PersonId.Value } : null));

            //SuperVisors
            CreateMap<SuperVisorsEntity, SuperVisorsDTO>()
                .ForMember(dest => dest.PersonId, m => m.MapFrom(src => src.Person != null ? src.Person.Id : (int?)null));
            CreateMap<SuperVisorsDTO, SuperVisorsEntity>()
                .ForMember(dest => dest.Person, m => m.MapFrom(src => src.PersonId.HasValue ? new PersonEntity { Id = src.PersonId.Value } : null));

            //Vote
            CreateMap<VoteEntity, VoteDTO>()
                .ForMember(dest => dest.BillId, m => m.MapFrom(src => src.Bill != null ? src.Bill.Id : (int?)null))
                .ForMember(dest => dest.VoteOpportunitiesId, m => m.MapFrom(src => src.VoteOpportunities != null ? src.VoteOpportunities.Id : (int?)null));
            CreateMap<VoteDTO, VoteEntity>()
                .ForMember(dest => dest.Bill, m => m.MapFrom(src => src.BillId.HasValue ? new BillEntity { Id = src.BillId.Value } : null))
                .ForMember(dest => dest.VoteOpportunities, m => m.MapFrom(src => src.VoteOpportunitiesId.HasValue ? new VoteOpportunitiesEntity { Id = src.VoteOpportunitiesId.Value } : null));

            //VoteOpportunities
            CreateMap<VoteOpportunitiesEntity, VoteOpportunitiesDTO>().ReverseMap();

            //VoteSuperVisor
            CreateMap<VoteSuperVisorEntity, VoteSuperVisorDTO>()
                .ForMember(dest => dest.ApplySuperViserId, m => m.MapFrom(src => src.ApplySuperVisor != null ? src.ApplySuperVisor.Id : (int?)null));
            CreateMap<VoteSuperVisorDTO, VoteSuperVisorEntity>()
                .ForMember(dest => dest.ApplySuperVisor, m => m.MapFrom(src => src.ApplySuperViserId.HasValue ? new ApplySuperVisorEntity { Id = src.ApplySuperViserId.Value } : null));
        }
    }
}
